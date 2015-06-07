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
    public class MapPointOnRoutesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: MapPointOnRoutes
        public ActionResult Index(int? id)
        {
            ViewBag.SupplyId = id;
            return View(db.MapPointOnRoutes.Where(mp => mp.SupplyId == id).ToList());
        }

        // GET: MapPointOnRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPointOnRoute mapPointOnRoute = db.MapPointOnRoutes.Find(id);
            if (mapPointOnRoute == null)
            {
                return HttpNotFound();
            }
            return View(mapPointOnRoute);
        }

        // GET: MapPointOnRoutes/Create
        public ActionResult Create(int? id)
        {
            ViewBag.SupplyId = id;
            return View();
        }

        // POST: MapPointOnRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyId,PointNumber")] MapPointOnRoute mapPointOnRoute)
        {
            if (ModelState.IsValid)
            {
                db.MapPointOnRoutes.Add(mapPointOnRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapPointOnRoute);
        }

        // GET: MapPointOnRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPointOnRoute mapPointOnRoute = db.MapPointOnRoutes.Find(id);
            if (mapPointOnRoute == null)
            {
                return HttpNotFound();
            }
            return View(mapPointOnRoute);
        }

        // POST: MapPointOnRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapPointOnRouteId,SupplyId,PointNumber")] MapPointOnRoute mapPointOnRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapPointOnRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapPointOnRoute);
        }

        // GET: MapPointOnRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapPointOnRoute mapPointOnRoute = db.MapPointOnRoutes.Find(id);
            if (mapPointOnRoute == null)
            {
                return HttpNotFound();
            }
            return View(mapPointOnRoute);
        }

        // POST: MapPointOnRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapPointOnRoute mapPointOnRoute = db.MapPointOnRoutes.Find(id);
            db.MapPointOnRoutes.Remove(mapPointOnRoute);
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
