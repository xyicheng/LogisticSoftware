using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LogisticsSolver.Distance;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities;
using Ninject.Infrastructure.Language;

namespace LogisticSoftware.WebUI.Controllers
{
    [Authorize]
    public class SuppliesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: Supplies
        public ActionResult Index()
        {
            return View(db.Supplies.ToList());
        }

        // GET: Supplies/Route/5
        public ActionResult Route(int? id)
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

        public ActionResult Generate(int? id)
        {
            

            Supply supply = db.Supplies.Find(id);
            var response = GoogleDistanseMatrixFinder
                .GetDistanseMatrix(supply
                .PlacesOnTheRoute
                .Select(p => new Tuple<double,double,int> ( p.Place.Latitude, p.Place.Longitude,p.PlaceId))
                .ToArray());



            supply.IsGenerated = true;
            db.Entry(supply).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Route", "Supplies", new { id = supply.SupplyId });
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplyId,Target,Date")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index", "PlaceOnTheRoutes", new { id = supply.SupplyId });
            }

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
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplyId,Target,Date")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
