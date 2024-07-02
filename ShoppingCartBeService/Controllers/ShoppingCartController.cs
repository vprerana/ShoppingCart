using Microsoft.AspNetCore.Mvc;
using ShoppingCartBeService.DataModel;
using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICartService cartService;

        public ShoppingCartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        [HttpPost("AddItemsToCart")]
        public IActionResult AddItem([FromBody] CartItem item)
        {
            cartService.AddItem(item);
            return Ok();
        }

        [HttpGet("GetItemsFromCart")]
        public ActionResult<IEnumerable<ICartItem>> GetItems()
        {
            return Ok(cartService.GetItems());
        }
    }
}