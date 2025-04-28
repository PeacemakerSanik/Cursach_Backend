using Cursach_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TestController : Controller
{
    private readonly Verified_IMSI_Context _context;

    public TestController(Verified_IMSI_Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> CheckDatabase()
    {
        try
        {
            // Простая проверка подключения
            var canConnect = await _context.Database.CanConnectAsync();
            if (!canConnect)
                return Content("Не удалось подключиться к базе данных");

            var data = await _context.Verified_Mobiles.Take(10).ToListAsync();

            return View(data);
        }
        catch (Exception ex)
        {
            return Content($"Ошибка: {ex.Message}");
        }
    }
    public IActionResult ReturnHome()
    {
        return RedirectToAction("Index", "Home");
    }
}