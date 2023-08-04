using BillingSystem.Domain.Entities.ApartmentEntity;
using BillingSystem.Domain.Entities.UserEntity;
using BillingSystem.Infrastructure.EFCore.Configurations.ApartmentConfiguration;
using BillingSystem.Infrastructure.EFCore.Configurations.UserConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.EFCore.Context;

/// Migrations = add-migration name
/// Db update = update-database
public class BillingSystemDbContext : DbContext
{
    public BillingSystemDbContext(DbContextOptions options) : base(options) { }

    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Apartment> Apartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Database table configuration applied
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ApartmentConfiguration());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Apartment>().HasData(
        new Apartment { Id = 1, Block = "A", Floor = 2, Number = 4, Type = "3+1", Resident = 1, Status = 1 },
        new Apartment { Id = 2, Block = "B", Floor = 3, Number = 6, Type = "2+1", Resident = 2, Status = 1 },
        new Apartment { Id = 3, Block = "C", Floor = 4, Number = 8, Type = "3+1", Resident = 1, Status = 0 }
        );

        modelBuilder.Entity<User>().HasData(
        new User { Id = 1, FirstName = "Nisa Doğa", LastName = "Turhan", TCKNumber = "11111111111", Email = "nisatur@gmail.com", Password = "123456", Phone = "0567 456 43 43", Role = "User", ApartmentId = 1 },
        new User { Id = 2, FirstName = "Nisa", LastName = "Turhan", TCKNumber = "22222222222", Email = "nisa@gmail.com", Password = "123456", Phone = "0567 456 43 43", Role = "User", ApartmentId = 2 },
        new User { Id = 3, FirstName = "Doğa", LastName = "Turhan", TCKNumber = "33333333333", Email = "doga@gmail.com", Password = "123456", Phone = "0567 456 43 43", Role = "User", ApartmentId = 1 }
        );

    }
}
