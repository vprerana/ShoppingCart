namespace ShoppingCartBeService.Interfaces
{
    public interface ICartItem
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
    }
}