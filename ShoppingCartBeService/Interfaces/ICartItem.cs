namespace ShoppingCartBeService.Interfaces
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public interface ICartItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item.
        /// </summary>
        int Quantity { get; set; }
    }
}