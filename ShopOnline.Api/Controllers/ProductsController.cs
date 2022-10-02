using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Repositories;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly ProductRepository _productRepo;

	public ProductsController(ProductRepository productRepo)
	{
		_productRepo = productRepo;
	}

	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProductsAsync()
	{
		try
		{
			var products = await _productRepo.GetAllAsync();
			if (products == null)
			{
				return NotFound("Products are not found");
			}

			return Ok(products);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("{productId:int}")]
	public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int productId)
	{
		try
		{
			var product = await _productRepo.GetByIdAsync(productId);
			if(product == null)
			{
				return NotFound($"Product with id '{productId}' was not found");
			}

			return Ok(product);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("categories")]
	public async Task<ActionResult<IReadOnlyList<ProductCategoryDto>>> GetProductCategories()
	{
		try
		{
			var categories = await _productRepo.GetAllProductCategoriesAsync();

			if (categories == null)
			{
				return NotFound("Product Categories are not found.");
			}

			return Ok(categories);

		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}
}
