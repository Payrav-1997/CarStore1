using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Caunt { get; set; }
        public User Orderer { get; set; }
        public Car Item { get; set; }
        public bool IsOrdered { get; set; }
    }
}
