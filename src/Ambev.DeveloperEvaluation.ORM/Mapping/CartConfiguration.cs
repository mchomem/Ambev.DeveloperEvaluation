using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.UserId).IsRequired().HasColumnType("uuid");
        builder
            .Property(c => c.SaleNumber) // Nota: em um cenário real, o número da venda é controlado por um gerenciador de sequência de documentos fiscais.
            .IsRequired()
            .HasColumnType("integer")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(c => c.Date).IsRequired().HasColumnType("timestamptz");
        builder.Property(c => c.TotalSale).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(c => c.TotalSaleDiscount).IsRequired().HasColumnType("decimal(18,2)");

        #region Relationships

        builder
            .HasOne(c => c.User)
            .WithMany(u => u.Carts)
            .HasForeignKey(c => c.UserId)
            .HasConstraintName("FK_Carts_Users_UserId")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
