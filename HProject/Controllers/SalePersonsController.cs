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
    public class SalePersonsController : Controller
    {
        private HCosmeticEntities2 db = new HCosmeticEntities2();

        // GET: SalePersons
        public ActionResult Index()
        {
            var salePersons = db.SalePersons.Include(s => s.Role).Include(s => s.Store);
            return View(salePersons.ToList());
        }

        // GET: SalePersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalePerson salePerson = db.SalePersons.Find(id);
            if (salePerson == null)
            {
                return HttpNotFound();
            }
            return View(salePerson);
        }

        // GET: SalePersons/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: SalePersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalePersonId,SalePersonName,SalePersonPhone,RoleId,UserId,Password,StoreId")] SalePerson salePerson)
        {
            if (ModelState.IsValid)
            {
                db.SalePersons.Add(salePerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", salePerson.RoleId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", salePerson.StoreId);
            return View(salePerson);
        }

        // GET: SalePersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalePerson salePerson = db.SalePersons.Find(id);
            if (salePerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", salePerson.RoleId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", salePerson.StoreId);
            return View(salePerson);
        }

        // POST: SalePersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalePersonId,SalePersonName,SalePersonPhone,RoleId,UserId,Password,StoreId")] SalePerson salePerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salePerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", salePerson.RoleId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", salePerson.StoreId);
            return View(salePerson);
        }

        // GET: SalePersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalePerson salePerson = db.SalePersons.Find(id);
            if (salePerson == null)
            {
                return HttpNotFound();
            }
            return View(salePerson);
        }

        // POST: SalePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalePerson salePerson = db.SalePersons.Find(id);
            db.SalePersons.Remove(salePerson);
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
