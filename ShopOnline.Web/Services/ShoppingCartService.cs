using ShopOnline.Models.Dtos;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly HttpClient _httpClient;

    public ShoppingCartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartItemDto> AddItemAsync(CartItemDto cartItemDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/ShoppingCart", cartItemDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new CartItemDto();
                }

                return await response.Content.ReadFromJsonAsync<CartItemDto>() ?? new CartItemDto();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<CartItemDto>> GetUserItemsAsync(int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ShoppingCart/user/{userId}");

            if (response.IsSuccessStatusCode)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<CartItemDto>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<CartItemDto>>() ?? new List<CartItemDto>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemDto> DeleteItemAsync(int itemId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{itemId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new CartItemDto();
                }

                return await response.Content.ReadFromJsonAsync<CartItemDto>() ?? new CartItemDto();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
