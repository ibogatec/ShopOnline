using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Models.ViewModels;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductsByCategoryBase : ComponentBase
{

    [Inject]
    public IProductService? ProductService { get; set; }

    [Parameter]
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public IReadOnlyList<ProductViewModel>? Products { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            if (ProductService == null)
            {
                return;
            }

            Products = await ProductService.GetProductsByCategoryAsync(CategoryId);

            if(Products == null || Products.Count <= 0)
            {
                return;
            }

            CategoryName = Products.FirstOrDefault()?.ProductCategoryName;

        }
        catch (Exception ex)
        {
            ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
    }

}
