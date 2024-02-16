using System.Text.Json;
using Azure.Data.Tables;
using Microsoft.ApplicationInsights;
using Microsoft.Azure.Functions.Worker;

public class ShuffleTodayQuotes
{
    [Function("DHB_ShuffleTodayQuotes")]
    [BlobOutput("blog-util-files/todayQuote.txt", Connection = "AzureWebJobsStorage")]
    public string Run(
        [TimerTrigger("0 0 0 * * *")]TimerInfo myTimer,
        [TableInput("Quotes", Connection = "AzureWebJobsStorage")] TableClient tableClient,
        [BlobInput("blog-util-files/todayQuote.txt", Connection = "AzureWebJobsStorage")] string quoteFile)
    {
        Quote currentQuote = JsonSerializer.Deserialize<Quote>(quoteFile);
        List<Quote> quotes = tableClient.Query<Quote>(element => element.PartitionKey != currentQuote.PartitionKey).ToList();

        int randomizedIndex = new Random().Next(quotes.Count - 1);
        Quote newQuote = quotes.ElementAt(randomizedIndex);

        LogShuffleAction(int.Parse(currentQuote.PartitionKey), randomizedIndex);
        return JsonSerializer.Serialize(newQuote);
    }

    private void LogShuffleAction(int oldIndex, int newIndex)
    {
        TelemetryClient telemetryClient = new TelemetryClient(new Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration{
            ConnectionString = Environment.GetEnvironmentVariable("APPINSIGHTS_CONNECTIONSTRING")
        });

        telemetryClient.TrackEvent($"DHB_ShuffleTodayQuotes function fired. Old quote id: {oldIndex}, new quote id: {newIndex}");
    }
}