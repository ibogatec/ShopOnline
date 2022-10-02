using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetProductsAsync();

    Task<ProductDto> GetProductByIdAsync(int id);

    Task<IReadOnlyList<ProductCategoryDto>> GetProductCategoriesAsync();
}
