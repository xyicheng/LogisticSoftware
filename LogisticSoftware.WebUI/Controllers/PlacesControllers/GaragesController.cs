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
    }
    }
}
