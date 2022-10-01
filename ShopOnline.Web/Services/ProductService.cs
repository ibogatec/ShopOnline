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

    public async Task<IReadOnlyList<ProductDto>> GetProducts()
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

    public async Task<ProductDto> GetProductById(int id)
    {
        try
        {
            var respnse = await _httpClient.GetAsync($"api/products/{id}");

            if (respnse.IsSuccessStatusCode)
            {
                return await respnse.Content.ReadFromJsonAsync<ProductDto>() ?? new ProductDto();
            }
            else
            {
                var message = await respnse.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
