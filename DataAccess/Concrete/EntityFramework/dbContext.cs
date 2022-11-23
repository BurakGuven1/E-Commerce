using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class dbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Ecommerce; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // db tarafında hata verdi ( sürüm kaynaklı ) " Bu kod yazılınca primary key olduğunu algıladı " !!!!
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>().HasKey(o => o.OrderID);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vendor>().HasKey(o => o.VendorID);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorProduct> VendorProduct { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Users> Users{ get; set; }
        

    }
}
