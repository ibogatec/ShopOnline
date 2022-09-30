using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductsBase : ComponentBase
{

    [Inject]
    public IProductService? ProductService { get; set; }

    public IReadOnlyList<ProductDto>? Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (ProductService == null)
        {
            return;
        }

        Products = await ProductService.GetProducts() ?? new List<ProductDto>();
    }

    protected IOrderedEnumerable<IGrouping<string, ProductDto>>? GetProductsGroupedByCategory()
    {
        return Products?.GroupBy(p => p.ProductCategoryName).OrderBy(p => p.Key);
    }
}
