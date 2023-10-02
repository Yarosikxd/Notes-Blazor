using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// ������� ������������ ����� ���������� �� ���� ����� PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// ������� ������ �� ������������ �������
// ...

var app = builder.Build();

// ���������� ������ �����䳿 � ����� �����
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
   
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // ������ ������� ���� �����
}

// �������� �������
app.Run();
