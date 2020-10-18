using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Model;

namespace UserApi.Repository
{
  public  interface IUserRepository
    {
        public void DeleteUser(int userId);
        public User GetUserById(int userId);
        public IEnumerable<User> GetUsers();
        public void InsertUser(User user);
        public void Save();
        public void UpdateUser(User user);
    }
}
