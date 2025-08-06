using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItem");
        builder.HasKey(si => si.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(si => si.Quantity).IsRequired();
        builder.Property(si => si.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.Discount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.DiscountedPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.Status).IsRequired();

        builder.HasOne(si => si.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(si => si.Items)
            .WithMany()
            .HasForeignKey(si => si.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(si => si.SaleId)
            .HasDatabaseName("IX_SaleItem_SaleId");

        builder.HasIndex(si => si.ProductId)
            .HasDatabaseName("IX_SaleItem_ItemsId");

        builder.HasIndex(si => si.Status)
            .HasDatabaseName("IX_SaleItem_Status");

        builder.Property(si => si.Status)
            .HasConversion(
                v => v.ToString(),
                v => (SaleItemStatus) Enum.Parse(typeof(SaleItemStatus), v))
            .IsRequired();

    }
}
