using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    
    public class CarController : Admin //Только для админа
    {
        public DataContext _context;
        public CarController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(li);
        }


        [HttpPost]
        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).Where(p => p.Category.Name == category).ToList();
            if (category == "Машины")
                li = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(li);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Model = _context.Models.ToList();
            return View();
        }

        //Добавление 
        [HttpPost]
        public async Task<IActionResult> Add(Car model, int id, IFormFile file)
        {
            string dirpath = Path.GetFullPath("wwwroot/img/");
            string path = dirpath + file.FileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            model.Img = "/img/" + file.FileName;
            var Category = await _context.Categories.SingleAsync(c => c.Id == id);
            model.Category = Category;           
            _context.Cars.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Удаление
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Cars.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Изменение
        public IActionResult Edit(int id)
        {
            var model = _context.Cars.Include(p => p.Category).Single(p => p.Id == id);
            var Catli = _context.Categories.Where(p => p.Id == model.Category.Id).ToList();
            var Stali = _context.Statuses.Where(p=> p.Id == model.Status.Id).ToList();
            var Modli = _context.Models.Where(p => p.Id == model.Model.Id).ToList();
            foreach (var x in _context.Categories.ToList())
            {
                Catli.Add(x);
            }
            foreach (var x in _context.Statuses.ToList())
            {
                Stali.Add(x);
            }
            foreach (var x in _context.Models.ToList())
            {
                Modli.Add(x);
            }
            ViewBag.Categories = Catli;
            ViewBag.Status = Stali;
            ViewBag.Model = Modli;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Car model, int id)
        {
            var lastmodel = _context.Cars.Single(p => p.Id == model.Id);
            var Category = _context.Categories.Single(p => p.Id == id);
            var status = _context.Statuses.First(p=> p.Id == model.Status.Id);
            var Model = _context.Models.First(p=> p.Id == model.Model.Id);
            lastmodel.Name = model.Name;
            lastmodel.Price = model.Price;
            lastmodel.Img = model.Img;
            lastmodel.Desciption = model.Desciption;
            lastmodel.Status = status;
            lastmodel.Model = Model;
            lastmodel.Category = Category;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}