using BillingSystem.Application.Token;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BillingSystem.Application;

public static class DependencyInjection
{
    public static void AddApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IApartmentService, ApartmentService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}
