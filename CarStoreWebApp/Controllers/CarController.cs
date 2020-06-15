using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class CarController : Admin
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
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Car model, int id)
        {
            var Category = await _context.Categories.SingleAsync(c => c.Id == id);
            model.Category = Category;
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Cars.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _context.Cars.Include(p => p.Category).Single(p => p.Id == id);
            var li = _context.Categories.Where(p => p.Id == model.Category.Id).ToList();
            foreach (var x in _context.Categories.ToList())
            {
                li.Add(x);
            }
            ViewBag.Categories = li;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Car model, int xid)
        {
            var lastmodel = _context.Cars.Single(p => p.Id == model.Id);
            var Category = _context.Categories.Single(p => p.Id == xid);
            lastmodel.Name = model.Name;
            lastmodel.Price = model.Price;
            lastmodel.Img = model.Img;
            lastmodel.Desciption = model.Desciption;
            lastmodel.Status = Status;
            lastmodel.Model = Model;
            lastmodel.Category = Category;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}