using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Context;
using WebApplication1.Crypt;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegistrationUser : Controller
    {
        private readonly DbUser _db;
        private readonly CryptPass _crypt;

        public RegistrationUser(DbUser db, CryptPass crypt)
        {
            _db = db;
            _crypt = crypt;
        }

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
                if (user.isAgree == true)
                {
                    user.Password = _crypt.Encod(user.Password);
                    user.ConfirmPassword = _crypt.Encod(user.ConfirmPassword);

                    _db.UserInfo.Add(user);
                    _db.SaveChanges();
                    return View("Accept", user);
                }
                else
                {
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel users) // 🚨 Сделайте async Task<IActionResult>
        {
            if (ModelState.IsValid)
            {
                string encryptedPassword = _crypt.Encod(users.Password);

                UserRegistrationModel user = _db.UserInfo.FirstOrDefault(
                    x => x.Email == users.Email && x.Password == encryptedPassword
                );

                if (user != null)
                {

                    var claims = new List<Claim>
            {

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)

            };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, "CookieAuth");

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, // Сохранять куки после закрытия браузера
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    // 2. Устанавливаем куки в браузере
                    await HttpContext.SignInAsync(
                        "CookieAuth",
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // 3. Перенаправляем на главную страницу 
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Неверный Email или пароль.");
                    return View(users);
                }
            }

            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Удаляем куки аутентификации
            await HttpContext.SignOutAsync("CookieAuth");

            // Перенаправляем на страницу входа
            return RedirectToAction("Login", "RegistrationUser");
        }
    }
}
