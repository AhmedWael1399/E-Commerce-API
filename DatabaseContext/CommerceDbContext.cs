using Microsoft.EntityFrameworkCore;
using Models;


namespace DatabaseContext
{
    public class CommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductCategory>()
                    .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                    .HasOne(p => p.Product)
                    .WithMany(pc => pc.ProductCategory)
                    .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductCategory>()
                    .HasOne(p => p.Categories)
                    .WithMany(pc => pc.ProductCategory)
                    .HasForeignKey(c => c.CategoryId);

            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            var categories = new List<Categories>
            {
                new () { Id = 1, Type = "Electronics", Description = "Electronic devices and gadgets" },
                new () { Id = 2, Type = "Clothing", Description = "Apparel and accessories" },
                new () { Id = 3, Type = "Books", Description = "Printed and digital reading materials" }
            };
            modelBuilder.Entity<Categories>().HasData(categories);

            var products = new List<Product>
            {
                new () { Id = 1, Name = "Laptop", Price = 999.99, Description = "High-performance laptop" },
                new () { Id = 2, Name = "T-Shirt", Price = 19.99, Description = "Cotton T-Shirt" },
                new () { Id = 3, Name = "Headphones", Price = 79.99, Description = "Wireless Headphones" },
                new () { Id = 4, Name = "Jeans", Price = 49.99, Description = "Slim-fit Jeans" },
                new () { Id = 5, Name = "The Great Gatsby", Price = 12.99, Description = "Classic novel by F. Scott Fitzgerald" },
                new () { Id = 6, Name = "Smartphone", Price = 699.99, Description = "Flagship smartphone" }
            };
            modelBuilder.Entity<Product>().HasData(products);

            var productCategories = new List<ProductCategory>
            {
                new () {ProductId = 1, CategoryId = 1},
                new () {ProductId = 6, CategoryId = 1},
                new () {ProductId = 2, CategoryId = 2}
            };
            modelBuilder.Entity<ProductCategory>().HasData(productCategories);
        }
    }
}
