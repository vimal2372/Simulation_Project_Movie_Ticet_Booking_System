using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Model;


namespace UserApi.DBContexts
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Vimal",
                    Email = "dfjfj@d.com",
                    Password = "123",
                    
                    PhoneNumber = "9756145456",

                },
                new User
                {

                    Id = 2,
                    UserName = "rajat",
                    Email = "dab@d.com",
                    Password = "124",
                    PhoneNumber = "9756148465",
                },
                new User
                {
                    Id = 3,
                    UserName = "arjun",
                    Email = "abc@d.com",
                    Password = "125",
                    PhoneNumber = "9753453245",
                }
            );

    }
}
