using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace KLO128.Calculator.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new { Value = Assembly.GetExecutingAssembly().GetName().Version?.ToString() });
        }
    }
}
