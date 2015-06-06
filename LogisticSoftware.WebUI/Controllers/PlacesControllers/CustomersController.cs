using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    [Authorize]
    public class CustomersController : PlacesController
    {
        private LogisticsDbContext _db = new LogisticsDbContext();

        public CustomersController()
        {
            PlacesTable = _db.Customers;
            IndexTitle = "Клієнти";
            CreateString = "Додати клієнта";
            DatailsTitle = "Клієнт";
            EditTitle = "Редагувати клієнта";

            DeleteTitle = "Видалити клієнта";
            DeleteConfirmation = "Ви впевені, що хочете видалити клієнта?";
            CreateTitle = "Додати клієнта";

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
