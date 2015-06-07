using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    [Authorize]
    public class SuppliersController : PlacesController
    {
        private LogisticsDbContext _db = new LogisticsDbContext();

        public SuppliersController()
        {
            PlacesTable = _db.Suppliers;
            IndexTitle = "Постачальники";
            CreateString = "Додати постачальника";
            DatailsTitle = "Постачальник";
            EditTitle = "Редагувати постачальника";

            DeleteTitle = "Видалити постачальника";
            DeleteConfirmation = "Ви впевені, що хочете видалити постачальника?";
            CreateTitle = "Додати постачальника";

            PlaceAdderEvent += delegate (Place place) {
                PlacesTable.Add(new Supplier
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
