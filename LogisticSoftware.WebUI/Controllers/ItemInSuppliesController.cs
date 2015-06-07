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
    public class ItemInSuppliesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: ItemInSupplies
        public ActionResult Index()
        {
            var itemsInSupplies = db.ItemsInSupplies.Include(i => i.From).Include(i => i.To).Include(i => i.Vehicle);
            return View(itemsInSupplies.ToList());
        }

        // GET: ItemInSupplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInSupply itemInSupply = db.ItemsInSupplies.Find(id);
            if (itemInSupply == null)
            {
                return HttpNotFound();
            }
            return View(itemInSupply);
        }

        // GET: ItemInSupplies/Create
        public ActionResult Create()
        {
            ViewBag.FromPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName");
            ViewBag.ToPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: ItemInSupplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemInSupplyId,ItemName,ItemsQuantityInPack,SingleItemWeight,NumberOfPackages,FromPlaceId,ToPlaceId,VehicleId")] ItemInSupply itemInSupply)
        {
            if (ModelState.IsValid)
            {
                db.ItemsInSupplies.Add(itemInSupply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", itemInSupply.VehicleId);
            return View(itemInSupply);
        }

        // GET: ItemInSupplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInSupply itemInSupply = db.ItemsInSupplies.Find(id);
            if (itemInSupply == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", itemInSupply.VehicleId);
            return View(itemInSupply);
        }

        // POST: ItemInSupplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemInSupplyId,ItemName,ItemsQuantityInPack,SingleItemWeight,NumberOfPackages,FromPlaceId,ToPlaceId,VehicleId")] ItemInSupply itemInSupply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemInSupply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.FromPlaceId);
            ViewBag.ToPlaceId = new SelectList(db.PlacesOnTheRoutes, "PlaceOnTheRouteId", "PlaceName", itemInSupply.ToPlaceId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "RegistrationNumber", itemInSupply.VehicleId);
            return View(itemInSupply);
        }

        // GET: ItemInSupplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemInSupply itemInSupply = db.ItemsInSupplies.Find(id);
            if (itemInSupply == null)
            {
                return HttpNotFound();
            }
            return View(itemInSupply);
        }

        // POST: ItemInSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemInSupply itemInSupply = db.ItemsInSupplies.Find(id);
            db.ItemsInSupplies.Remove(itemInSupply);
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
