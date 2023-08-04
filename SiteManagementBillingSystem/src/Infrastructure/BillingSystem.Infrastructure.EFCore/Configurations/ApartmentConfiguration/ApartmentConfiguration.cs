using BillingSystem.Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Domain.Entities.ApartmentEntity;

namespace BillingSystem.Infrastructure.EFCore.Configurations.ApartmentConfiguration;

// Apartment table definition
public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Id).IsUnique(true);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.UpdatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.Property(e => e.Block).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Floor).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Number).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Type).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Resident).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Status).IsRequired(true).HasMaxLength(50);
    }
}