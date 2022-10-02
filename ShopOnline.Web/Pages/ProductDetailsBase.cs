using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Models.ViewModels;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductDetailsBase : ComponentBase
{
    [Inject]
    public IProductService? ProductService { get; set; }

    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int Id { get; set; }

    public ProductViewModel? Product { get; set; }

    public string? ErrorMessage { get; set; }

    protected async Task AddToCartAsync(CartItemViewModel cartItem)
    {
        try
        {
            if (ShoppingCartService == null)
            {
                return;
            }

            var addedCartItem = await ShoppingCartService.AddItemAsync(cartItem);

            NavigationManager?.NavigateTo("/ShoppingCart");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if(ProductService == null)
            {
                return;
            }

            Product = await ProductService.GetProductByIdAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

}
