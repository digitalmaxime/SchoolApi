using Application.MappingProfiles;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Application.Configuration;

public static class ApplicationConfigureServiceCollectionExtension
{
    public static IServiceCollection ConfigureApplicationService(
        this IServiceCollection services,
        IConfiguration config)
    {
         services.AddScoped<IStudentService, StudentService>();
         
         services.AddAutoMapper(typeof(StudentMappingProfile));

         return services;
    }
}
