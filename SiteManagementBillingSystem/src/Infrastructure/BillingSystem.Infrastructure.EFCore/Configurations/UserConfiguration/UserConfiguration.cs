using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Domain.Entities.UserEntity;

namespace BillingSystem.Infrastructure.EFCore.Configurations.UserConfiguration;

// User table definition
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Id).IsUnique(true);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.UpdatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.Property(e => e.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.TCKNumber).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Password).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Phone).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.CarPlateNumber).IsRequired(false).HasMaxLength(50);
        builder.Property(e => e.Role).IsRequired(true).HasMaxLength(50);

        builder.HasOne(e => e.Apartment)
               .WithMany(e => e.Users)
               .HasForeignKey(e => e.ApartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}