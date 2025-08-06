using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branch");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(b => b.BranchIdentifier).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Address).IsRequired().HasMaxLength(200);
        builder.Property(b => b.City).IsRequired().HasMaxLength(100);
        builder.Property(b => b.State).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Country).IsRequired().HasMaxLength(50);
        builder.Property(b => b.PostalCode).IsRequired().HasMaxLength(20);
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(15);

        builder.HasMany(b => b.Sales)
            .WithOne(s => s.Branch)
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(b => b.BranchIdentifier)
            .IsUnique()
            .HasDatabaseName("IX_Branch_BranchIdentifier");
    }
}
