using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Models.Dtos;
using ShopOnline.Api.Repositories;

namespace ShopOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
	private readonly ShoppingCartRepository _shoppingCartRepo;

	public ShoppingCartController(ShoppingCartRepository shoppingCartRepo)
	{
		_shoppingCartRepo = shoppingCartRepo;
	}

    [HttpGet]
    [Route("{itemId:int}")]
    public async Task<ActionResult<IReadOnlyList<CartItemDto>>> GetItemAsync(int itemId)
    {
        try
        {
            var cartItem = await _shoppingCartRepo.GetItemAsync(itemId);
            if (cartItem == null)
            {
                return NotFound($"Cart item with id '{itemId}' was not found");
            }

            return Ok(cartItem);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("user/{userId:int}")]
    public async Task<ActionResult<IReadOnlyList<CartItemDto>>> GetUserItemsAsync(int userId)
    {
        try
        {
            var cartItems = await _shoppingCartRepo.GetItemsAsync(userId);
            if (cartItems == null || cartItems.Count <= 0)
            {
                return NoContent();
            }

            return Ok(cartItems);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CartItemDto>> PostItemAsync([FromBody] CartItemDto cartItem)
    {
        try
        {
            var item = await _shoppingCartRepo.AddItemAsync(cartItem);
            if (item != null)
            {
                return CreatedAtAction(nameof(GetItemAsync), new { itemId = item.Id }, item);
            }

            return BadRequest(cartItem);
        }
        catch (Exception ex)
        {
            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }
    }

    [HttpDelete("{itemId:int}")]
    public async Task<ActionResult<CartItemDto>> DeleteItemAsync(int itemId)
    {
        try
        {
            var deletedItem = await _shoppingCartRepo.DeleteItemAsync(itemId);
            if (deletedItem == null)
            {
                return NotFound($"Item with id '{itemId}' was not found.");
            }

            return Ok(deletedItem);
        }
        catch (Exception ex)
        {
            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }
    }

    [HttpPatch("{itemId:int}")]
    public async Task<ActionResult<CartItemDto>> UpdateQtyAsync(int itemId, [FromBody] int newQty)
    {
        try
        {
            var updatedItem = await _shoppingCartRepo.UpdateItemQtyAsync(itemId, newQty);

            if (updatedItem == null)
            {
                return NotFound($"Item with id '{itemId}' was not found.");
            }

            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

    }
}
