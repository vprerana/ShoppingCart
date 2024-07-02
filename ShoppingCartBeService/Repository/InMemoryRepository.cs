using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.Repository
{
    public class InMemoryRepository : ICartRepository
    {
        private static readonly IList<ICartItem> cartItems = new List<ICartItem>();
        
        public void AddItem(ICartItem item)
        {   
            if (item == null){
                throw new ArgumentNullException(nameof(item), "Cart item cannot be null.");
            }
            var existingItem = cartItems.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cartItems.Add(item);
            }
        }

        public IEnumerable<ICartItem> GetItems()
        {
            Console.WriteLine(cartItems);
            return cartItems.ToList();
        }
    }
}