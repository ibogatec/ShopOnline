using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Web.Models.ViewModels;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ShoppingCartBase : ComponentBase
{
	[Inject]
	public IJSRuntime? JSRuntime { get; set; }

    [Inject]
    public IShoppingCartService? ShoppingCartService { get; set; }

    public IList<CartItemViewModel>? ShoppingCartItems { get; set; }

	public string? TotalPrice { get; set; }

	public int TotalQuantity { get; set; }

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

				UpdateTotalPriceAndQuantity();
			}

		}
		catch (Exception)
		{
			throw;
		}
	}

	protected async Task ChangeQty(int itemId)
	{
		if (JSRuntime == null)
		{
			return;
		}

		await JSRuntime.InvokeVoidAsync("makeUpdateQtyButtonVisible", itemId, true);
	}

	protected async Task UpdateQtyAsync(int itemId, int qty)
	{
		try
		{
			if (ShoppingCartService == null)
			{
				return;
			}

			var updatedItem = await ShoppingCartService.UpdateQtyAsync(itemId, qty);

			UpdateTotalPriceAndQuantity();

            if (JSRuntime == null)
            {
                return;
            }

            await JSRuntime.InvokeVoidAsync("makeUpdateQtyButtonVisible", itemId, false);
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

			UpdateTotalPriceAndQuantity();

		}
		catch (Exception ex)
		{
            ErrorMessage = ex.Message;
		}
    }

	private void UpdateTotalPriceAndQuantity()
	{
        TotalPrice = ShoppingCartItems != null ? ShoppingCartItems.Sum(i => i.ProductPrice * i.Qty).ToString("C") : $"{0.0:C}";

        TotalQuantity = ShoppingCartItems != null ? ShoppingCartItems.Sum(i => i.Qty) : 0;

		ShoppingCartService?.OnShopingCartChanged(TotalQuantity);
    }
}
