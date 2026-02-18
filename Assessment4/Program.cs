using Assessment4.Models;
using Assessment4.Services;
using Assessment4.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure AppSettings
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

// Register Custom Service
builder.Services.AddScoped<IMyService, MyService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use Custom Middleware
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
