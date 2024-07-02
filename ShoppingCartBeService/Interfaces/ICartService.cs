namespace ShoppingCartBeService.Interfaces
{
    public interface ICartService
    {
        void AddItem(ICartItem item);
        IEnumerable<ICartItem> GetItems();
    }
}