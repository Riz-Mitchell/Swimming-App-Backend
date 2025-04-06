using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend;
using SwimmingAppBackend.Context;
using DotNetEnv;
// using SwimmingAppBackend.Services;
using SwimmingAppBackend.Models;
using Microsoft.OpenApi.Models;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });

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

// builder.Services.AddSingleton(new FirebaseNotificationService(Environment.GetEnvironmentVariable("FIREBASE_NOTIFICATION_KEY")));

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
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at root
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
