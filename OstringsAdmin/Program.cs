using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Data;
using OstringsAdmin.Data.Models;
using Microsoft.AspNetCore.Identity;
using OstringsAdmin.Repository;
using OstringsAdmin.Services;
using OstringsAdmin.Contracts.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(opt =>
               opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;

    options.Lockout.AllowedForNewUsers = false;
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Repositories
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ICateogriesRepository, CateogriesRepository>();
builder.Services.AddTransient<IProvidersRepository, ProvidersRepository>();
builder.Services.AddTransient<IEntriesRepository, EntriesRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();

//Services
builder.Services.AddTransient<UsersService>();
builder.Services.AddTransient<ProductsService>();
builder.Services.AddTransient<CateogriesService>();
builder.Services.AddTransient<EntriesService>();
builder.Services.AddTransient<OrdersService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

if (!await roleManager.RoleExistsAsync("Admin"))
    await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));

if (!await roleManager.RoleExistsAsync("User"))
    await roleManager.CreateAsync(new IdentityRole<Guid>("User"));

app.UseAuthentication();
app.UseAuthorization();

app.Run();
