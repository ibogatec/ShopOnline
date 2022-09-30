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
}
