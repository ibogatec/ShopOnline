﻿namespace ShopOnline.Web.Models.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageURL { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = string.Empty;

}
