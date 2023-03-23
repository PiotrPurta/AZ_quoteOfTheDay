using PPP.Quotes.model;

namespace PPP.Quotes.services
{
    public interface IQuoteService
    {
        Quote GetTodayQuote();
    }
}