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
    public abstract class PlacesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        private const string IndexUrl = "~/Views/Shared/Places/Index.cshtml";
        private const string DetailsUrl = "~/Views/Shared/Places/Details.cshtml";
        private const string EditUrl = "~/Views/Shared/Places/Edit.cshtml";
        private const string CreateUrl = "~/Views/Shared/Places/Create.cshtml";
        private const string DeleteUrl = "~/Views/Shared/Places/Delete.cshtml";
        protected string IndexTitle = "Місця";
        protected string CreateString = "Додати місце";
        protected string DatailsTitle = "Місце";
        protected string EditTitle = "Редагувати місце";
        

        protected string DeleteTitle = "Видалити місце";
        protected string DeleteConfirmation = "Ви впевені, що хочете видалити місце?";
        protected string CreateTitle = "Додати місце";

        protected DbSet PlacesTable;

        public delegate void PlaceAdder(Place place);
        public event PlaceAdder PlaceAdderEvent;
        public delegate void PlaceRemover(Place place);
        public event PlaceRemover PlaceRemoverEvent;

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
            ViewBag.Title = CreateTitle;
            return View(CreateUrl);
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapPointId,PlaceName,Address,Latitude,Longitude")] Place place)
        {
            if (ModelState.IsValid)
            {
                PlaceAdderEvent(place);
                return RedirectToAction("Index");
            }
            ViewBag.Title = CreateTitle;
            return View(CreateUrl,place);
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
            ViewBag.Title = DeleteTitle;
            ViewBag.DeleteConfirmation = DeleteConfirmation;
            return View(DeleteUrl,place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var place = (Place)PlacesTable.Find(id);
            PlaceRemoverEvent(place);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
