using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using PPP.Quotes.services;

namespace PPP.Quotes
{
    public class GetQuote
    {
        private readonly IQuoteService _quoteService;

        public GetQuote(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [FunctionName("GetQuote")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            return new OkObjectResult(_quoteService.GetTodayQuote());
        }
    }
}
