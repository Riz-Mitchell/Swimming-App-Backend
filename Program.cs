using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SwimmingAppBackend;
using DotNetEnv;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SwimmingAppBackend.Domain.Services;
using SwimmingAppBackend.Infrastructure.Context;
using System.Text.Json.Serialization;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Preserve property names as-is
    });
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });

var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!);
var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

// Register JWT Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };

    // Look for the token in the HTTP-only cookie
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("AccessToken"))
            {
                context.Token = context.Request.Cookies["AccessToken"];
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(); // Don't forget this!

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
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ITwilioService, TwilioService>();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


