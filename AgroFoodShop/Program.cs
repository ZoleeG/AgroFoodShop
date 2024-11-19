using AgroFoodShop.App;
using AgroFoodShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<AgroFoodShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:AgroFoodShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAntiforgery();

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

DbInitializer.Seed(app);

app.Run();
