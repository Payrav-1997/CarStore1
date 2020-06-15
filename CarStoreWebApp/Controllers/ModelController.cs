using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class ModelController : Controller
    {
        public DataContext _context;
        public ModelController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {

            var li = _context.Models.OrderByDescending(p => p).Include(p => p.Name).ToList();
            return View(li);
        }


        [HttpPost]
        public IActionResult Index(string category)
        {
            var li = _context.Models.OrderByDescending(p => p).Include(p => p.Name).Where(p => p.Name == category).ToList();
            return View(li);
        }
        public IActionResult Add()
        {
            ViewBag.Models = _context.Models.ToList();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>Add(Model model)
        {

            _context.Models.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Models.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _context.Models.Include(p => p.Name).Single(p => p.Id == id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category model, int id)
        {
            var lastmodel = _context.Models.Single(p => p.Id == model.Id);
            lastmodel.Name = model.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
}