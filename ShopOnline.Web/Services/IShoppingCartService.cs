using ShopOnline.Web.Models.ViewModels;

namespace ShopOnline.Web.Services;

public interface IShoppingCartService
{
    Task<IReadOnlyList<CartItemViewModel>> GetUserItemsAsync(int userId);

    Task<CartItemViewModel> AddItemAsync(CartItemViewModel cartItemDto);

    Task<CartItemViewModel> DeleteItemAsync(int itemId);

    Task<CartItemViewModel> UpdateQtyAsync(int itemId, int newQty);

    event Action<int>? ShoppingCartChanged;

    void OnShopingCartChanged(int totalQty);

}
