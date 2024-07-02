using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartBeService.Interfaces;
using ShoppingCartBeService.Controllers;
using ShoppingCartBeService.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartBeService.Tests
{
    [TestFixture]
    public class ShoppingCartControllerTests
    {
        private Mock<ICartService> mockService;
        private ShoppingCartController cartController;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<ICartService>();
            cartController = new ShoppingCartController(mockService.Object);
        }

        [Test]
        public void AddItem_ShouldReturnOkResult()
        {
            // Arrange
            var item = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };

            // Act
            var result = cartController.AddItem(item);

            // Assert
            mockService.Verify(s => s.AddItem(item), Times.Once);
        }

        [Test]
        public void GetItems_ShouldReturnOkObjectResult_WithListOfItems()
        {
            // Arrange
            var item1 = new CartItem { Name = "Apple", Price = 1.0m, Quantity = 5 };
            var item2 = new CartItem { Name = "Banana", Price = 0.5m, Quantity = 10 };
            mockService.Setup(s => s.GetItems()).Returns(new List<ICartItem> { item1, item2 });

            // Act
            var result = cartController.GetItems();

            // Assert
            var okResult = result.Result as OkObjectResult;
            var items = okResult.Value as IEnumerable<ICartItem>;
            Assert.That(2, Is.EqualTo(items.Count()));
            Assert.That(items.Any(i => i.Name == "Apple"), Is.True);
            Assert.That(items.Any(i => i.Name == "Banana"), Is.True);
        }
    }
}
