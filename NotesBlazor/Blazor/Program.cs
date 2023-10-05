using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Application.Service;
using Application.Service.Service;
using Domain.Repository.Interfaces;
using Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// database connection string settings PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IDbContext, AppDbContext>();
builder.Services.AddScoped<INoteService,NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<NoteService>();


var app = builder.Build();

// means of interaction with the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
   
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); //  interaction with the database
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


