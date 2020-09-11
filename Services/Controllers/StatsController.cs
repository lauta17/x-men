using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("asd");
        }
    }
}
