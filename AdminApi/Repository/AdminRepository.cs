using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.DBContexts;
using AdminApi.Model;

namespace AdminApi.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminContext _dbContext;
       

        public AdminRepository(AdminContext dbContext)
        {
           
            _dbContext = dbContext;
        }

        public void DeleteAdmin(int adminId)
        {
            var admin = _dbContext.Admins.Find(adminId);
            _dbContext.Admins.Remove(admin);
            Save();
        }

       

        public Admin GetAdminById(int adminId)
        {
            return _dbContext.Admins.Find(adminId);
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return _dbContext.Admins.ToList();
        }

        

       

        public void InsertAdmin(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            Save();
        }

        

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAdmin(Admin admin)
        {
            _dbContext.Entry(admin).State = EntityState.Modified;
            Save();
        }

        
    }
}
