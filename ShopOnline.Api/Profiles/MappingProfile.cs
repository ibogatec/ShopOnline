using AutoMapper;
using ShopOnline.Api.Models.Dtos;
using ShopOnline.Api.Models.Entities;

namespace ShopOnline.Api.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Product, ProductDto>()
			.ReverseMap();

		CreateMap<CartItem, CartItemDto>()
			.ForMember(m => m.TotalPrice, conf => conf.MapFrom(m => m.Qty * (m.Product != null ? m.Product.Price : 0)))
			.ReverseMap();

		CreateMap<ProductCategory, ProductCategoryDto>()
			.ReverseMap();
	}

}
