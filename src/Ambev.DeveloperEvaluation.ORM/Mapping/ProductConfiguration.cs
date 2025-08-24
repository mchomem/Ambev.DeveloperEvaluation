﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
        builder.Property(p => p.Category).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Image).IsRequired().HasColumnType("text");

        builder.OwnsOne(p => p.Rating, rating =>
        {
            rating.Property(r => r.Rate).IsRequired().HasColumnName("RatingRate").HasColumnType("decimal(3,2)");
            rating.Property(r => r.Count).IsRequired().HasColumnName("RatingCount").HasColumnType("integer");
        });

        builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("timestamptz");
        builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("timestamptz");
    }
}
