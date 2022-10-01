using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IList<CartItemDto>? ShoppingCartItems { get; set; }

    public string? ErrorMessage { get; set; }

	protected async Task DeleteItemAsync(int itemId)
	{
		try
		{
			if (ShoppingCartService == null)
			{
				return;
			}

			var deletedItem = await ShoppingCartService.DeleteItemAsync(itemId);

			var itemToRemove = ShoppingCartItems?.First(i => i.Id == deletedItem.Id);
			
			if (itemToRemove != null)
			{
				ShoppingCartItems?.Remove(itemToRemove);
			}

		}
		catch (Exception)
		{

			throw;
		}
	}

    protected override async Task OnInitializedAsync()
    {
		try
		{
			if (ShoppingCartService == null)
			{
				return;
			}

			ShoppingCartItems = (await ShoppingCartService.GetUserItemsAsync(1)).ToList();
		}
		catch (Exception ex)
		{
            ErrorMessage = ex.Message;
		}
    }
}
