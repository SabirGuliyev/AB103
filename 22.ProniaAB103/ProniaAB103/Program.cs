using Microsoft.EntityFrameworkCore;
using ProniaAB103.DAL;
using ProniaAB103.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LayoutService>();

builder.Services.AddDbContext<AppDbContext>(opt => 
         opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();


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
