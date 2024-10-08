using Microsoft.AspNetCore.Mvc;

namespace HelloRender.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController(ILogger<PingController> logger) : ControllerBase
{
    [HttpGet(Name = "Ping")]
    public string Get()
    {
        logger.LogInformation("Ping...");
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}