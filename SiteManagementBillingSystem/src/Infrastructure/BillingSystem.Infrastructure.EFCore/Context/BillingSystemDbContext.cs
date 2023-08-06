using BillingSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.EFCore;

/// Migrations = add-migration name
/// Db update = update-database
public class BillingSystemDbContext : DbContext
{
    public BillingSystemDbContext(DbContextOptions options) : base(options) { }

    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Dues> Dues { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Database table configuration applied
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
        modelBuilder.ApplyConfiguration(new DuesConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Apartment>().HasData(
        new Apartment { Id = 1, Block = "A", Floor = 1, Number = 1, Type = "2+1", Resident = 1, Status = 1, CreatedDate = DateTime.UtcNow , UpdatedDate = DateTime.UtcNow },
        new Apartment { Id = 2, Block = "A", Floor = 1, Number = 2, Type = "2+1", Resident = 2, Status = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Apartment { Id = 3, Block = "A", Floor = 2, Number = 3, Type = "3+1", Resident = 1, Status = 0, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Apartment { Id = 4, Block = "A", Floor = 2, Number = 4, Type = "3+1", Resident = 1, Status = 0, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Apartment { Id = 5, Block = "A", Floor = 3, Number = 5, Type = "3+1", Resident = 1, Status = 0, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Apartment { Id = 6, Block = "A", Floor = 3, Number = 6, Type = "3+1", Resident = 1, Status = 0, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

        modelBuilder.Entity<User>().HasData(
        new User { Id = 1, FirstName = "Admin", LastName = "Admin", TCKNumber = "11111111111", Email = "admin@gmail.com", Password = "admin", Phone = "0567 456 43 43", Role = "Admin", ApartmentId = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new User { Id = 2, FirstName = "Nisa", LastName = "Turhan", TCKNumber = "22222222222", Email = "nisa@gmail.com", Password = "123456", Phone = "0567 456 43 43", Role = "User", ApartmentId = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new User { Id = 3, FirstName = "Doğa", LastName = "Turhan", TCKNumber = "33333333333", Email = "doga@gmail.com", Password = "123456", Phone = "0567 456 43 43", Role = "User", ApartmentId = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

        modelBuilder.Entity<Dues>().HasData(
        new Dues { Id = 1, Month = "July", Year = 2023, Amounth = 200, DuesPaymentStatus = 0, ApartmentId = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Dues { Id = 2, Month = "July", Year = 2023, Amounth = 200, DuesPaymentStatus = 0, ApartmentId = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Dues { Id = 3, Month = "July", Year = 2023, Amounth = 200, DuesPaymentStatus = 0, ApartmentId = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

        modelBuilder.Entity<Invoice>().HasData(
        new Invoice { Id = 1, Month = "July", Year = 2023, Amounth = 200, InvoiceType = 1, InvoicePaymentStatus = 0, ApartmentId = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Invoice { Id = 2, Month = "July", Year = 2023, Amounth = 200, InvoiceType = 2, InvoicePaymentStatus = 0, ApartmentId = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
        new Invoice { Id = 3, Month = "July", Year = 2023, Amounth = 200, InvoiceType = 3, InvoicePaymentStatus = 0, ApartmentId = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
        );

    }
}
