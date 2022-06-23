using DeviceShop.Repository;
using DeviceShop.Services;
using Microsoft.EntityFrameworkCore;
using ShopDevice.Helpers;
using ShopDevice.Repository;
using ShopDevice.Services;
using SiteShopCar.Data;
using SiteShopCar.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbApplicationContext>(options =>
options.UseNpgsql("Host=localhost;Port=5432;Database=ShopElectronics;Username=postgres;Password=1"));


builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddControllersWithViews();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddTransient<ICommonRepository<Device>, DeviceService<Device>>();
builder.Services.AddTransient<ICommonRepository<TypeDevice>, TypeDeviceServices<TypeDevice>>();
builder.Services.AddTransient<ICommonRepository<Brand>, BrandService<Brand>>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
