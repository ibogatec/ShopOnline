using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductsBase : ComponentBase
{

    [Inject]
    public IProductService? ProductService { get; set; }

    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IReadOnlyList<ProductDto>? Products { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (ProductService == null)
            {
                return;
            }

            Products = await ProductService.GetProductsAsync();

            if(ShoppingCartService == null)
            {
                return;
            }

            var totalQty = (await ShoppingCartService.GetUserItemsAsync(1)).Sum(i => i.Qty);
            ShoppingCartService.OnShopingCartChanged(totalQty);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
    }

    protected IOrderedEnumerable<IGrouping<string, ProductDto>>? GetProductsGroupedByCategory()
    {
        return Products?.GroupBy(p => p.ProductCategoryName).OrderBy(p => p.Key);
    }
}
