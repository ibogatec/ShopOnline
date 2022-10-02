using ShopOnline.Web.Models.ViewModels;
using System.Net.Http.Json;
using System.Text;

namespace ShopOnline.Web.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly HttpClient _httpClient;

    public event Action<int>? ShoppingCartChanged;

    public ShoppingCartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartItemViewModel> AddItemAsync(CartItemViewModel cartItemDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/ShoppingCart", cartItemDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new CartItemViewModel();
                }

                return await response.Content.ReadFromJsonAsync<CartItemViewModel>() ?? new CartItemViewModel();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<CartItemViewModel>> GetUserItemsAsync(int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ShoppingCart/user/{userId}");

            if (response.IsSuccessStatusCode)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<CartItemViewModel>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<CartItemViewModel>>() ?? new List<CartItemViewModel>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemViewModel> DeleteItemAsync(int itemId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{itemId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new CartItemViewModel();
                }

                return await response.Content.ReadFromJsonAsync<CartItemViewModel>() ?? new CartItemViewModel();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CartItemViewModel> UpdateQtyAsync(int itemId, int newQty)
    {
        try
        {
            var content = new StringContent(newQty.ToString(), Encoding.UTF8, "application/json-patch+json");

            var response = await _httpClient.PatchAsync($"api/ShoppingCart/{itemId}", content);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new CartItemViewModel();
                }

                return await response.Content.ReadFromJsonAsync<CartItemViewModel>() ?? new CartItemViewModel();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }

    }

    public virtual void OnShopingCartChanged(int totalQty)
    {
        ShoppingCartChanged?.Invoke(totalQty);
    }
}
