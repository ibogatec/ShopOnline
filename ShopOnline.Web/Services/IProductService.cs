using ShopOnline.Web.Models.ViewModels;

namespace ShopOnline.Web.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductViewModel>> GetProductsAsync();

    Task<ProductViewModel> GetProductByIdAsync(int id);

    Task<IReadOnlyList<ProductCategoryViewModel>> GetProductCategoriesAsync();

    Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryAsync(int categoryId);

}
