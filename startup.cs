using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PPP.Quotes.services;

[assembly: FunctionsStartup(typeof(PPP.Quotes.Startup))]

namespace PPP.Quotes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IQuotesService, QuoteService>();
        }
    }
}