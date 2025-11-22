using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserRegistrationModel
    {

        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [Display(Name = "Почта")]
        [UIHint("Почту")]
        [EmailAddress]
        [Required(ErrorMessage = "Введите Почту")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Почта не валидна")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [UIHint("Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [Compare("ConfirmPassword", ErrorMessage = "Пароли должны совпадать")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Ваш пароль не попадает в дипазон от 6 до 16 симлолов ")]

        public string Password { get; set; }
        [UIHint("Пароль")]
        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Ваш пароль не попадает в дипазон от 6 до 16 симлолов ")]

        public string ConfirmPassword { get; set; }
        [Display(Name = "Возраст")]
        [Range(17, 70, ErrorMessage = "Ваш возраст должен быть от 17 до 70 лет")]
        public int? Age { get; set; }
        [Display(Name = "Согласны ли с условием?")]
        [Required(ErrorMessage = "Поставьте галочку")]
        public bool isAgree { get; set; }

    }
}
