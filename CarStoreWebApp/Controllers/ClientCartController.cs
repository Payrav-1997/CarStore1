﻿using System;
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

        public async Task<IActionResult> AddCart(int id)
        {
            var product = await _context.Cars.FirstOrDefaultAsync(p => p.Id == id);



            _context.Carts.Add(new Cart { Item = product.Id });
            await _context.SaveChangesAsync();

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> CartList()
        {
            var cartList = await _context.Carts.ToListAsync();
            foreach (var cartProduct in cartList)
            {
                cartProduct.Cars = await _context.Cars.Where(p => p.Id == cartProduct.carId).ToListAsync();
            }
            return View(cartList);
        }
    }
}