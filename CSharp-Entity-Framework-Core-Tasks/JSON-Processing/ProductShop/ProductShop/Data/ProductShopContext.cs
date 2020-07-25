namespace ProductShop.Data
{
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProductShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId});
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .HasKey(x => x.Id);

                entity
                    .Property(x => x.BuyerId)
                    .IsRequired(false);

                entity
                    .Property(x => x.SellerId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(f => f.FirstName)
                    .IsRequired(false);

                entity
                    .Property(l => l.LastName)
                    .IsRequired();

                entity
                    .Property(a => a.Age)
                    .IsRequired(false);

                entity.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId);

                entity.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId);
            });
        }
    }
}