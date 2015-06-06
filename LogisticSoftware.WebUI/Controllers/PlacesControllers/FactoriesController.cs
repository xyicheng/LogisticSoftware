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
        private LogisticsDbContext db = new LogisticsDbContext();

        public FactoriesController()
        {
            PlacesTable = db.Factories;
            IndexTitle = "Виробничі потужності";
            CreateString = "Додати виробничу потужність";
            DatailsTitle = "Виробнича потужність";
            EditTitle = "Редагувати виробничу потужність";
        }
    }
}
