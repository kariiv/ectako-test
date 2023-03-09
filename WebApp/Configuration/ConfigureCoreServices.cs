using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;
using EctakoTest.Core.Services;
using EctakoTest.Infrastructure.Data;
using EctakoTest.Infrastructure.Logging;

namespace EctakoTest.WebApp.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IProductGroupService, ProductGroupService>();

        return services;
    }
}