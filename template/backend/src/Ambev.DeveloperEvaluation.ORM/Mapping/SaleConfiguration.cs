using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(s => s.Date).IsRequired();
        builder.Property(s => s.Total).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(s => s.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(s => s.Branch)
            .WithMany(b => b.Sales)
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Customer)
            .WithMany()
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Items)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => s.CustomerId)
            .HasDatabaseName("IX_Sale_CustomerId");

        builder.HasIndex(s => s.BranchId)
            .HasDatabaseName("IX_Sale_BranchId");

        builder.HasIndex(s => s.Date)
            .HasDatabaseName("IX_Sale_Date");
    }
}
