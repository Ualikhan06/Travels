using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Abouts : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
