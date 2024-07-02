using NUnit.Framework;
using Moq;
using ShoppingCartBeService.Interfaces;
using ShoppingCartBeService.Services;
using ShoppingCartBeService.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartBeService.Tests
{
    [TestFixture]
    public class CartServiceTests
    {
        private Mock<ICartRepository> mockRepository;
        private ICartService cartService;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<ICartRepository>();
            cartService = new CartService(mockRepository.Object);
        }

        [Test]
        public void AddItem_ShouldCallRepositoryAddItem()
        {
            // Arrange
            var item = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };

            // Act
            cartService.AddItem(item);

            // Assert
            mockRepository.Verify(r => r.AddItem(item), Times.Once);
        }

        [Test]
        public void GetItems_ShouldReturnAllItemsFromRepository()
        {
            // Arrange
            var item1 = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };
            var item2 = new CartItem { Name = "Banana", Price = 0.5m, Quantity = 10 };
            mockRepository.Setup(r => r.GetItems()).Returns(new List<ICartItem> { item1, item2 });

            // Act
            var items = cartService.GetItems();

            // Assert
            Assert.That(2, Is.EqualTo(items.Count()));
            Assert.That(items.Any(i => i.Name == "Apple"), Is.True);
            Assert.That(items.Any(i => i.Name == "Banana"), Is.True);
        }
    }
}
