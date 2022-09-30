namespace ShopOnline.Models.Dtos;

public class CartItemDto
{
    public int Id { get; set; }

    public int Qty { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string ProductDescription { get; set; } = string.Empty;

    public string ProductImageURL { get; set; } = string.Empty;

    public decimal ProductPrice { get; set; }

    public decimal TotalPrice { get; set; }
}
