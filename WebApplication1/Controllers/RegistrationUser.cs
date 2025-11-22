using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class RegistrationUser : Controller
    {
        [HttpGet]
        public IActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                if (user != null && user.isAgree != false)
                {

                    return View("Accept", user);
                }
                else;
                {
                    return NotFound();
                }
            }
            else
            {
                return View(user);
            }
        }
    }
}
