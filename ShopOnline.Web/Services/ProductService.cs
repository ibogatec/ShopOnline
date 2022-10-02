using ShopOnline.Models.Dtos;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductDto>>("api/products") ?? new List<ProductDto>();

            return products;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new ProductDto();
                }

                return await response.Content.ReadFromJsonAsync<ProductDto>() ?? new ProductDto();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<ProductCategoryDto>> GetProductCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/categories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<ProductCategoryDto>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<ProductCategoryDto>>() ?? new List<ProductCategoryDto>();
            }

            var message = await response.Content.ReadAsStringAsync();
            throw new Exception($"Http status: {response.StatusCode}, Message: {message}");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IReadOnlyList<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/categories/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new List<ProductDto>();
                }

                return await response.Content.ReadFromJsonAsync<IReadOnlyList<ProductDto>>() ?? new List<ProductDto>();
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
