using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDI.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]   
        public async Task<IActionResult> Get()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }
    }
}
