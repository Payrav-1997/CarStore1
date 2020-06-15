using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Register
    {
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан электронный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Некорректный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Пароли не совпадают!")]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
    }
}
