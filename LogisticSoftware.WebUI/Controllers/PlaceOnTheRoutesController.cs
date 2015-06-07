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

namespace LogisticSoftware.WebUI.Controllers
{
    public class PlaceOnTheRoutesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: PlaceOnTheRoutes
        public ActionResult Index(int? id)
        {
            var supply = db.Supplies.Find(id);
            var placesOnTheRoutes = supply.PlacesOnTheRoute;
            ViewBag.Supply = supply;
            return View(placesOnTheRoutes.ToList());
        }

        // GET: PlaceOnTheRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceOnTheRoute placeOnTheRoute = db.PlacesOnTheRoutes.Find(id);
            if (placeOnTheRoute == null)
            {
                return HttpNotFound();
            }
            return View(placeOnTheRoute);
        }

        // GET: PlaceOnTheRoutes/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            ViewBag.SupplyId = new SelectList(db.Supplies, "SupplyId", "Target");
            return View();
        }

        // POST: PlaceOnTheRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceOnTheRouteId,NumberOnTheRoute,PlaceId,SupplyId")] PlaceOnTheRoute placeOnTheRoute)
        {
            if (ModelState.IsValid)
            {
                db.PlacesOnTheRoutes.Add(placeOnTheRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", placeOnTheRoute.PlaceId);
            ViewBag.SupplyId = new SelectList(db.Supplies, "SupplyId", "Target", placeOnTheRoute.SupplyId);
            return View(placeOnTheRoute);
        }

        // GET: PlaceOnTheRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceOnTheRoute placeOnTheRoute = db.PlacesOnTheRoutes.Find(id);
            if (placeOnTheRoute == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", placeOnTheRoute.PlaceId);
            ViewBag.SupplyId = new SelectList(db.Supplies, "SupplyId", "Target", placeOnTheRoute.SupplyId);
            return View(placeOnTheRoute);
        }

        // POST: PlaceOnTheRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceOnTheRouteId,NumberOnTheRoute,PlaceId,SupplyId")] PlaceOnTheRoute placeOnTheRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeOnTheRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", placeOnTheRoute.PlaceId);
            ViewBag.SupplyId = new SelectList(db.Supplies, "SupplyId", "Target", placeOnTheRoute.SupplyId);
            return View(placeOnTheRoute);
        }

        // GET: PlaceOnTheRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceOnTheRoute placeOnTheRoute = db.PlacesOnTheRoutes.Find(id);
            if (placeOnTheRoute == null)
            {
                return HttpNotFound();
            }
            return View(placeOnTheRoute);
        }

        // POST: PlaceOnTheRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceOnTheRoute placeOnTheRoute = db.PlacesOnTheRoutes.Find(id);
            db.PlacesOnTheRoutes.Remove(placeOnTheRoute);
            db.SaveChanges();
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
