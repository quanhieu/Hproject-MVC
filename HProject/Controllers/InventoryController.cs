using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HProject.Models;

namespace HProject.Controllers
{
    public class InventoryController : BaseController
    {
        // GET: Inventory
        //public ActionResult ByMonth()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Order.OrderDate.Month)
        //        .ToList()
        //        .Select(g => new Inventory
        //        {
        //            Group = g.Key.ToString(),
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity),
        //            Min = g.Min(d => d.Price),
        //            Max = g.Max(d => d.Price),
        //            Avg = g.Average(d => d.Price)


        //        });
        //    ViewBag.Group = "Month";
        //    return View("Inventory", model);
        //}


        //public ActionResult ByProduct()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Product)
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.Name,
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Product";
        //    return View("ByProduct", model);
        //}
        //public ActionResult ByCategory()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Product.Category)
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.Name,
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Category";
        //    return View("Revenue", model);
        //}
        //public ActionResult BySupplier()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Product.Supplier)
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.Name,
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Supplier";
        //    return View("Revenue", model);
        //}
        //public ActionResult ByCustomer()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Order.Customer)
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.Id,
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Customer";
        //    return View("Revenue", model);
        //}
        //public ActionResult ByYear()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => d.Order.OrderDate.Year)
        //        .ToList()
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.ToString(),
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Year";
        //    return View("Revenue", model);
        //}
        //public ActionResult ByQuarter()
        //{
        //    var model = dbc.OrderDetails
        //        .GroupBy(d => Math.Ceiling(d.Order.OrderDate.Month / 3.0))
        //        .ToList()
        //        .Select(g => new Revenue
        //        {
        //            Group = g.Key.ToString(),
        //            Count = g.Sum(d => d.Quantity),
        //            Sum = g.Sum(d => d.Quantity * d.Quantity * (1 - d.Discount)),
        //            Min = g.Min(d => d.UnitPrice),
        //            Max = g.Max(d => d.UnitPrice),
        //            Avg = g.Average(d => d.UnitPrice)
        //        });
        //    ViewBag.Group = "Quarter";
        //    return View("Revenue", model);
        //}


    }
}

//<li><a href = "@Url.Action("ByMonth", "Inventory")">Theo từng tháng</a></li>
///Inventory/ByMonth/Inventory