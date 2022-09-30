using AutoMapper;
using ShopOnline.Api.Models.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Product, ProductDto>()
			.ReverseMap();

		CreateMap<CartItem, CartItemDto>()
			.ReverseMap();
	}

}
