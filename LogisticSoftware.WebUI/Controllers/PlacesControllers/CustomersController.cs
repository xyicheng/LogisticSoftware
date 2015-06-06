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
        private LogisticsDbContext db = new LogisticsDbContext();

        public CustomersController()
        {
            PlacesTable = db.Customers;
            IndexTitle = "Клієнти";
            CreateString = "Додати клієнта";
            DatailsTitle = "Клієнт";
            EditTitle = "Редагувати клієнта";
        }
    }
}
