using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class FarmsController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public FarmsController()
        {
            PlacesTable = _db.Farms;
            IndexTitle = "Ферми";
            CreateString = "Додати ферму";
            DatailsTitle = "Ферма";
            EditTitle = "Редагувати ферму";

            DeleteTitle = "Видалити ферму";
            DeleteConfirmation = "Ви впевені, що хочете видалити ферму?";
            CreateTitle = "Додати ферму";

            PlaceAdderEvent += delegate (Place place) {
                PlacesTable.Add(new Farm()
                {
                    MapPointId = place.MapPointId,
                    PlaceName = place.PlaceName,
                    Address = place.Address,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude
                });
                _db.SaveChanges();
            };

            PlaceRemoverEvent += delegate (Place place) {
                var garage = PlacesTable.Find(place.MapPointId);
                PlacesTable.Remove(garage);
                _db.SaveChanges();
            };
        }
    }
}