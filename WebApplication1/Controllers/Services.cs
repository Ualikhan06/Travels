using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Services : Controller
    {
        private readonly AppDbContext _db;
        public Services(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Service()
        {
            List<TourOffer> tourOffers = await _db.tourOffers.ToListAsync();
            return View(tourOffers);
        }
    }
}
