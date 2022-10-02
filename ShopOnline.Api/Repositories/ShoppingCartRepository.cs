using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models.Dtos;
using ShopOnline.Api.Models.Entities;

namespace ShopOnline.Api.Repositories;

public class ShoppingCartRepository
{
    private readonly IMapper _mapper;
    private readonly ShopOnlineDbContext _dbContext;

    public ShoppingCartRepository(
        IMapper mapper,
        ShopOnlineDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<CartItemDto> AddItemAsync(CartItemDto cartItemDto)
    {
        var product = await _dbContext.Products.FindAsync(cartItemDto.ProductId);
        if (product == null)
        {
            throw new Exception($"Something went wrong when attempting to retrieve product (productId:{cartItemDto.ProductId})");
        }

        var cartItem = _mapper.Map<CartItem>(cartItemDto);
        cartItem.ProductId = cartItemDto.ProductId;
        cartItem.Product = product;

        await _dbContext.CartItems.AddAsync(cartItem);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CartItemDto>(cartItem);
    }

    public async Task<CartItemDto> UpdateItemQtyAsync(int id, int newQty)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(id);

        if (cartItem != null)
        {
            cartItem.Qty = newQty;
            await _dbContext.SaveChangesAsync();
        }

        return _mapper.Map<CartItemDto>(cartItem);
    }

    public async Task<CartItemDto> DeleteItemAsync(int id)
    {
        var cartItem = await _dbContext.CartItems.Include(i => i.Product).FirstAsync(i => i.Id == id);

        if (cartItem != null)
        {
            _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
        }

        return _mapper.Map<CartItemDto>(cartItem);
    }

    public async Task<CartItemDto> GetItemAsync(int id)
    {
        var cartItem = await _dbContext.CartItems.FirstAsync(i => i.Id == id);

        return _mapper.Map<CartItemDto>(cartItem);
    }

    public async Task<IReadOnlyList<CartItemDto>> GetItemsAsync(int userId)
    {
        var items = await _dbContext.CartItems.Include(i => i.Product)
                                              .Include(i => i.Cart)
                                              .ThenInclude(i => i!.User)
                                              .Where(i => i.Cart != null && i.Cart.UserId == userId)
                                              .ToListAsync();

        return _mapper.Map<IReadOnlyList<CartItemDto>>(items);
    }

}
