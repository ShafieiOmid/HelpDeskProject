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
    public class PrintersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Printers
        public ActionResult Index()
        {
            return View(db.Printers.ToList());
        }

        // GET: Printers/Details/5
        public ActionResult Details(Guid? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // GET: Printers/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Printers/Repairs
        public ActionResult Repairs()
        {
            return View();
        }

        // POST: Printers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsActive,HID,PrinterModel,PrinterType,CartdridgeType")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                printer.Id = Guid.NewGuid();
                db.Printers.Add(printer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(printer);
        }

        // GET: Printers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // POST: Printers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsActive,HID,PrinterModel,PrinterType,CartdridgeType")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(printer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(printer);
        }

        // GET: Printers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Printer printer = db.Printers.Find(id);
            if (printer == null)
            {
                return HttpNotFound();
            }
            return View(printer);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Printer printer = db.Printers.Find(id);
            db.Printers.Remove(printer);
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
