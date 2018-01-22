using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpDeskProject.Models;
using HelpDeskProject.Models.Devices.Printer;

namespace HelpDeskProject.Controllers
{
    public class CartridgesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Cartridges
        public ActionResult Index()
        {
            return View(db.Cartridges.ToList());
        }

        // GET: Cartridges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            return View(cartridge);
        }

        // GET: Cartridges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cartridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsActive,DrumReplaced,MaggnetReplaced,BladeReplaced,FoamReplaced,TankReplaced,CID,PrinterModel,CartridgeModel,DeliverTime,CommitTime")] Cartridge cartridge)
        {
            if (ModelState.IsValid)
            {
                cartridge.CommitTime = DateTime.Now;
                cartridge.Id = Guid.NewGuid();
                db.Cartridges.Add(cartridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartridge);
        }

        // GET: Cartridges/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            return View(cartridge);
        }

        // POST: Cartridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsActive,DrumReplaced,MaggnetReplaced,BladeReplaced,FoamReplaced,TankReplaced,CID,PrinterModel,CartridgeModel,DeliverTime,CommitTime")] Cartridge cartridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartridge);
        }

        // GET: Cartridges/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartridge cartridge = db.Cartridges.Find(id);
            if (cartridge == null)
            {
                return HttpNotFound();
            }
            return View(cartridge);
        }

        // POST: Cartridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cartridge cartridge = db.Cartridges.Find(id);
            db.Cartridges.Remove(cartridge);
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
