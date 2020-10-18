using BookingtApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookingtApi.Repository
{
  public  interface IBookingtRepository
    {
      
        public IEnumerable<Bookingt> GetBookingts();
        public void InsertBookingt(Bookingt bookingt);
        public void Save();  
    }
}
