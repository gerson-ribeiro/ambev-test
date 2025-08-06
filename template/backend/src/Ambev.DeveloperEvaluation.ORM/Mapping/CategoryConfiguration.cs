using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public  class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.Identification).IsRequired().HasMaxLength(100);
        builder.Property(c => c.DisplayName).IsRequired().HasMaxLength(100);

        builder.HasIndex(c => c.Identification)
            .IsUnique()
            .HasDatabaseName("IX_Category_Identification");

        builder.HasMany(c => c.Promotions)
            .WithMany();
    }
}
