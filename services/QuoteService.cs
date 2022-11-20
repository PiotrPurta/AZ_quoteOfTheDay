using System;
using PPP.Quotes.model;

namespace PPP.Quotes.services
{
    public class QuoteService : IQuotesService
    {
        private readonly Quote[] _quotes = StaticQuotes.Quotes;

        public Quote GetTodayQuote()
        {
            return _quotes[GetRandomQuoteIndex()];
        }

        private int GetRandomQuoteIndex(){
            Random randomGenerator = new Random();
            return randomGenerator.Next(0, _quotes.Length);
        }
    }
}