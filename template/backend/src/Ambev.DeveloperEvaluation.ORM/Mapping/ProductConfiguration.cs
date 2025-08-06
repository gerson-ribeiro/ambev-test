using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(p => p.Identification).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.OriginalPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Active).IsRequired().HasDefaultValue(true);
        builder.Property(p => p.Sku).IsRequired().HasMaxLength(50);
        builder.Property(p => p.BarCode).IsRequired().HasMaxLength(250);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.SaleItems)
            .WithOne(si => si.Items)
            .HasForeignKey(si => si.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Promotions)
            .WithMany();

        builder.HasIndex(p => p.BarCode)
            .IsUnique()
            .HasDatabaseName("IX_Product_BarCode");

        builder.HasIndex(p => p.Sku)
            .IsUnique()
            .HasDatabaseName("IX_Product_Sku");

    }
}
