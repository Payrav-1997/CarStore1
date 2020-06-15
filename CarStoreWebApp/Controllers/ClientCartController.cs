using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class ClientCarController : Controller
    {
        public DataContext _context;
        public ClientCarController(DataContext context)
        {
            this._context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Cars.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(li);
        }
        //Добавление в корзину
        public async Task<IActionResult> AddCart(int id)
        {
            var product = await _context.Cars.FirstOrDefaultAsync(p => p.Id == id);


            _context.Carts.Add(new Cart { Item =  product});
            await _context.SaveChangesAsync();

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> CartList()
        {
            var cartList = await _context.Carts.Include(u => u.Item).ToListAsync();
            return View(cartList);
        }
    }
}