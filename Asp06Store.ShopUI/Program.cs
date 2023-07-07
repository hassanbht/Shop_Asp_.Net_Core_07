using Asp07Store.ShopUI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shop_Asp.Net.Core_07.Domain.Setting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Get Connection String from appsetting
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
// read appsettings        
builder.Services.AddOptions();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//Active Session
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<Basket>(c => SessionBasket.GetBasket(c));
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCagegoryReposiroty>();
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
//app.MapRazorPages();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/Page{PageNumber}");
            endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
            endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
            endpoints.MapDefaultControllerRoute();
        }
    );

app.Run();
