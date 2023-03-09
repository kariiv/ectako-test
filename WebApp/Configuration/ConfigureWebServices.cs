using Microsoft.OpenApi.Models;

namespace EctakoTest.WebApp.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        
        services.AddControllers(options =>
        {
            options.UseNamespaceRouteToken();
        });
        
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ectako Test", Version = "v1" });
        });
        
        return services;
    }
}