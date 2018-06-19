using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapstoneDraft.Models;
using PrsEf;

namespace CapstoneDraft.Controllers
{
    public class PurchaseRequestLineitemsController : Controller
    {
        private CapstoneControllerContext db = new CapstoneControllerContext();

        // GET: PurchaseRequestLineitems
        public ActionResult Index()
        {
            var purchaseRequestLineitems = db.PurchaseRequestLineitems.Include(p => p.Product).Include(p => p.PurchaseRequest);
            return View(purchaseRequestLineitems.ToList());
        }

        // GET: PurchaseRequestLineitems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineitem purchaseRequestLineitem = db.PurchaseRequestLineitems.Find(id);
            if (purchaseRequestLineitem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineitem);
        }

        // GET: PurchaseRequestLineitems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "PartNumber");
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description");
            return View();
        }

        // POST: PurchaseRequestLineitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Quantity,ProductId,PurchaseRequestId")] PurchaseRequestLineitem purchaseRequestLineitem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequestLineitems.Add(purchaseRequestLineitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "PartNumber", purchaseRequestLineitem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineitem.PurchaseRequestId);
            return View(purchaseRequestLineitem);
        }

        // GET: PurchaseRequestLineitems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineitem purchaseRequestLineitem = db.PurchaseRequestLineitems.Find(id);
            if (purchaseRequestLineitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "PartNumber", purchaseRequestLineitem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineitem.PurchaseRequestId);
            return View(purchaseRequestLineitem);
        }

        // POST: PurchaseRequestLineitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Quantity,ProductId,PurchaseRequestId")] PurchaseRequestLineitem purchaseRequestLineitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequestLineitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "PartNumber", purchaseRequestLineitem.ProductId);
            ViewBag.PurchaseRequestId = new SelectList(db.PurchaseRequests, "Id", "Description", purchaseRequestLineitem.PurchaseRequestId);
            return View(purchaseRequestLineitem);
        }

        // GET: PurchaseRequestLineitems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineitem purchaseRequestLineitem = db.PurchaseRequestLineitems.Find(id);
            if (purchaseRequestLineitem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineitem);
        }

        // POST: PurchaseRequestLineitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequestLineitem purchaseRequestLineitem = db.PurchaseRequestLineitems.Find(id);
            db.PurchaseRequestLineitems.Remove(purchaseRequestLineitem);
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
