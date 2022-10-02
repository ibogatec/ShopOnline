using Microsoft.AspNetCore.Components;
using ShopOnline.Web.Models.ViewModels;

namespace ShopOnline.Web.Pages;

public class DisplayProductsBase : ComponentBase
{
    [Parameter]
    public IReadOnlyList<ProductViewModel>? Products { get; set; }
}
