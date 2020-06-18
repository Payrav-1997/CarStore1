using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Login
    {
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 20 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}
