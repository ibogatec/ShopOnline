using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models.Entities;

namespace ShopOnline.Api.Repositories;

public class ProductRepository
{
	private readonly ShopOnlineDbContext _dbContext;

	public ProductRepository(ShopOnlineDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IReadOnlyList<Product>> GetAllAsync()
	{
		return await _dbContext.Products.Include(p => p.ProductCategory).ToListAsync();
    }
}
