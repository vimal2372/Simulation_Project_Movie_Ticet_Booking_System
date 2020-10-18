using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Model;


namespace AdminApi.DBContexts
{
    public class AdminContext:DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    UserName = "Vimal",
                   
                    Password = "123"
                    
                 

                },
                new Admin
                {

                    Id = 2,
                    UserName = "rajat",
                    Password = "123"
                    
                }
               
            );

    }
}
