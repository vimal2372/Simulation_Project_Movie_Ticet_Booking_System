using BookingtApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BookingtApi.DBContexts
{
    public class BookingtContext:DbContext
    {
        public BookingtContext(DbContextOptions<BookingtContext> options) : base(options)
        {
        }
        public DbSet<Bookingt> Bookingts { get; set; }


       

    }
}
