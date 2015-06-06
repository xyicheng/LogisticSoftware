using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web.UI.WebControls;
using LogisticSoftware.WebUI.Models.Entities;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Models
{
    public class LogisticsDbContext : DbContext
    {

        public LogisticsDbContext() : base("LogisticsDb")
        {
            Database.SetInitializer(new LogisticsDbInitializer());
        }

        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        
        public DbSet<MapPoint> MapPoints { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Granary> Granaries { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            

        }

    }

    public class LogisticsDbInitializer : DropCreateDatabaseAlways<LogisticsDbContext>
    {
        protected override void Seed(LogisticsDbContext context)
        {
            var fuelType = new FuelType() {FuelName = "Дизельне паливо"};
            context.FuelTypes.Add(fuelType);
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-80" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-92" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Бензин А-95" });
            context.FuelTypes.Add(new FuelType() { FuelName = "Зріджений газ" });
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



            var driver = new Driver
            {
                DateOfBirth = new DateTime(1994, 6, 2),
                Name = "Іванов І.І.",
            };
            context.Drivers.Add(driver);

            driver = new Driver
            {
                DateOfBirth = new DateTime(1986, 7, 2),
                Name = "Сергієв С.І.",
            };
            context.Drivers.Add(driver);

            var garage = new Garage()
            {
                PlaceName = "Гараж №1",
                Address = "м. Черкаси, вул. Хрещатик 64",
                Latitude = 49.45445,
                Longitude = 32.044730,
            };
            context.Garages.Add(garage);

            var factory = new Factory()
            {
                PlaceName = "Фабрика №1",
                Address = "м. Черкаси, пр. Хіміків 32",
                Latitude = 49.401511,
                Longitude = 32.053967,
            };
            context.Factories.Add(factory);

            var supplier = new Supplier()
            {
                PlaceName = "Постачальник №1",
                Address = "м. Черкаси, пр. Хіміків 32",
                Latitude = 49.401511,
                Longitude = 32.053967,
            };
            context.Suppliers.Add(supplier);

            var customer = new Customer()
            {
                PlaceName = "Клієнт №1",
                Address = "м. Черкаси, пр. Хіміків 32",
                Latitude = 49.401511,
                Longitude = 32.053967,
            };
            context.Customers.Add(customer);

            var vehicle = new Vehicle()
            {
                Driver = driver,
                FuelType = fuelType,
                Garage = garage,
                LastInspection = new DateTime(2014, 3, 12),
                ModelName = "Рено FH30",
                RegistrationNumber = "АН3256ЕН",
                WeightCapacity = 25000,
                TrunkSize = 60000
            };
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
            var supply = new Supply()
            {
                Target = "Перевезення товару з фабрики клієнту",
                Date = DateTime.Now
            };
            context.Supplies.Add(supply);

            supply.MapPointsOnRoute = new HashSet<MapPointOnRoute>
            {
                new MapPointOnRoute()
                {
                    MapPoint = garage,
                    PointNumber = 0
                },
                new MapPointOnRoute()
                {
                    MapPoint = factory,
                    PointNumber = 1
                },
                new MapPointOnRoute()
                {
                    MapPoint = customer,
                    PointNumber = 2
                },
                new MapPointOnRoute()
                {
                    MapPoint = garage,
                    PointNumber = 3
                }
            };


            base.Seed(context);
        }
    }
}