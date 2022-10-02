using ShopOnline.Web.Models.ViewModels;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ProductViewModel>> GetProductsAsync()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductViewModel>>("api/products") ?? new List<ProductViewModel>();

            return products;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new ProductViewModel();
                }

                return await response.Content.ReadFromJsonAsync<ProductViewModel>() ?? new ProductViewModel();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<ProductCategoryViewModel>> GetProductCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/categories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<ProductCategoryViewModel>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<ProductCategoryViewModel>>() ?? new List<ProductCategoryViewModel>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<ProductViewModel>> GetProductsByCategoryAsync(int categoryId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/categories/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<ProductViewModel>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<ProductViewModel>>() ?? new List<ProductViewModel>();
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
