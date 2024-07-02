using ShoppingCartBeService.Interfaces;

namespace ShoppingCartBeService.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddItem(ICartItem item)
        {
            _cartRepository.AddItem(item);
        }

        public IEnumerable<ICartItem> GetItems()
        {
            return _cartRepository.GetItems();
        }
    }
}