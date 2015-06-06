﻿using System.Data.Entity;
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
        private LogisticsDbContext db = new LogisticsDbContext();

        public SuppliersController()
        {
            PlacesTable = db.Suppliers;
            IndexTitle = "Постачальники";
            CreateString = "Додати постачальника";
            DatailsTitle = "Постачальник";
            EditTitle = "Редагувати постачальника";
        }
    }
}
