using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Areas.Admin.Controllers
{
    public class AboutController : AdminBase
    {
        public DataContext _context;
        public AboutController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Abouts.ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(string about)
        {
            ViewBag.Abouts = _context.Abouts.ToList();
            var list = _context.Abouts.OrderByDescending(p => p).Where(p => p.Email == about).ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            ViewBag.Abouts = _context.Abouts.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Add(AboutModel model )
        {
           _context.Abouts.Add(model);
           _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Abouts.FirstAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = _context.Abouts.Where(p=>p.Id==id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(AboutModel model,int id)
        {           
            var lastModel = _context.Abouts.Where(p => p.Id == model.Id).FirstOrDefault();
            model.Id=lastModel.Id;
            _context.Entry(model).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}