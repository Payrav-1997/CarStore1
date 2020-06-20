using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Areas.Admin.Controllers
{

    public class CarController : AdminBase //Только для админа
    {
        public DataContext _context;
        public CarController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var list = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(list);
        }


        [HttpPost]
        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var list = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).Where(p => p.Category.Name == category).ToList();
            list = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(list);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();

            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Model = _context.Models.ToList();
            return View();
        }

        //Добавление машины
        [HttpPost]
        public async Task<IActionResult> Add(Car model, int CId, int SId, int MId, IFormFile file)
        {
            string dirpath = Path.GetFullPath("wwwroot/img/");
            string path = dirpath + file.FileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            model.Img = "/img/" + file.FileName;
            var Category = await _context.Categories.FirstAsync(c => c.Id == CId);
            var Model = await _context.Models.FirstAsync(c => c.Id == MId);
            var Status = await _context.Statuses.FirstAsync(c => c.Id == SId);
            model.Category = Category;
            model.Model = Model;
            model.Status = Status;
            _context.Cars.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Удаление машины
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Cars.FirstAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Изменение машины
        public IActionResult Edit(int id)
        {
            var model = _context.Cars.Include(p => p.Category).Include(p => p.Status).Include(p => p.Model).Single(p => p.Id == id);
            var CategoryList = _context.Categories.Where(p => p.Id == model.Category.Id).ToList();
            var StatusList = _context.Statuses.Where(p => p.Id == model.Status.Id).ToList();
            var ModelList = _context.Models.Where(p => p.Id == model.Model.Id).ToList();
            foreach (var x in _context.Categories.ToList())
            {
                CategoryList.Add(x);
            }
            foreach (var x in _context.Statuses.ToList())
            {
                StatusList.Add(x);
            }
            foreach (var x in _context.Models.ToList())
            {
                ModelList.Add(x);
            }
            ViewBag.Categories = CategoryList;
            ViewBag.Status = StatusList;
            ViewBag.Model = ModelList;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Car model, int id, int SId, int MId, IFormFile file)
        {
            var lastmodel = _context.Cars.Single(p => p.Id == model.Id);
            if (file != null)
            {
                if ("/img/" + file.FileName != lastmodel.Img)
                {
                    string dirpath = Path.GetFullPath("wwwroot/img/");
                    string path = dirpath + file.FileName;
                    using (var stream = System.IO.File.Create(path))
                    {
                        file.CopyTo(stream);
                    }
                    model.Img = "/img/" + file.FileName;
                }
            }
            var Category = await _context.Categories.SingleAsync(p => p.Id == id);
            var Model = await _context.Models.FirstAsync(c => c.Id == MId);
            var status = await _context.Statuses.FirstAsync(c => c.Id == SId);
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
        //Для Покупки
        public IActionResult GetOrders()
        {
            var list = _context.Orders.Include(p => p.Item).Include(p => p.Item.Item).ToList();
            return View(list);
        }
        //Для удаение покупки
        public IActionResult DeleteOrder(int id)
        {
            _context.Orders.Remove(_context.Orders.Where(p => p.Id == id).FirstOrDefault());
            _context.SaveChanges();
            return RedirectToAction("GetOrders", "Car");
        }
    }
}