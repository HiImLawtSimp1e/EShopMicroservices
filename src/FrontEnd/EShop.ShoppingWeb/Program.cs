global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Refit;
global using EShop.ShoppingWeb.DomainModels.Catalog;
global using EShop.ShoppingWeb.DomainModels.Basket;
global using EShop.ShoppingWeb.DomainModels.Ordering;
global using EShop.ShoppingWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRefitClient<ICatalogService>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});

builder.Services.AddRefitClient<IBasketService>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});

builder.Services.AddRefitClient<IOrderingService>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
