using Microsoft.EntityFrameworkCore;
 using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .HasKey(c => c.CustomerId);

                entity
                    .Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity
                    .Property(c => c.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(80);

                entity
                    .Property(p => p.CreditCardNumber)
                    .IsRequired()
                    .IsUnicode();

                entity
                    .HasMany(p => p.Sales)
                    .WithOne(s => s.Customer)
                    .HasForeignKey(k => k.CustomerId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity
                    .HasKey(s => s.SaleId);

                entity
                    .Property(s => s.Date)
                    .IsRequired();    
                
                entity
                    .HasOne(p => p.Product)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(p => p.ProductId);

                entity
                    .HasOne(p => p.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(p => p.CustomerId);

                entity
                    .HasOne(p => p.Store)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(p => p.StoreId);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity
                    .HasKey(s => s.StoreId);

                entity
                    .Property(s => s.Name)                    
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(80);

                entity
                    .HasMany(p => p.Sales)
                    .WithOne(s => s.Store)
                    .HasForeignKey(k => k.StoreId);
            });

            modelBuilder.Entity<Product> (entity =>
            {
                entity
                    .HasKey(p => p.ProductId);

                entity
                    .Property(p => p.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(p => p.Description)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                entity
                    .Property(p => p.Quantity)
                    .IsRequired();

                entity
                    .Property(p => p.Price)
                    .IsRequired();

                entity
                    .HasMany(p => p.Sales)
                    .WithOne(s => s.Product)
                    .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
