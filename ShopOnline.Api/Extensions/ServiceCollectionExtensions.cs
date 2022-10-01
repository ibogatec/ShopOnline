using ShopOnline.Api.Data;
using ShopOnline.Api.Repositories;
using System.Reflection;

namespace ShopOnline.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddShopOnlineDataServices(this IServiceCollection services)
    {
        services.AddDbContext<ShopOnlineDbContext>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<ShoppingCartRepository>();
        services.AddScoped<ShopOnlineSeeder>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
