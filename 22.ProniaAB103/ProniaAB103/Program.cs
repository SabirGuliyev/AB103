using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Models;
using ProniaAB103.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

    options.User.RequireUniqueEmail = true;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddSession(option =>
{

    option.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LayoutService>();

builder.Services.AddDbContext<AppDbContext>(opt => 
         opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "Default",

    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"

    );

app.MapControllerRoute(
    name:"Default",

    pattern:"{controller=home}/{action=index}/{id?}"

    );

app.Run();
