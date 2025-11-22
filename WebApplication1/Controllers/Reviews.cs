using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Reviews : Controller
    {
        public IActionResult Review()
        {
            return View();
        }
    }
}
