using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
        public string Desciption { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public Model Model { get; set; }
    }
}
