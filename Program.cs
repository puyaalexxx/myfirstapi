using System.Text;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyFirstApi;
using MyFirstApi.Authentication;
using MyFirstApi.Data;
using MyFirstApi.Helpers;
using MyFirstApi.Services;
using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

var logsPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
Directory.CreateDirectory(logsPath);

var logger = new LoggerConfiguration()
    .WriteTo.File(
        Path.Combine(logsPath, "log.txt"),
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 90)
    //.WriteTo.Console(new JsonFormatter())
    .WriteTo.Seq("http://localhost:5341/")
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDiServices();
builder.Services.AddConfig(builder.Configuration);

builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixed", options =>
{
    options.PermitLimit = 5;
    options.Window = TimeSpan.FromSeconds(10);
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    options.QueueLimit = 2;
}));

// Add services to the container.
builder.Services.AddDbContext<MainDbContext>();

//authentication via jwt
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var secret = builder.Configuration["JwtConfig:Secret"];
    var issuer = builder.Configuration["JwtConfig:ValidIssuer"];
    var audience = builder.Configuration["JwtConfig:ValidAudiences"];

    if (secret is null || issuer is null || audience is null)
    {
        throw new ApplicationException("Jwt is not set in the configuration");
    }

    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters  = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});

//add authentication support for swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter();

app.MapGet("/rate-limiting-mini", () => Results.Ok($"Hello {DateTime.Now.Ticks.ToString()}"))
    .RequireRateLimiting("fixed");

app.UseMiddleware<CorrelationIdMiddleware>();

/*app.Use(async (context, next) =>
{
    Console.WriteLine("Use first middleware world");
    await next(context);
    Console.WriteLine("Use second middleware world");
});

app.Run(async context =>
{
    Console.WriteLine("Handling request in app.Run middleware");
    await context.Response.WriteAsync("Hello world");
});*/


app.Run();