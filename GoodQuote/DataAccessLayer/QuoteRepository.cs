using GoodQuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodQuote.DataAccessLayer
{
    public class QuoteRepository : IQuoteRepository
    {
        public List<Quote> GetQuotes()
        {
            using (var context = new QuoteDBContext())
            {
                return context.Quotes.OrderBy(q => q.Author).ToList();
            }
        }
        public void AddQuote(Quote temp)
        {
            using (var context = new QuoteDBContext())
            {
                context.Quotes.Add(temp);
                context.SaveChanges();
            }
        }
        public Quote GetQuoteByID(int ID)
        {
            using (var context = new QuoteDBContext())
            {
                return context.Quotes.First(q => q.QuoteID == ID);
            }
        }
        public void EditQuote(Quote temp)
        {
            using (var context = new QuoteDBContext())
            {
                context.Quotes.Update(temp);
                context.SaveChanges();
            }
        }
        public void DeleteQuote(int ID)
        {
            using (var context = new QuoteDBContext())
            {
                Quote temp = context.Quotes.First(q => q.QuoteID == ID);
                context.Quotes.Remove(temp);
                context.SaveChanges();
            }
        }
        public Quote GetRandomQuote()
        {
            using (var context = new QuoteDBContext())
            {
                Random myObject = new Random();
                int max = context.Quotes.ToList().Count();
                int rando = myObject.Next(0, max);
                return context.Quotes.Skip(rando).First();
            }
        }
    }
}
