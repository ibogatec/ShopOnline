using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Repositories;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly ProductRepository _productRepo;

	public ProductsController(
		IMapper mapper,
		ProductRepository productRepo)
	{
		_mapper = mapper;
		_productRepo = productRepo;
	}

	[HttpGet]
	public async Task<ActionResult<IReadOnlyList<ProductDto>>> Get()
	{
		try
		{
			var products = await _productRepo.GetAllAsync();
			if (products == null)
			{
				return NotFound("Products are not found");
			}

			return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ProductDto>> GetById(int id)
	{
		try
		{
			var product = await _productRepo.GetById(id);
			if(product == null)
			{
				return NotFound($"Product with id '{id}' was not found");
			}

			return Ok(_mapper.Map<ProductDto>(product));
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

}
