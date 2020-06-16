using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public static class InitialAdmin
    {
        static public void Admin(DataContext context)
        {
            if(!context.Users.Any())
            {
                var role = context.Roles.First(r=>r.Id == 1);
                context.Users.Add(new User()
                {
                    Email= "admin@mail.ru",
                    Password = HashingPassword("1234"),
                    Role = role
                });
                context.SaveChanges();
            }
        }
        //Захеширую пароль
        static public string HashingPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            return Convert.ToBase64String(md5data);
        }
    }
}
