using Microsoft.AspNetCore.Mvc;
using ShoppingCartBeService.DataModel;
using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly ILogger<ShoppingCartController> logger; 

        public ShoppingCartController(ICartService _cartService, ILogger<ShoppingCartController> _logger)
        {
            cartService = _cartService;
            logger = _logger;
        }

        /// <summary>
        /// Adds an item to the shopping cart.
        /// </summary>
        /// <param name="item">The item to add to the cart.</param>
        /// <returns>Response indicating the addition of item to the cart</returns>
        [HttpPost("item")]
        public IActionResult AddItem([FromBody] CartItem item)
        {
            if (item == null)
            {
                logger.LogWarning("Attempted to add a null item to the cart.");
                return BadRequest("Item cannot be null.");
            }

            try
            {
                cartService.AddItem(item);
                logger.LogInformation("Item added to the cart: {ItemName}", item.Name);
                return Ok(new { message = "Item added successfully.", item });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while adding item to the cart.");
                return StatusCode(500, "An error occurred while adding the item to the cart.");
            }
        }

        /// <summary>
        /// Retrieves all items in the shopping cart.
        /// </summary>
        /// <returns> Response containing the list of cart items.</returns>

        [HttpGet("items")]
        public ActionResult<IEnumerable<ICartItem>> GetItems()
        {
            try
            {
                var items = cartService.GetItems();
                logger.LogInformation("Retrieved {ItemCount} items from the cart.", items.Count());
                return Ok(new { message = "Items retrieved successfully.", items });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving items from the cart.");
                return StatusCode(500, "An error occurred while retrieving items from the cart.");
            }
        }
    }
}