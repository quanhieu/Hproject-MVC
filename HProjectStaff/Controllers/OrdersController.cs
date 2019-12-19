using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HProjectStaff.Models;

namespace HProjectStaff.Controllers
{
    public class OrdersController : Controller
    {
        private HCosmeticEntities db = new HCosmeticEntities();

        #region MyCode
        public ActionResult CreateOrder(string searchString)
        {
            ViewBag.Products = db.Products.ToList();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Products = db.Products.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrder(Order model)
        {
            if (ShoppingCart.Cart.Items.Count() > 0)
            {
                try
                {
                    var user = Session["User"] as HProjectStaff.Models.SalePerson;
                    model.SalePersonId = user.SalePersonId;
                    model.StoreId = user.StoreId;
                    db.Orders.Add(model);
                    db.SaveChanges();
                    foreach (var item in ShoppingCart.Cart.Items)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderId = model.OrderId;
                        od.ProductId = item.ProductId;
                        od.Quantity = item.UnitsInOrder;
                        od.Price = item.Price;
                        db.OrderDetails.Add(od);
                    }
                    db.SaveChanges();
                    ShoppingCart.Cart.Clear();
                    ModelState.Clear();
                    ModelState.AddModelError("", "SUBMITED");
                }
                catch
                {
                    ModelState.AddModelError("", "Errors");
                }

                ViewBag.Products = db.Products.ToList();
            }
            else
            {

                ModelState.AddModelError("", "There are 0 item in your SHOPPING CART");
                return RedirectToAction("CreateOrder", "Orders");
            }
            return View();
        }
        #endregion

        #region Scaffolding



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
        #endregion
    }
}
