using EctakoTest.Infrastructure.Data;

namespace EctakoTest.WebApp.Extensions;

public static class AppDbContextBuilderExtension
{
    public static async Task<IHost> UseDbSeed(this IHost app, bool migrate = false)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = services.GetRequiredService<AppDbContext>();
                await new AppDbContextSeed(dbContext, loggerFactory).SeedAsync(migrate);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }
        
        return app;
    }
}