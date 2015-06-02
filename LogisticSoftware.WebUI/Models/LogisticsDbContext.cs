using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }

    public class BookDbInitializer : DropCreateDatabaseAlways<LogisticsDbContext>
    {
        protected override void Seed(LogisticsDbContext context)
        {
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
            context.SaveChanges();

            context.Users.Add(new User()
            {
                Login = "admin",
                Name = "Петров П.П.",
                Password = "secret"
            });

            context.Users.Add(new User()
            {
                Login = "user1",
                Name = "Іванов І. І.",
                Password = "secret"
            });

            var cat = context.Categories.First(category => category.CategoryName == "C");


            var driver = new Driver
            {
                DateOfBirth = new DateTime(1994, 6, 2),
                Name = "Іванов І.І.",
                Categories = new List<Category> { cat },
            };
            context.Drivers.Add(driver);

            driver = new Driver
            {
                DateOfBirth = new DateTime(1986, 7, 2),
                Name = "Сергієв С.І.",
                Categories = new List<Category> { cat },
            };
            context.Drivers.Add(driver);

            var garage = new Garage()
            {
                PlaceName = "Гараж №1",
                Region = "Черкаська",
                District = "Соснівський",
                City = "Черкаси",
                Street = "Хрещатик",
                NumberOfBuilding = "64",
                Latitude = 49.45445,
                Longitude = 32.044730,
            };
            context.Garages.Add(garage);

            var factory = new Factory()
            {
                PlaceName = "Фабрика №1",
                Region = "Черкаська",
                District = "Придніпровський",
                City = "Черкаси",
                Street = "пр. Хіміків",
                NumberOfBuilding = "32",
                Latitude = 49.401511,
                Longitude = 32.053967,
            };
            context.Factories.Add(factory);

            base.Seed(context);
        }
    }
}