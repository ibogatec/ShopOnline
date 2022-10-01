using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IReadOnlyList<CartItemDto>? ShoppingCartItems { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
		try
		{
			if (ShoppingCartService == null)
			{
				return;
			}

			ShoppingCartItems = await ShoppingCartService.GetUserItemsAsync(1);
		}
		catch (Exception ex)
		{
            ErrorMessage = ex.Message;
		}
    }
}
