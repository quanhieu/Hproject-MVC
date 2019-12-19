using HProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HProject.Controllers
{
    public class ReportViewController : Controller
    {
        private HCosmeticEntities2 db = new HCosmeticEntities2();
        // GET: ReportView
        // Daily
        public ActionResult Index(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            if (toDate < fromDate)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            //var oRDERs = db.ORDERs.Include(o => o.CUSTOMER).Include(o => o.SALEPERSON).Include(o => o.STOREs).Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            var custOrders = db.Orders.Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();


            return View(custOrders.ToList());
        }

        public ActionResult Bystore(DateTime? fromDate, DateTime? toDate, string StoreList)
        {
            HCosmeticEntities2 db = new HCosmeticEntities2();
            var StoreLocation = db.Stores.ToList();
            SelectList list = new SelectList(StoreLocation, "StoreLocation", "StoreLocation");
            ViewBag.StoreLocation = list;

            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            if (toDate < fromDate)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            var report = db.revenues.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && c.StoreLocation == StoreList).ToList();
            return View(report);
        }

        public ActionResult ByStaff(DateTime? fromDate, DateTime? toDate, string staff)
        {
            HCosmeticEntities2 db = new HCosmeticEntities2();
            var Stafflist = db.SalePersons.ToList();
            SelectList list = new SelectList(Stafflist, "SalePersonName", "SalePersonName");
            ViewBag.staffName = list;

            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            if (toDate < fromDate)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            var report = db.revenues.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && c.SalePersonName == staff).ToList();
            return View(report);
        }

        public ActionResult Bystoreandstaff(DateTime? fromDate, DateTime? toDate, string StoreList, string staff)
        {
            HCosmeticEntities2 db = new HCosmeticEntities2();
            var Storelist = db.Stores.ToList();
            SelectList list = new SelectList(Storelist, "StoreLocation", "StoreLocation");
            ViewBag.StoreName = list;
            var Stafflist = db.SalePersons.ToList();
            SelectList list1 = new SelectList(Stafflist, "SalePersonName", "SalePersonName");
            ViewBag.staffName = list1;

            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            if (toDate < fromDate)
            {
                toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            }

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            var report = db.revenues.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && c.StoreLocation == StoreList && c.SalePersonName == staff).ToList();
            return View(report);
        }


        //Weekly
        public ActionResult Weekly(DateTime? fromDate, DateTime? toDate)
        {
                fromDate = DateTime.Now.AddDays(-7);
                toDate = DateTime.Now;

            //if (toDate < fromDate)
            //{
            //    toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            //}

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            //var oRDERs = db.ORDERs.Include(o => o.CUSTOMER).Include(o => o.SALEPERSON).Include(o => o.STOREs).Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            var custOrders = db.Orders.Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            return View(custOrders.ToList());
        }

        //Month
        public ActionResult Monthly(DateTime? fromDate, DateTime? toDate)
        {
            fromDate = DateTime.Now.AddDays(-30);
            toDate = DateTime.Now;

            //if (toDate < fromDate)
            //{
            //    toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            //}

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            //var oRDERs = db.ORDERs.Include(o => o.CUSTOMER).Include(o => o.SALEPERSON).Include(o => o.STOREs).Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            var custOrders = db.Orders.Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            return View(custOrders.ToList());
        }

        //Year
        public ActionResult Year(DateTime? fromDate, DateTime? toDate)
        {
            fromDate = DateTime.Now.AddDays(-365);
            toDate = DateTime.Now;

            //if (toDate < fromDate)
            //{
            //    toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            //}

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            //var oRDERs = db.ORDERs.Include(o => o.CUSTOMER).Include(o => o.SALEPERSON).Include(o => o.STOREs).Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            var custOrders = db.Orders.Where(c => c.OrderDate >= fromDate && c.OrderDate < toDate).ToList();
            return View(custOrders.ToList());
        }
    }
}