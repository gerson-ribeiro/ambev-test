using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.ToTable("Promotion");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(p => p.Identification).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Percent).IsRequired().HasColumnType("decimal(5,2)");
        builder.Property(p => p.MaxUnit).IsRequired(false);
        builder.Property(p => p.MinUnit).IsRequired();
        builder.Property(p => p.ExpirationDate).IsRequired(false);

        builder.HasIndex(p => p.Identification)
            .IsUnique()
            .HasDatabaseName("IX_Promotion_Identification");

        builder.HasIndex(p => p.ExpirationDate)
            .HasDatabaseName("IX_Promotion_ExpirationDate");
    }
}
