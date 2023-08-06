using BillingSystem.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.EFCore;

// Invoice table definitions
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Id).IsUnique(true);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.UpdatedDate).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.Property(e => e.Month).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Year).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Amounth).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.InvoiceType).IsRequired(true);
        builder.Property(e => e.InvoicePaymentStatus).IsRequired(true).HasDefaultValue(0);

        builder.HasOne(e => e.Apartment)
               .WithMany(e => e.Invoices)
               .HasForeignKey(e => e.ApartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}