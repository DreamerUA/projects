using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LabPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Длина логина от 5 до 100 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длин0 пароля от 3 до 30 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}