using System.Diagnostics;
using Cursach_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cursach_Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static DateTime _lastUpdate = DateTime.MinValue;

        [HttpGet]
        public JsonResult CheckUpdates()
        {
            var currentLastUpdate = DeviceStorage.LastChanged;
            bool needsRefresh = currentLastUpdate > _lastUpdate;
            _lastUpdate = currentLastUpdate;
            return Json(new { needsRefresh });
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(DeviceStorage.GetAllDevices());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAct()
        {
            return RedirectToAction("CheckDatabase", "Test");
        }
    }
}
