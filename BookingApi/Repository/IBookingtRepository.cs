using BookingtApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UserApi.Repository
{
  public  interface IBooingtRepository
    {
        
        public IEnumerable<Bookingt> GetBookingts();
        public void InsertBookingt(Bookingt bookingt);
        public void Save();
       
    }
}
