using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    [Authorize]
    public class GaragesController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public GaragesController()
        {
            PlacesTable = _db.Garages;
            IndexTitle = "Гаражі";
            CreateString = "Додати гараж";
            DatailsTitle = "Гараж";
            EditTitle = "Редагувати гараж";

            DeleteTitle = "Видалити гараж";
            DeleteConfirmation = "Ви впевені, що хочете видалити гараж?";
            CreateTitle = "Додати гараж";

            PlaceAdderEvent += delegate(Place place) {
                PlacesTable.Add(new Garage
                {
                    MapPointId = place.MapPointId,
                    PlaceName = place.PlaceName,
                    Address = place.Address,
                    Latitude = place.Latitude,
                    Longitude = place.Longitude
                });
                _db.SaveChanges();
            };

            PlaceRemoverEvent += delegate(Place place) {
                var garage = PlacesTable.Find(place.MapPointId);
                PlacesTable.Remove(garage);
                _db.SaveChanges();
            };
        }

        
    }
}
