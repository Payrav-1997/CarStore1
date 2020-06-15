﻿using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreWebApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected virtual void OnModelCreateing(ModelBuilder model)
        {
            model.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "Новый"
                },
                new Status
                {
                    Id = 2,
                    Name = "Б/У"
                });
            string AdminRole = "Admin";
            string UserRole = "User";
            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = AdminRole
            };
            Role roleUser = new Role()
            {
                Id = 2,
                Name = UserRole
            };
            User admin = new User()
            {
                Id = 1,
                Email = "admin@mail.ru",
                Password = HashingPassword("1234"),
                Role = roleAdmin
            };
            model.Entity<Role>().HasData(
                roleAdmin,
                roleUser
                );
            model.Entity<User>().HasData(admin);

        }
        static public string HashingPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            return Convert.ToBase64String(md5data);
        }
    }
}
