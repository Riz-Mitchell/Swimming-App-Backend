using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend;
using SwimmingAppBackend.context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with PostgreSQL connection string from appsettings.json
builder.Services.AddDbContext<SwimmingAppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
