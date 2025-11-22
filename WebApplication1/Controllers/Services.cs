using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Services : Controller
    {
        public IActionResult Service()
        {
            return View();
        }
    }
}
