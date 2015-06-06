using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class GranariesController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public GranariesController()
        {
            PlacesTable = _db.Granaries;
            IndexTitle = "Зерносховища";
            CreateString = "Додати зерносховище";
            DatailsTitle = "Зерносховище";
            EditTitle = "Редагувати зерносховище";

            DeleteTitle = "Видалити зерносховище";
            DeleteConfirmation = "Ви впевені, що хочете видалити зерносховище?";
            CreateTitle = "Додати зерносховище";

            PlaceAdderEvent += delegate (Place place) {
                PlacesTable.Add(new Granary
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