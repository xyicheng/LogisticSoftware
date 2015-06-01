﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using LogisticSoftware.WebUI.Models.Entities;

namespace LogisticSoftware.WebUI.Models
{
    public class LogisticsDbContext : DbContext
    {

        public LogisticsDbContext () : base("LogisticsDb")
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemInSupply> ItemsInSupplies { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }

    public class BookDbInitializer : DropCreateDatabaseAlways<LogisticsDbContext>
    {
        protected override void Seed(LogisticsDbContext context)
        {
            context.Users.Add(new User()
            {
                Login = "admin",
                Name = "Суховий О. І.",
                Password = "secret"
            });
            context.Users.Add(new User()
            {
                Login = "user1",
                Name = "Іванов І. І.",
                Password = "secret"
            });
            var cat = new Category() { CategoryName = "С" };
            context.Categories.Add(cat);
            context.SaveChanges();
            var driver = new Driver
            {
                DateOfBirth = new DateTime(1994, 6, 2),
                MobilePhone = "0935703236",
                FirstName = "Максим",
                LastName = "Свідерський",
                MiddleName = "Юрійович",
                Categories = new List<Category> { cat },
            };
            context.Drivers.Add(driver);

            context.FuelTypes.Add(new FuelType() { FuelName = "Дизельне паливо" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-80" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-92" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-95" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Зріджений газ" });

            context.Categories.Add(new Category() { CategoryName = "А1" });
            context.Categories.Add(new Category() { CategoryName = "А" });
            context.Categories.Add(new Category() { CategoryName = "B1" });
            context.Categories.Add(new Category() { CategoryName = "B" });
            context.Categories.Add(new Category() { CategoryName = "ВЕ" });
            context.Categories.Add(new Category() { CategoryName = "C1" });
            context.Categories.Add(new Category() { CategoryName = "С1Е" });
            context.Categories.Add(new Category() { CategoryName = "C" });
            context.Categories.Add(new Category() { CategoryName = "СЕ" });
            context.Categories.Add(new Category() { CategoryName = "D1" });
            context.Categories.Add(new Category() { CategoryName = "D1E" });
            context.Categories.Add(new Category() { CategoryName = "D" });   
            context.Categories.Add(new Category() { CategoryName = "DE" });

            base.Seed(context);
        }
    }
}