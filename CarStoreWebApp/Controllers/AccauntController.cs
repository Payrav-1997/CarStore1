using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CarStoreWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreWebApp.Controllers
{
    public class AccauntController : Controller
    {
        DataContext context;
        public AccauntController(DataContext context)
        {
            this.context = context;
        }
        ///Для входа в акаунт
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if(ModelState.IsValid)
            {
                model.Password = HashingPassword(model.Password);
                User user = await context.Users.Include(t=>t.Role).FirstOrDefaultAsync(t => t.Email == model.Email && t.Password == model.Password);
                if(user != null)
                {
                    await Authenticate(user.Email,user.Role.Name);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Логин или пароль не корректный!");
            }         
            return View(model);
        }
        //Для регистрации
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                model.Password = HashingPassword(model.Password);
                User user = await context.Users.Include(t => t.Role).FirstOrDefaultAsync(t => t.Email == model.Email);
                if (user == null)
                {

                    var role = context.Roles.First(t => t.Name == "User");
                    context.Users.Add(new User()
                    {
                        
                        Email = model.Email,
                        Password = model.Password,
                        Role = role
                    });
                    await context.SaveChangesAsync();
                    await Authenticate(model.Email, role.Name);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Логин или пароль не корректный!");
            }
            return View(model);
        }
        //Для хеширование
        static public string HashingPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            return Convert.ToBase64String(md5data);
        }
        public async Task Authenticate(string email,string role)
        {
            List<Claim> list = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            ClaimsIdentity id = new ClaimsIdentity(list, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(id));
        }
        //Для выхода 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}