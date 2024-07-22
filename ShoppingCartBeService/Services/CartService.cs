using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.Services
{
    /// <summary>
    /// Service to manage the shopping cart operations.
    /// </summary>
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<CartService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository instance.</param>
        /// <param name="logger">The logger instance.</param>
        public CartService(ICartRepository cartRepository, ILogger<CartService> _logger)
        {
            _cartRepository = cartRepository;
            logger = _logger;
        }

        /// <summary>
        /// Adds an item to the cart.
        /// </summary>
        /// <param name="item">The cart item to add.</param>
        public void AddItem(ICartItem item)
        {
            try
            {
                logger.LogInformation("Inside CartService: Adding item to cart: {ItemName}", item.Name);
                _cartRepository.AddItem(item);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Inside CartService: Error occurred while adding item to the cart.");
                throw;
            }
        }

        /// <summary>
        /// Retrieves all items from the cart.
        /// </summary>
        /// <returns>A collection of cart items.</returns>
        public IEnumerable<ICartItem> GetItems()
        {
            try
            {
                logger.LogInformation("Inside CartService: Getting items from cart.");
                return _cartRepository.GetItems();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Inside CartService: Error occurred while retrieving items from the cart.");
                throw; 
            }
        }
    }
}
