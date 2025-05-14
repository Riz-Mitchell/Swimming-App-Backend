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
using SwimmingAppBackend.Infrastructure.Repositories;
using System.Text.Json;
using SwimmingAppBackend.Infrastructure.Models;
using SwimmingAppBackend.Domain.Helpers;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// JWT setup
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT_KEY environment variable is missing.");
}

var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

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
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
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

builder.Services.AddAuthorization();
// change to force deploy
// Configure DB context
var env = Environment.GetEnvironmentVariable("DOTNET_ENV");
Console.WriteLine($"=========================\nENV: {env}\n=========================");

if (env == "PROD")
{
    builder.Services.AddDbContext<SwimmingAppDBContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_PROD")));
    Console.WriteLine("✅ Running in PROD mode");
}
else
{
    builder.Services.AddDbContext<SwimmingAppDBContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_DEV")));
    Console.WriteLine("✅ Running in DEV mode");
}

// DI setup
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAthleteDataRepository, AthleteDataRepository>();
builder.Services.AddScoped<ISwimRepository, SwimRepository>();
builder.Services.AddScoped<IUserAchievementRepository, UserAchievementsRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISwimService, SwimService>();
builder.Services.AddScoped<IUserAchievementService, UserAchievementService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ITwilioService, TwilioService>();

var app = builder.Build();

// Auto migrations + optional JSON seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SwimmingAppDBContext>();

    dbContext.Database.Migrate();

    // Run seed only if flagged
    var runSeed = Environment.GetEnvironmentVariable("RUN_DATA_SEED");
    if (runSeed == "true")
    {
        string jsonDirectory = "Timesheets-In-JSON";
        foreach (var file in Directory.GetFiles(jsonDirectory, "*.json"))
        {
            Console.WriteLine($"Processing file: {file}");
            try
            {
                string json = File.ReadAllText(file);
                var splitDataList = JsonSerializer.Deserialize<List<SplitData>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (splitDataList != null)
                {
                    var eventName = Path.GetFileNameWithoutExtension(file);
                    if (eventName.EndsWith("Men"))
                    {
                        eventName = eventName.Substring(0, eventName.Length - 3);
                    }

                    var timeSheet = new TimeSheet
                    {
                        Event = Enum.TryParse<SwimmingAppBackend.Enum.EventEnum>(eventName, true, out var parsedEvent)
                            ? parsedEvent
                            : throw new InvalidOperationException($"Invalid event name: {eventName}"),
                        SplitDataForTimes = splitDataList
                    };

                    dbContext.TimeSheets.Add(timeSheet);
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            }
        }
    }
}

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
