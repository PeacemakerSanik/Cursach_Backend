using Cursach_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace Cursach_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        private static string ping = "";

        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonSerializer.Serialize(new PingModel() { id = 1, description = "", status = "Pinging" });
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] string ping)
        {
            return ping + "Ping successfully posted";
        }


    }
}
