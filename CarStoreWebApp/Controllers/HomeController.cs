using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public DataContext _context;
        public HomeController(DataContext context)
        {
            this._context = context;
        }
        
        public IActionResult Index()
        {
            var list = _context.Cars.Include(a=>a.Model).Include(a=>a.Category).ToList();
            return View(list);
        }
        //Только для админа
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SearchByCattegory(int id)
        {
            var list = _context.Cars.Include(a => a.Category).Include(a => a.Model).Where(p => p.Model == _context.Models.Where(p => p.Id == id).FirstOrDefault());
            return View(list.ToList());
        }
        public IActionResult About(int id)
        {
            ViewBag.Abouts = _context.Abouts.ToList();
            var list = _context.Abouts.ToList();
            return View(list);
        }
    }
}
