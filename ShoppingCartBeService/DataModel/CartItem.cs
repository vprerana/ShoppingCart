using ShoppingCartBeService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartBeService.DataModel
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem : ICartItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters.")]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}