using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using PPP.Quotes.services;
using System.Collections.Generic;
using System.Linq;

namespace PPP.Quotes
{
    public class GetResumeData
    {
        private readonly IQuoteService _quoteService;

        public GetResumeData(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [FunctionName("GetResumeData")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, 
            [CosmosDB(databaseName: "Resume", containerName: "Data", Connection = "CosmosDB")]IEnumerable<dynamic> profile)

        {
            if (profile == null || profile.Count() != 1){
                return new BadRequestObjectResult("Incorrect data");
            }

            return new OkObjectResult(profile.First().ToString());
        }
    }
}
