using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Model;

namespace AdminApi.Repository
{
  public  interface IAdminRepository
    {
        public void DeleteAdmin(int adminId);
        public Admin GetAdminById(int adminId);
        public IEnumerable<Admin> GetAdmins();
        public void InsertAdmin(Admin admin);
        public void Save();
        public void UpdateAdmin(Admin admin);
    }
}
