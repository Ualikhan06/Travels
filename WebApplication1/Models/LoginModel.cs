using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите почту.")]
        [Display(Name = "Почта")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$", ErrorMessage = "Почта не валидна")]
        [EmailAddress(ErrorMessage = "Неверный формат Email-адреса.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль.")]
        [Display(Name = "Пароль")]
        [UIHint("Пароль")]
        public string Password { get; set; }
    }
}