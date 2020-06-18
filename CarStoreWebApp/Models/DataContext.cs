using Microsoft.AspNetCore.SignalR.Protocol;
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
        public DbSet<Status> Statuses { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //Добавляю статус машины
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
            //Добавляю роль админа и пользователя
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
            model.Entity<Role>().HasData(
                roleAdmin,
                roleUser
                );

            //Добавляю категорию машины
            model.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                Name = "Tesla"
            },
             new Category()
             {
                 Id = 2,
                 Name = "Mercedes"
             },
            new Category()
            {
                Id = 3,
                Name = "BMW"
            },
            new Category()
            {
                Id = 4,
                Name = "Lada"
            });
            //Добавляю модель машины
            model.Entity<Model>().HasData(
           new Model()
           {
               Id = 1,
               Name = "Легковая"
           },
            new Model()
            {
                Id = 2,
                Name = "Грузовая"
            },
           new Model()
           {
               Id = 3,
               Name = "Электрический"
           });
          
        }


    }
}
