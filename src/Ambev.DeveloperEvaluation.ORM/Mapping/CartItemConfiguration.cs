using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");
        builder.HasKey(ci => ci.Id);
        
        builder.Property(ci => ci.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(ci => ci.CartId).IsRequired().HasColumnType("uuid");
        builder.Property(ci => ci.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(ci => ci.Quantity).IsRequired().HasColumnType("integer");
        builder.Property(ci => ci.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

        #region Relationships

        builder
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItens)
            .HasForeignKey(ci => ci.CartId)
            .HasConstraintName("FK_CartItens_Carts_CartId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(ci => ci.Product)
            .WithMany(p => p.CartItens)
            .HasForeignKey(ci => ci.ProductId)
            .HasConstraintName("FK_CartItens_Products_ProductId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
