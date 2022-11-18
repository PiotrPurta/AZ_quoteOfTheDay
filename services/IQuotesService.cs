using PPP.Quotes.model;

namespace PPP.Quotes.services
{
    public interface IQuotesService
    {
        Quote GetTodayQuote();
    }
}