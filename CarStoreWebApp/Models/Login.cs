﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан электронный адрес")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}
