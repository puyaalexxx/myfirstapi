using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoggingDemoController : ControllerBase
{
    private readonly ILogger<LoggingDemoController> _logger;

    public LoggingDemoController(ILogger<LoggingDemoController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [Route("simplelogging")]
    public IActionResult  SimpleLogging()
    {
        _logger.LogInformation("This is a logging message");
        
        return Ok("Example action executed successfully");
    }
    
    [HttpGet]
    [Route("structuredlogging")]
    public IActionResult  StructuredLogging()
    {
        _logger.LogInformation("This is a logging message with args: Today is {Week}. It is {Time}.", DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
        
        _logger.LogInformation($"This is a logging message with string concatenation: Today is {DateTime.Now.DayOfWeek}. It is {DateTime.Now.ToLongTimeString()}");
        
        return Ok("Structured logging executed successfully");
    }
}