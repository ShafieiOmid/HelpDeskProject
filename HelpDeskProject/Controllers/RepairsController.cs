using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpDeskProject.Models;

namespace HelpDeskProject.Controllers
{
    public class RepairsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Repairs
        public ActionResult Index()
        {
            return View(db.Repairs.ToList());
        }

        // GET: Repairs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModel repairModel = db.Repairs.Find(id);
            if (repairModel == null)
            {
                return HttpNotFound();
            }
            return View(repairModel);
        }

        // GET: Repairs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HasCost,HasReplaced,HID,PID,Model,Category,ReceiptID,CommitTime")] RepairModel repairModel)
        {
            if (ModelState.IsValid)
            {
                repairModel.CommitTime = DateTime.Now;
                repairModel.Id = Guid.NewGuid();
                db.Repairs.Add(repairModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairModel);
        }

        // GET: Repairs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModel repairModel = db.Repairs.Find(id);
            if (repairModel == null)
            {
                return HttpNotFound();
            }
            return View(repairModel);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HasCost,HasReplaced,HID,PID,Model,Category,ReceiptID,CommitTime")] RepairModel repairModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairModel);
        }

        // GET: Repairs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModel repairModel = db.Repairs.Find(id);
            if (repairModel == null)
            {
                return HttpNotFound();
            }
            return View(repairModel);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RepairModel repairModel = db.Repairs.Find(id);
            db.Repairs.Remove(repairModel);
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
