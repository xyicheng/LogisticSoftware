using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class WarehousesController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public WarehousesController()
        {
            PlacesTable = _db.Warehouses;
            IndexTitle = "Склади";
            CreateString = "Додати склад";
            DatailsTitle = "Склад";
            EditTitle = "Редагувати склад";
        }
    }
}
