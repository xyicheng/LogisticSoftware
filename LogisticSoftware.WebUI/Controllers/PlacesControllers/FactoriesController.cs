using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    [Authorize]
    public class FactoriesController : PlacesController
    {
        private LogisticsDbContext _db = new LogisticsDbContext();

        public FactoriesController()
        {
            PlacesTable = _db.Factories;
            IndexTitle = "Виробничі потужності";
            CreateString = "Додати виробничу потужність";
            DatailsTitle = "Виробнича потужність";
            EditTitle = "Редагувати виробничу потужність";

            DeleteTitle = "Видалити виробничу потужність";
            DeleteConfirmation = "Ви впевені, що хочете видалити виробничу потужність?";
            CreateTitle = "Додати виробничу потужність";

            PlaceAdderEvent += delegate (Place place) {
                PlacesTable.Add(new Factory
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
