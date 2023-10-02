using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Blazor.Data;
using Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// Додайте налаштування рядка підключення до бази даних PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<NoteService>();


var app = builder.Build();

// Налаштуйте засоби взаємодії з базою даних
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
   
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // Виконує міграції бази даних
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


