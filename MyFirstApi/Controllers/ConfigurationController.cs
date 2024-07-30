using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    [Route("my-key")]
    public ActionResult GetMyKey()
    {
        var myKey = configuration["MyKey"];

        return Ok(myKey);
    }

    [HttpGet]
    [Route("database-conf")]
    public ActionResult GetDatabaseConfiguration()
    {
        var databaseOption = new DataBaseOption();
        
        configuration.GetSection(DataBaseOption.SectionName).Bind(databaseOption);
        
        //another way to get configurations
        //var type = configuration["Database:Type"];
        //var connectionString = configuration["Database:ConnectionString"];

        return Ok( new {databaseOption.Type, databaseOption.ConnectionString});
    }
    
    [HttpGet]
    [Route("database-conf-with-generic-type")]
    public ActionResult GetDatabaseConfigurationWithGenericType()
    {
        var databaseOption = configuration.GetSection(DataBaseOption.SectionName).Get<DataBaseOption>();

        return Ok( new {databaseOption?.Type, databaseOption?.ConnectionString});
    }
    
    [HttpGet]
    [Route("database-conf-with-generic-ioptions")]
    public ActionResult GetDatabaseConfigurationWithIoOptions( [FromServices] IOptions<DataBaseOption> options)
    {
        var databaseOption = options.Value;
        
        return Ok( new {databaseOption.Type, databaseOption.ConnectionString});
    }
    
    [HttpGet]
    [Route("database-conf-options-snapshot")]
    public ActionResult GetDatabaseConfigurationWithIoOptionsSnaPshot( [FromServices] IOptionsSnapshot<DataBaseOption> options)
    {
        var databaseOption = options.Value;
        
        return Ok( new {databaseOption.Type, databaseOption.ConnectionString});
    }
    
    [HttpGet]
    [Route("database-conf-ioptions-monitor")]
    public ActionResult GetDatabaseConfigurationWithIoOptionsMonitor( [FromServices] IOptionsMonitor<DataBaseOption> options)
    {
        var databaseOption = options.CurrentValue;
        
        return Ok( new {databaseOption.Type, databaseOption.ConnectionString});
    }
    
    [HttpGet]
    [Route("database-conf-with-named-options")]
    public ActionResult GetDatabaseConfigurationWithNamedOptions( [FromServices] IOptionsSnapshot<DataBaseOption> options)
    {
        var systemDataBaseOption = options.Get(DataBaseOption.SystemDatabaseSectionName);
        var businessDataBaseOption = options.Get(DataBaseOption.BusinessDatabaseSectionName);
        
        return Ok( new {SystemDataBaseOption = systemDataBaseOption, BusinessDataBaseOption = businessDataBaseOption});
    }
}