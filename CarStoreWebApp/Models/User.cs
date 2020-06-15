﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public  string  Password { get; set; }
        public Role Role { get; set; }
    }
}
