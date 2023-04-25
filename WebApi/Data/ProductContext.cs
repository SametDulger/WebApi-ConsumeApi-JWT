using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Data
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(new Category[]
            {

                new() { Id = 1, Name = "Elektronik"},
                new() { Id = 2, Name = "Giyim"}

            });


            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){ Id = 1, Name = "Bilgisayar", CreatedDate = DateTime.Now.AddDays(-3), Price =15000, Stock=300, CategoryId =1 },
                new(){ Id = 2, Name = "Telefon", CreatedDate = DateTime.Now.AddDays(-5), Price =5000, Stock=500, CategoryId =1 },
                new(){ Id = 3, Name = "Klavye", CreatedDate = DateTime.Now.AddDays(-8), Price =500, Stock=450, CategoryId =1 },
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
