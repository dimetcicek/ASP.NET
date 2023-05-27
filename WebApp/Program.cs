using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webapp.Helpers.Repositories;
using WebApp.Contexts;
using WebApp.Helpers.Repositories;
using WebApp.Helpers.Services;
using WebApp.Models.Entities;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>();


// contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

// authentication
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.AccessDeniedPath = "/denied";
});


// repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<ProductRepository>();

// services
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserAdminService>();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
