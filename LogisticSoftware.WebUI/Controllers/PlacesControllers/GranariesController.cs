using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class GranariesController : PlacesController
    {
        private readonly LogisticsDbContext _db = new LogisticsDbContext();

        public GranariesController()
        {
            PlacesTable = _db.Granaries;
            IndexTitle = "Зерносховища";
            CreateString = "Додати зерносховище";
            DatailsTitle = "Зерносховище";
            EditTitle = "Редагувати зерносховище";
        }
    }
}