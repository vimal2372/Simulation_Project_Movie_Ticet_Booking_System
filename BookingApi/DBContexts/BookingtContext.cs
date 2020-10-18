using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookingtApi.Model;

namespace AdminApi.DBContexts
{
    public class BookingtContext:DbContext
    {
        public BookingtContext(DbContextOptions<BookingtContext> options) : base(options)
        {
        }
        public DbSet<Bookingt> Bookingts { get; set; }


       
    }
}
