using AgroFoodShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AgroFoodShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:AgroFoodShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);

app.Run();
