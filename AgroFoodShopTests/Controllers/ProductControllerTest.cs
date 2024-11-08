using AgroFoodShop.Controllers;
using AgroFoodShop.ViewModels;
using AgroFoodShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroFoodShopTests.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllProducts()
        {
            //arrange
            var mockProductRepository = RepositoryMocks.GetProductRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var productController = new ProductController(mockProductRepository.Object, mockCategoryRepository.Object);

            //act
            var result = productController.List("");

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var productListViewModel = Assert.IsAssignableFrom<ProductListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(5, productListViewModel.Products.Count());
        }
    }
}
