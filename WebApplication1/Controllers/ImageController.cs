using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
