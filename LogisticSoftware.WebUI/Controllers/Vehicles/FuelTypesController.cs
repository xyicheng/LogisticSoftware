using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogisticSoftware.WebUI.Models;
using LogisticSoftware.WebUI.Models.Entities;

namespace LogisticSoftware.WebUI.Controllers.Vehicles
{
    public class FuelTypesController : Controller
    {
        private LogisticsDbContext db = new LogisticsDbContext();

        // GET: FuelTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.FuelTypes.ToListAsync());
        }

        // GET: FuelTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuelType = await db.FuelTypes.FindAsync(id);
            if (fuelType == null)
            {
                return HttpNotFound();
            }
            return View(fuelType);
        }

        // GET: FuelTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuelTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FuelTypeId,FuelName")] FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                db.FuelTypes.Add(fuelType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fuelType);
        }

        // GET: FuelTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuelType = await db.FuelTypes.FindAsync(id);
            if (fuelType == null)
            {
                return HttpNotFound();
            }
            return View(fuelType);
        }

        // POST: FuelTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FuelTypeId,FuelName")] FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuelType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fuelType);
        }

        // GET: FuelTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelType fuelType = await db.FuelTypes.FindAsync(id);
            if (fuelType == null)
            {
                return HttpNotFound();
            }
            return View(fuelType);
        }

        // POST: FuelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FuelType fuelType = await db.FuelTypes.FindAsync(id);
            db.FuelTypes.Remove(fuelType);
            await db.SaveChangesAsync();
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
