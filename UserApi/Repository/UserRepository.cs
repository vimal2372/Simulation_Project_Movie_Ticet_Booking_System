using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.DBContexts;
using UserApi.Model;

namespace UserApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;
       

        public UserRepository(UserContext dbContext)
        {
           
            _dbContext = dbContext;
        }
        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            _dbContext.Users.Remove(user);
            Save();
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void InsertUser(User user)
        {
            _dbContext.Users.Add(user);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            Save();
        }
    }
}
