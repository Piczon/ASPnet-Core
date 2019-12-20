using System;
using Xunit;
using SportShop;
using Moq;
using SportShop.Models;
using System.Linq;
using SportShop.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ApiTests
{
    public class UnitTest1
    {

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void AllProducts()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "Product 1"},
                new Product { ProductID = 2, Name = "Product 2"},
                new Product { ProductID = 3, Name = "Product 3"},
                new Product { ProductID = 4, Name = "Product 4"},
            }.AsQueryable<Product>());

            AdminController controller = new AdminController(mock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(controller.Index()).ToArray();

            Assert.Equal(4, result.Length);
            Assert.Equal("Product 1", result[0].Name);
            Assert.Equal("Product 2", result[1].Name);
            Assert.Equal("Product 3", result[2].Name);
            Assert.Equal("Product 4", result[3].Name);
        }

        [Fact]
        public void FilterProducts()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "Product 1", Category = "First"},
                new Product { ProductID = 2, Name = "Product 2", Category = "Second"},
                new Product { ProductID = 3, Name = "Product 3", Category = "Third"},
                new Product { ProductID = 4, Name = "Product 4", Category = "First"},
            }.AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(controller.List("First")).ToArray();


            Assert.Equal(2, result.Length);

            Assert.True(result[0].Name == "Product 1" && result[0].Category == "First");
            Assert.True(result[1].Name == "Product 4" && result[1].Category == "First");
        }

        [Theory]
        [InlineData(1, "Product 1")]
        [InlineData(2, "Product 2")]
        public void FilterProductsWithTestCase(int id, string name)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1, Name = "Product 1", Category = "First"},
                new Product { ProductID = 2, Name = "Product 2", Category = "Second"},
                new Product { ProductID = 3, Name = "Product 3", Category = "Third"},
                new Product { ProductID = 4, Name = "Product 4", Category = "First"},
            }.AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);

            Product result = GetViewModel<Product>(controller.GetById(id));


            Assert.Equal(name, result.Name);
        }

    }
}
