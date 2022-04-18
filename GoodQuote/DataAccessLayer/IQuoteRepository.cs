using GoodQuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodQuote.DataAccessLayer
{
    public interface IQuoteRepository
    {
        List<Quote> GetQuotes();
        void AddQuote(Quote quote);
        Quote GetQuoteByID(int ID);
        void EditQuote(Quote temp);
        void DeleteQuote(int ID);
        Quote GetRandomQuote();
    }
}
