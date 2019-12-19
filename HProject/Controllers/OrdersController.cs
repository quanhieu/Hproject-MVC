using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HProject.Models;

namespace HProject.Controllers
{
    public class OrdersController : Controller
    {
        private HCosmeticEntities2 db = new HCosmeticEntities2();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.SalePerson).Include(o => o.Store);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderDetails = order.OrderDetails.ToList();
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.SalePersonId = new SelectList(db.SalePersons, "SalePersonId", "SalePersonName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,CustomerName,CustomerPhone,StoreId,SalePersonId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalePersonId = new SelectList(db.SalePersons, "SalePersonId", "SalePersonName", order.SalePersonId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalePersonId = new SelectList(db.SalePersons, "SalePersonId", "SalePersonName", order.SalePersonId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,CustomerName,CustomerPhone,StoreId,SalePersonId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalePersonId = new SelectList(db.SalePersons, "SalePersonId", "SalePersonName", order.SalePersonId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", order.StoreId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            var orderdetails = order.OrderDetails.ToList();
            foreach (var item in orderdetails)
            {
                db.OrderDetails.Remove(item);
            }
            db.SaveChanges();
            db.Orders.Remove(order);
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
