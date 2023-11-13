using BusinessObject.Model;
using BusinessObject.Model.Authen;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Context
{
    public class eStoreDBContext : DbContext
    {
        public eStoreDBContext()
        {       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = Guid.NewGuid(), FirstName = "Duan", LastName = "Ho", Email = "duan@gmail.com", Password = "123123Aa.", UserName = "duan123", Role = "Adminstrator" },
                new User { UserId = Guid.NewGuid(), FirstName = "A", LastName = "Nguyen", Email = "nva@gmail.com", Password = "123123Aa.", UserName = "nva", Role = "Customer" },
                new User { UserId = Guid.NewGuid(), FirstName = "Admin", LastName = "01", Email = "admin@gmail.com", Password = "123123Aa.", UserName = "admin01", Role = "Adminstrator" },
                new User { UserId = Guid.NewGuid(), FirstName = "B", LastName = "Nguyen", Email = "nvb@gmail.com", Password = "123123Aa.", UserName = "nvb", Role = "Customer" }
                );
        }
    }
}
