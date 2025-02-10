using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExampleController : ControllerBase
{
    // Scope
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}
