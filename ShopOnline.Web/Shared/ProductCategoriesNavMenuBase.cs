using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Models.ViewModels;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Shared;

public class ProductCategoriesNavMenuBase : ComponentBase
{
    [Inject]
    public IProductService? ProductService { get; set; }

    public IReadOnlyList<ProductCategoryViewModel>? ProductCategories { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (ProductService == null)
            {
                return;
            }

            ProductCategories = await ProductService.GetProductCategoriesAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
    }
}
