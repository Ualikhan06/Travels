using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Reviews : Controller
    {
        private readonly AppDbContext _db;
        public Reviews(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Review()
        {
            // ✅ ИСПРАВЛЕНИЕ: Удалена дублирующая строка
            List<BannerItem> bannerItems = await _db.BannerItems.ToListAsync();

            // Передаем данные в представление
            return View(bannerItems);
        }
    }
}

