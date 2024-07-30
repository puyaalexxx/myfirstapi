using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MiddlewareController : ControllerBase
{
    private readonly ILogger<MiddlewareController> _logger;
    
    [ActivatorUtilitiesConstructor]
    public MiddlewareController(ILogger<MiddlewareController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("rate-limiting")]
    [EnableRateLimiting(policyName: "fixed")]
    public ActionResult RateLimitingDemo()
    {
        return Ok($"Hello Controller {DateTime.Now.Ticks.ToString()}");
    }
    
    [HttpGet("useCustomMiddleware")]
    public ActionResult Get()
    {
        var correlationId = Request.Headers["X-Correlation-Id"].FirstOrDefault();
        
        _logger.LogInformation("Handling the request. {CorrelationId}", correlationId);
        
        return Ok("Custom Middleware executed successfully");
    }
}