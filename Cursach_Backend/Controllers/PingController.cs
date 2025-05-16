using Cursach_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace Cursach_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : Controller
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonSerializer.Serialize(new PingModel() { id = 1, description = "", status = "Pinging" });
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] IMSIModel model)
        {
            if (!DeviceStorage.Contains(model))
                DeviceStorage.AddDevice(model);
            return DeviceStorage.GetAllDevices().FirstOrDefault(x=> x.IMSI == model.IMSI && x.Ki == model.Ki) == null ? "Failed" : "Successful";
        }

        public IActionResult Details(string Ki)
        {
            var device = DeviceStorage.GetAllDevices().Find(x=> x.Ki == Ki);
            if (device == null) return NotFound();
            return View(device);
        }

        private void InitializeAuthentification()
        {

        }

    }
}
