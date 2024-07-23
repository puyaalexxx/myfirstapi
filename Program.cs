using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using MyFirstApi;
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
builder.Services.AddControllers();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter();

app.MapGet("/rate-limiting-mini", () => Results.Ok($"Hello {DateTime.Now.Ticks.ToString()}")).RequireRateLimiting("fixed");

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