using ShoppingCartBeService.DataModel;
using ShoppingCartBeService.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartBeService.Repository
{
    /// <summary>
    /// In-memory implementation of the cart repository.
    /// </summary>
    public class InMemoryRepository : ICartRepository
    {
        private static readonly IList<ICartItem> cartItems = new List<ICartItem>();
        private readonly ILogger<InMemoryRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public InMemoryRepository(ILogger<InMemoryRepository> _logger)
        {
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
                if (item == null)
                {
                    logger.LogWarning("InMemoryRepo : Attempted to add a null item to the cart.");
                    throw new ArgumentNullException(nameof(item), "InMemoryRepo : Cart item cannot be null.");
                }

                var existingItem = cartItems.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    logger.LogInformation("InMemoryRepo : Updated quantity for item: {ItemName}", item.Name);
                }
                else
                {
                    cartItems.Add(item);
                    logger.LogInformation("InMemoryRepo : Added new item to the cart: {ItemName}", item.Name);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "InMemoryRepo : Error occurred while adding item to the cart.");
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
                logger.LogInformation("InMemoryRepo : Retrieving all items from the cart.");
                return cartItems.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "InMemoryRepo : Error occurred while retrieving items from the cart.");
                throw; 
            }
        }
    }
}
