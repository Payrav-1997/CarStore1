using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class ClientAvtoController : Controller
    {
        public DataContext _context;
        public ClientAvtoController(DataContext context)
        {
            this._context = context;
        }
        //Для вывода машин на экран
        [HttpGet]
        public IActionResult List(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var list = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).Where(p => p.Category.Name == category).ToList();
            list = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult GetOnly(int id)
        {
            var car = _context.Cars.Include(c=>c.Status).Include(c=>c.Model).First(c=> c.Id == id);
            return View(car);
        }
        
    }
}