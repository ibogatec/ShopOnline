using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class CheckoutBase : ComponentBase
{
    [Inject]
    public IJSRuntime? Js { get; set; }

    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IReadOnlyList<CartItemDto>? CartItems { get; set; }

    public int TotalQty { get; set; }

    public string? PaymentDescription { get; set; }

    public decimal PaymentAmount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (ShoppingCartService == null)
            {
                return;
            }

            CartItems = await ShoppingCartService.GetUserItemsAsync(1);

            if (CartItems == null)
            {
                return;
            }

            var orderGuid = Guid.NewGuid();

            PaymentAmount = CartItems.Sum(i => i.ProductPrice * i.Qty);
            TotalQty = CartItems.Sum(i => i.Qty);
            PaymentDescription = $"O_1_{orderGuid}";
        }
        catch (Exception)
        {
            // Log Exception
            throw;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (Js != null && firstRender)
            {
                await Js.InvokeVoidAsync("initPayPalButton");
            }
        }
        catch (Exception)
        {
            throw;
        }

    }

}
