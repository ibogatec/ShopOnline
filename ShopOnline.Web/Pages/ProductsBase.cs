using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Models.ViewModels;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductsBase : ComponentBase
{

    [Inject]
    public IProductService? ProductService { get; set; }

    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IReadOnlyList<ProductViewModel>? Products { get; set; }

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

    protected IOrderedEnumerable<IGrouping<string, ProductViewModel>>? GetProductsGroupedByCategory()
    {
        return Products?.GroupBy(p => p.ProductCategoryName).OrderBy(p => p.Key);
    }
}
