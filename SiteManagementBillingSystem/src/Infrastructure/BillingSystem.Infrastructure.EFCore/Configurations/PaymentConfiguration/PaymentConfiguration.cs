using BillingSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingSystem.Infrastructure.EFCore;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Id).IsUnique(true);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Date).IsRequired(true).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).HasDefaultValue(DateTime.UtcNow);
        builder.Property(e => e.PaymentType).IsRequired(true);
        builder.Property(e => e.Amount).IsRequired(true);

        builder.HasOne(e => e.User)
               .WithMany(e => e.Payments)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Invoice)
            .WithOne(e => e.Payment)
            .HasForeignKey<Invoice>(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Dues)
            .WithOne(e => e.Payment)
            .HasForeignKey<Dues>(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
