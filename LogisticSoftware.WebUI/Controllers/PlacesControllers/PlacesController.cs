using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities.Places;

namespace LogisticSoftware.WebUI.Controllers.PlacesControllers
{
    public class PlacesController : Controller
    {
        private static LogisticsDbContext db = new LogisticsDbContext();

        private const string IndexUrl = "~/Views/Shared/Places/Index.cshtml";
        private const string DetailsUrl = "~/Views/Shared/Places/Details.cshtml";
        private const string EditUrl = "~/Views/Shared/Places/Edit.cshtml";
        protected string IndexTitle = "Місця";
        protected string CreateString = "Додати місце";
        protected string DatailsTitle = "Місце";
        protected string EditTitle = "Редагувати місце";

        protected DbSet PlacesTable = db.Places;

        // GET: Places
        public ActionResult Index()
        {
            ViewBag.Title = IndexTitle;
            ViewBag.CreateString = CreateString;
            return View(IndexUrl, ((IQueryable<Place>)PlacesTable).ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = (Place)PlacesTable.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = DatailsTitle;
            return View(DetailsUrl,place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceId,PlaceName,Address,Latitude,Longitude")] Place place)
        {
            if (ModelState.IsValid)
            {
                PlacesTable.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = (Place)PlacesTable.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = EditTitle;
            return View(EditUrl,place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceId,PlaceName,Address,Latitude,Longitude")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Title = EditTitle;
            return View(EditUrl,place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = (Place)PlacesTable.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            PlacesTable.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
