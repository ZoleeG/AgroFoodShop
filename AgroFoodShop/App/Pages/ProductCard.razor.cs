using AgroFoodShop.Models;
using Microsoft.AspNetCore.Components;

namespace AgroFoodShop.App.Pages
{
    public partial class ProductCard
    {
        [Parameter]
        public Product? Product { get; set; }
    }
}
