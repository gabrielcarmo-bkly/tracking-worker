using Microsoft.Extensions.DependencyInjection;
using TrackingWorker.Services.Interfaces;
using TrackingWorker.Services.Implementations;
using TrackingWorker.Repositories.Interfaces;
using TrackingWorker.Repositories.Implementations;
using TrackingWorker.Common.Validators;

namespace TrackingWorker.Configuration;

/// <summary>
/// Dependency Inversion Principle: Configure dependencies here
/// Single Responsibility Principle: Only handles DI configuration
/// </summary>
public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Add controllers for Web API
        services.AddControllers();
        
        // Register repositories
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        
        // Register services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserValidator, UserValidator>();
        
        return services;
    }
}