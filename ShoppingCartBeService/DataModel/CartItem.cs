using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.DataModel
{
    public class CartItem : ICartItem
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}