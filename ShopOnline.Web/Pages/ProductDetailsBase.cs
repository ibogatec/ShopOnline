using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;

namespace ShopOnline.Web.Pages;

public class ProductDetailsBase : ComponentBase
{
    [Inject]
    public IProductService? ProductService { get; set; }

    [Parameter]
    public int Id { get; set; }

    public ProductDto? Product { get; set; }

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            if(ProductService == null)
            {
                return;
            }

            Product = await ProductService.GetProductById(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

}
