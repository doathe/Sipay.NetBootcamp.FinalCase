using BillingSystem.Infrastructure.EFCore.Context;
using BillingSystem.Infrastructure.EFCore.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Infrastructure.EFCore;

public static class DependencyInjection
{
    public static void AddEFCoreDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuration Options for db
        var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string is null or empty.");
        }
        // Database Dependency Injection
        services.AddDbContext<BillingSystemDbContext>(option => option.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
