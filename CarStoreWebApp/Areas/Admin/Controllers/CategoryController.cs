using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Areas.Admin.Controllers
{
    public class CategoryController : AdminBase
    {
        public DataContext _context;
        public CategoryController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
           
            var list = _context.Categories.OrderByDescending(p => p).ToList();
            return View(list);
        }


        [HttpPost]
        public IActionResult Index(string category)
        {
            var list = _context.Categories.Where(p => p.Name == category).OrderByDescending(p => p).ToList();
            return View(list);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        //Добавление категории
        [HttpPost]
        public async Task<IActionResult> Add(Category model)
        {
          
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Удаление категории
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Categories.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Изменение категории
        public IActionResult Edit(int id)
        {
            var model = _context.Categories.Single(p => p.Id == id);
        
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