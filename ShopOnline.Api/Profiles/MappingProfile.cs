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
			.ReverseMap();
	}

}
