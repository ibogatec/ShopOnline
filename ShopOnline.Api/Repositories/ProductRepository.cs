using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories;

public class ProductRepository
{
	private readonly IMapper _mapper;
	private readonly ShopOnlineDbContext _dbContext;

	public ProductRepository(
		IMapper mapper,
		ShopOnlineDbContext dbContext)
	{
		_mapper = mapper;
		_dbContext = dbContext;
	}

	public async Task<IReadOnlyList<ProductDto>> GetAllAsync()
	{
		var products = await _dbContext.Products.Include(p => p.ProductCategory).ToListAsync();

		return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

	public async Task<ProductDto> GetByIdAsync(int id)
	{
		var product =  await _dbContext.Products.Include(p => p.ProductCategory).FirstAsync(p => p.Id == id);

		return _mapper.Map<ProductDto>(product);
	}

	public async Task<IReadOnlyList<ProductCategoryDto>> GetAllProductCategoriesAsync()
	{
		var categories = await _dbContext.ProductCategories.ToListAsync();

		return _mapper.Map<IReadOnlyList<ProductCategoryDto>>(categories);
	}

    public async Task<IReadOnlyList<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
		var products = await _dbContext.Products.Include(p => p.ProductCategory).Where(p => p.ProductCategoryId == categoryId).ToListAsync();
		
		return _mapper.Map<IReadOnlyList<ProductDto>>(products);
	}
}
