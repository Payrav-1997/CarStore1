using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Areas.Admin.Controllers
{
    public class ModelController : AdminBase
    {
        public DataContext _context;
        public ModelController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Models.OrderByDescending(p => p).ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(string model)
        {
            var list = _context.Models.Where(p => p.Name == model).OrderByDescending(p => p).ToList();
            return View(list);
        }
        public IActionResult Add()
        {
            ViewBag.Models = _context.Models.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Model models)
        {
            _context.Models.Add(models);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var model = await _context.Models.SingleAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");     
        }
        public IActionResult Edit (int id)
        {
            var model = _context.Models.Single(p => p.Id == id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Model model,int id)
        {
            var lastModel = _context.Models.Single(p => p.Id == model.Id);
            lastModel.Name = model.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}