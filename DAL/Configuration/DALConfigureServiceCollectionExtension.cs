using Contacts.RepositoryInterfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configuration;

public static class DALConfigureServiceCollectionExtension
{
    public static IServiceCollection ConfigureInfrastructureService(
        this IServiceCollection services,
        IConfiguration config)
    {
        return services
            .ConfigureDatabaseSetup(config)
            .AddScoped<ISchoolRepository, SchoolRepository>();
    }

    private static IServiceCollection ConfigureDatabaseSetup(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<SchoolContext>(options =>
        {
            options.UseMySQL(config.GetConnectionString("DefaultConnection"));
        }); 
        
        return services;
    } 
}