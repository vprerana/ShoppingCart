namespace ShoppingCartBeService.Interfaces
{
    public interface ICartRepository
    {
        void AddItem(ICartItem item);
        IEnumerable<ICartItem> GetItems();

    }
}