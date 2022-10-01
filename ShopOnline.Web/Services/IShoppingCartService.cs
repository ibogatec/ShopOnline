using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services;

public interface IShoppingCartService
{
    Task<IReadOnlyList<CartItemDto>> GetUserItemsAsync(int userId);

    Task<CartItemDto> AddItemAsync(CartItemDto cartItemDto);

    Task<CartItemDto> DeleteItemAsync(int itemId);
}
