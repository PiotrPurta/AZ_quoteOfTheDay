using Azure;
using Azure.Data.Tables;

public class Quote : ITableEntity
{
    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }
    
    public ETag ETag { get; set; }

    public string Author { get; set; }
}