﻿using AgroFoodShop.Models;

namespace AgroFoodShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; }
        public string? CurrentCategory { get; }
        public ProductListViewModel(IEnumerable<Product> products, string? currentCategory)
        {
            Products = products;
            CurrentCategory = currentCategory;
        }
    }
}
