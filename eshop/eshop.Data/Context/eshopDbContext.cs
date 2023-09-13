using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Context
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kozmetik", Description = "Tüm kozmetik ürünleri" },
                new Category { Id = 2, Name = "Teknoloji", Description = "Laptop, Ses sistemleri, kameralar" },
                new Category { Id = 3, Name = "Kırtasiye", Description = "Kalem, silgi ve tahta :)" }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Eye liner", CreatedDate = DateTime.Now, Description = "İncecik kalemler", Price = 250, Stock = 100 },
                new Product { Id = 2, CategoryId = 2, Name = "Dell XPS 13", CreatedDate = DateTime.Now, Description = "....", Price = 75000, Stock = 100 },
                new Product { Id = 3, CategoryId = 3, Name = "Beyaz Tahta", CreatedDate = DateTime.Now, Description = "70 x 100 cm çalışma tahtası", Price = 250, Stock = 100 }


               );
        }
    }
}
