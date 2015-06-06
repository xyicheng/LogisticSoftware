using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;

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
        }
    }
}