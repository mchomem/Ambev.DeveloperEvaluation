using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

        builder.OwnsOne(u => u.Name, name =>
        {
            name.Property(n => n.FirstName).IsRequired().HasMaxLength(50).HasColumnName("FirstName");
            name.Property(n => n.LastName).IsRequired().HasMaxLength(50).HasColumnName("LastName");
        });

        builder.Property(u => u.Phone).HasMaxLength(20);
        builder.Property(u => u.Status).HasConversion<string>().HasMaxLength(20);
        builder.Property(u => u.Role).HasConversion<string>().HasMaxLength(20);
        builder.Property(u => u.CreatedAt).IsRequired().HasColumnType("timestamptz");
        builder.Property(u => u.UpdatedAt).IsRequired(false).HasColumnType("timestamptz");

        #region Foreign key to table.

        builder
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.Id)
            .HasConstraintName("FK_User_Address_Id")
            .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}
