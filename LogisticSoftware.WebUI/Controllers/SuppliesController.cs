using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities;

namespace LogisticSoftware.WebUI.Controllers
{
    public class SuppliesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies;
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.FromPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            ViewBag.ToPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyId,Cost,Date,VehicleId,FromPlaceId,ToPlaceId")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", supply.VehicleId);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", supply.VehicleId);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplyId,Cost,Date,VehicleId,FromPlaceId,ToPlaceId")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", supply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", supply.VehicleId);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supply supply = db.Supplies.Find(id);
            db.Supplies.Remove(supply);
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
