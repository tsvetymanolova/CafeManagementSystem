using CafeManagementSystemProject.DataFolder;
using Microsoft.EntityFrameworkCore;
using CafeManagementSystemProject.Services;
using CafeManagementSystemProject.Services.Interfaces;
using CafeManagementSystemProject.Repositories;
using CafeManagementSystemProject.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCOrderDbContext>(c =>
    c.UseMySQL("Server=127.0.0.1;Database=tina;Uid=root;Pwd=TinaITsveti;"));
// Add services to the container.

builder.Services.AddScoped < IProductRepository, ProductRepository > ();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
Seed.SeedData(app);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();
