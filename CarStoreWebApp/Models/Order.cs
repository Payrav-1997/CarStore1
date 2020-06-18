using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Длина номера должна быть от 7 до 15 символов")]
        public string Phone { get; set; }
        public string Adress { get; set; }
        public Cart Item { get; set; }
    }
}
