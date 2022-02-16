using Microsoft.EntityFrameworkCore;
using T3MVCProject.Models;
using T3MVCProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(opts =>
{
    opts.IdleTimeout = TimeSpan.FromMinutes(30);
});


string strCon = builder.Configuration.GetConnectionString("conn");

builder.Services.AddDbContext<T3ShopContext>(opts =>
{
    opts.UseSqlServer(strCon);
});


//Injecting the service
builder.Services.AddScoped<IRepo<int, Shopper>, ShopperRepo>();
builder.Services.AddScoped<IRepo<string, User>, UserRepo>();
builder.Services.AddScoped<LoginService>();

//Inject Order Service
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddTransient<IRepo<int, Order>, OrderRepo>();
builder.Services.AddTransient<IRepo<int, OrderItem>, OrderItemRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}");

app.Run();
