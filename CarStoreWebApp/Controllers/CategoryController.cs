using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class CategoryController : Admin
    {
        public DataContext _context;
        public CategoryController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Categories.OrderByDescending(p => p).Include(p => p.Name).ToList();
            return View(li);
        }


        [HttpPost]
        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Categories.OrderByDescending(p => p).Include(p => p.Name).Where(p => p.Name == category).ToList();
            if (category == "Машины")
                li = _context.Categories.OrderByDescending(p => p).Include(p => p.Name).ToList();
            return View(li);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Category model, int id)
        {
           
            var Category = await _context.Categories.SingleAsync(c => c.Id == id);
            model.Name = Name;
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Categories.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _context.Categories.Include(p => p.Name).Single(p => p.Id == id);
        
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category model, int id)
        {
            var lastmodel = _context.Categories.Single(p => p.Id == model.Id);        
            lastmodel.Name = model.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}