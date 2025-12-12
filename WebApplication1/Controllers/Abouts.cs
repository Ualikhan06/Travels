using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Добавить для ToListAsync
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AboutsController : Controller
    {
        private readonly AppDbContext _db;

        public AboutsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> About()
        {
            // ✅ ИСПРАВЛЕНИЕ: Удалена дублирующая строка
            List<BannerItem> bannerItems = await _db.BannerItems.ToListAsync();

            // Передаем данные в представление
            return View(bannerItems);
        }
    }
}