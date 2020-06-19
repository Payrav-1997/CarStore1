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
            ViewBag.Abauts = _context.Abouts.ToList();
            var list = _context.Cars.OrderByDescending(p => p).Include(p => p.About).ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult Index(string about)
        {
            ViewBag.Abouts = _context.Abouts.ToList();
            var list = _context.Cars.OrderByDescending(p => p).Include(p => p.About).Where(p => p.About.Email == about).ToList();
            list = _context.Cars.OrderByDescending(p => p).Include(p => p.About).ToList();
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
            var model = _context.Cars.Include(p=>p.About).Single(p=>p.Id==id);
            var AboutList = _context.Abouts.Where(p => p.Id == model.About.Id).ToList();
            foreach (var item in _context.Abouts.ToList())
            {
                AboutList.Add(item);
            }
            ViewBag.Abouts = AboutList;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(AboutModel model,int id)
        {
            var lastModel = _context.Abouts.Single(p => p.Id == model.Id);
            lastModel.Adress = model.Adress;
            lastModel.Email = model.Email;
            lastModel.Phone = model.Phone;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}