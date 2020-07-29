using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data.Configurations
{
    public class ProductEntityConfiguration
        : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasAlternateKey(p => p.Name);

            builder
                 .Property(p => p.Name)
                 .HasMaxLength(50)
                 .IsUnicode(true);
        }
    }
}
