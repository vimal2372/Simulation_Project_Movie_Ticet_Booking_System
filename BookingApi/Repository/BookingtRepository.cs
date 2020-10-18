using AdminApi.DBContexts;
using BookingtApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingtApi.Repository;
using UserApi.Repository;

namespace BookingtApi.Repository
{
    public class BookingtRepository : IBookingtRepository
    {
        private readonly BookingtContext _dbContext;
       

        public BookingtRepository(BookingtContext dbContext)
        {
           
            _dbContext = dbContext;
        }

      
     

        public IEnumerable<Bookingt> GetBookingts()
        {
            return _dbContext.Bookingts.ToList();
        }

       
        public void InsertBookingt(Bookingt bookingt)
        {
            _dbContext.Bookingts.Add(bookingt);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

       

        
    }
}
