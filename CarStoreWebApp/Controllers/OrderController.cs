using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class OrderController : Controller
    {
        DataContext _context;
        public OrderController(DataContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Orders.Include(c=>c.Item).Include(c => c.Item.Orderer).Include(c=>c.Item.Item).Where(c=> c.Item.Orderer.Email == User.Identity.Name).ToList();
            return View(list);
        }
        //Для адресов покупателей 
        [HttpPost]
        public async Task<IActionResult> AddOrder(Order model)
        {
            var Items = await _context.Carts.Include(c => c.Orderer).Where(c => c.Orderer.Email == User.Identity.Name).ToListAsync();
            foreach (var x in Items)
            {
                var item = await _context.Carts.FirstAsync(c=>c == x);
           
                _context.Orders.Add(new Order()
                {
                    Item = x,
                    Adress = model.Adress,
                    Name = model.Name,
                    Phone = model.Phone
                });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("OrderVerification", "ClientCart");
        }
    }
}