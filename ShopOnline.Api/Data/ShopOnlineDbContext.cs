using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Models.Entities;
using System.Reflection;

namespace ShopOnline.Api.Data;

public class ShopOnlineDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Cart> Carts { get; set; } = default!;

    public DbSet<CartItem> CartItems { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<ProductCategory> ProductCategories { get; set; } = default!;

    public DbSet<User> Users { get; set; } = default!;

    public ShopOnlineDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetDbFilePath()
    {
        var dbFileName = _configuration.GetConnectionString("SQLiteDbFile");
        var dbFileLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var dbFilePath = Path.Join(dbFileLocation, dbFileName);

        return dbFilePath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={GetDbFilePath()}");
    }

}
