using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend;
using SwimmingAppBackend.Context;
using DotNetEnv;
using SwimmingAppBackend.Interfaces;
using SwimmingAppBackend.Repositories;
using SwimmingAppBackend.Models;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

Console.WriteLine("DOTNET_ENV=" + builder.Configuration["DOTNET_ENV"]);

// Configure DbContext with PostgreSQL connection string from environment variables
if (Environment.GetEnvironmentVariable("DOTNET_ENV") == "PROD")
{
    // Load Production Variables
    builder.Services.AddDbContext<SwimmingAppDBContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_PROD")));
    Console.WriteLine("=========================\nPROD MODE !!!!!!!\n=========================\n");
}
else
{
    builder.Services.AddDbContext<SwimmingAppDBContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_DEV")));
    Console.WriteLine("=========================\nDEV MODE !!!!!!!\n=========================\n");
}

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISwimRepository, SwimRepository>();
builder.Services.AddScoped<ISwimmerMetaDataRepository, SwimmerMetaDataRepository>();

var app = builder.Build();

// Ensure migrations are applied on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SwimmingAppDBContext>();

    // Apply migrations automatically
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
