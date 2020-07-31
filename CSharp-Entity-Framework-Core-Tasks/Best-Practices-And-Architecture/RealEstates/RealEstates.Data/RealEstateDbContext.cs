using Microsoft.EntityFrameworkCore;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {

        }

        public RealEstateDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RealEstate;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>()
                .HasMany(x => x.Properties)
                .WithOne(x => x.District)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealEstatePropertyTag>()
               .HasKey(pt => new { pt.PropertyId, pt.TagId });

            //modelBuilder.Entity<RealEstatePropertyTag>()
            //   .HasOne(p => p.Property)
            //   .WithMany(p => p.Tags)
            //   .HasForeignKey(p => p.PropertyId);

            //modelBuilder.Entity<RealEstatePropertyTag>()
            //    .HasOne(t => t.Tag)
            //    .WithMany(t => t.Tags)
            //    .HasForeignKey(t => t.TagId);

        }
    }
}
