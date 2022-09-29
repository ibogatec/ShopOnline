using ShopOnline.Api.Data;

namespace ShopOnline.Api.Extensions;

public static class ServiceProviderExtensions
{
    public static void SeedData(this IServiceProvider serviceProvider, bool seedData)
    {
        using var scope = serviceProvider.CreateScope();

        var services = scope.ServiceProvider;

        var seeder = services.GetRequiredService<ShopOnlineSeeder>();
        seeder.SeedInitialData(seedData);
    }
}
