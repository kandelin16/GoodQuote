using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodQuote.Models
{
    public class QuoteDBContext : DbContext
    {
        public QuoteDBContext()
        {
        }

        public QuoteDBContext(DbContextOptions<QuoteDBContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Settings.QuoteDBConnectionString);
            }
        }
    }
}
