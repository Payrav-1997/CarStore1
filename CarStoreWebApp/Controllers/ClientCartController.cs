using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class ClientCartController : Controller
    {
        public DataContext _context;
        public ClientCartController(DataContext context)
        {
            this._context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Accaunt");
            }
            else
            {
                var list = _context.Carts.OrderByDescending(p => p).Include(p => p.Item).Where(c => c.Orderer.Email == User.Identity.Name).ToList();
                return View(list);
            }
        }
        //Добавление в корзину
        public IActionResult AddCart(int id)
        {
            var product = _context.Cars.FirstOrDefault(p => p.Id == id);
            string email = User.Identity.Name;
            var orderer = _context.Users.Where(p => p.Email == email).FirstOrDefault();
            if (_context.Carts.Any(p => p.Item.Id == product.Id))
            {
                var x = _context.Carts.Where(p => p.Item.Id == id).FirstOrDefault();
                x.Caunt++;
                _context.Entry(x).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            _context.Carts.Add(new Cart { Item = product, Caunt = 1, Orderer = orderer});
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CartList()
        {
            var cartList = await _context.Carts.Include(u => u.Item).ToListAsync();
            return View(cartList);
        }
        //Удаление из корзины
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Carts.FirstAsync(p => p.Id == id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult OrderVerification()
        {
            return View();
        }
    }
}