using AutoMapper;
using EctakoTest.WebApp.Mapping;

namespace EctakoTest.WebApp.Configuration;

public static class ConfigureMapperServices
{
    public static IServiceCollection AddMapperServices(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        return services;
    }
}