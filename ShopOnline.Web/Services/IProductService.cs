using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetProducts();
}
