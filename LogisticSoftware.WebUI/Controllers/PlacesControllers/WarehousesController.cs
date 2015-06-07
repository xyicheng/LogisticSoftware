using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class WarehousesController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public WarehousesController()
        {
            PlacesTable = _db.Warehouses;
            IndexTitle = "Склади";
            CreateString = "Додати склад";
            DatailsTitle = "Склад";
            EditTitle = "Редагувати склад";

            DeleteTitle = "Видалити склад";
            DeleteConfirmation = "Ви впевені, що хочете видалити склад?";
            CreateTitle = "Додати склад";

            PlaceAdderEvent += delegate (Place place) {
                PlacesTable.Add(new Warehouse
                {
                    PlaceId = place.PlaceId,
                    PlaceName = place.PlaceName,
                    Address = place.Address,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude
                });
                _db.SaveChanges();
            };

            PlaceRemoverEvent += delegate (Place place) {
                var garage = PlacesTable.Find(place.PlaceId);
                PlacesTable.Remove(garage);
                _db.SaveChanges();
            };
        }
    }
}
