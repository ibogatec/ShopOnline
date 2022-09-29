using ShopOnline.Api.Data;

namespace ShopOnline.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddShopOnlineDataServices(this IServiceCollection services)
    {
        services.AddDbContext<ShopOnlineDbContext>();
        services.AddScoped<ShopOnlineSeeder>();
    }
}
