using NUnit.Framework;
using Moq;
using ShoppingCartBeService.Interfaces;
using ShoppingCartBeService.Services;
using ShoppingCartBeService.DataModel;
using ShoppingCartBeService.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartBeService.Tests.Repository
{
    [TestFixture]
    public class InMemoryCartRepositoryTests
    {
        private InMemoryRepository cartRepository;

        [SetUp]
        public void Setup()
        {
            cartRepository = new InMemoryRepository();
        }

        [Test]
        public void AddItem_OnItemAdditionRequest_AddsItemToCart()
        {
            // Arrange
            var item = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };

            // Act
            cartRepository.AddItem(item);

            // Assert
            var items = cartRepository.GetItems();
            Assert.That(1,  Is.EqualTo(items.Count()));
            Assert.That("Apple", Is.EqualTo(items.First().Name));
        }

        [Test]
        public void GetItems_ShouldReturnAllItemsInCart()
        {
            // Arrange
            var item1 = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };
            var item2 = new CartItem { Name = "Banana", Price = 0.5m, Quantity = 10 };
            cartRepository.AddItem(item1);
            cartRepository.AddItem(item2);

            // Act
            var items = cartRepository.GetItems();

            // Assert
            Assert.That(2, Is.EqualTo(items.Count()));
            Assert.That(items.Any(i => i.Name == "Apple"), Is.True);
            Assert.That(items.Any(i => i.Name == "Banana"), Is.True);
        }
    }
}