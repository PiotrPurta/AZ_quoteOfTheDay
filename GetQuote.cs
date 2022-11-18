using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using PPP.Quotes.services;

namespace PPP.Quotes
{
    public class GetQuote
    {
        private readonly IQuotesService _quoteService;

        public GetQuote(IQuotesService quoteService)
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
