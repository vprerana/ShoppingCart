namespace ShoppingCartBeService.Interfaces
{
    /// <summary>
    /// Provides methods to manage the shopping cart repository.
    /// </summary>
    public interface ICartRepository
    {
        /// <summary>
        /// Adds an item to the cart.
        /// </summary>
        /// <param name="item">The cart item to add.</param>
        void AddItem(ICartItem item);

        /// <summary>
        /// Retrieves all items from the cart.
        /// </summary>
        /// <returns>A collection of cart items.</returns>
        IEnumerable<ICartItem> GetItems();
    }
}
