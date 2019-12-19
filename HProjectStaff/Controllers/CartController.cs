using HProjectStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HProjectStaff.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int ProductId, FormCollection form)
        {
            int UnitsInOrder = 1;

            string unitsinorder = Request.Form["abc"];

            if (String.IsNullOrEmpty(unitsinorder) == false)
            {
                UnitsInOrder = Int32.Parse(unitsinorder);
            }
            //int UnitsInOrder = Convert.ToInt32(unitsinorder);
            ShoppingCart.Cart.Add(ProductId, UnitsInOrder);
            return RedirectToAction("CreateOrder", "Orders");
        }
        public ActionResult Clear()
        {
            ShoppingCart.Cart.Clear();
            return RedirectToAction("CreateOrder", "Orders");
        }
        public ActionResult Remove(int ProductId)
        {
            ShoppingCart.Cart.Remove(ProductId);
            return RedirectToAction("CreateOrder", "Orders");
        }
        public ActionResult Update()
        {
            foreach (var p in ShoppingCart.Cart.Items)
            {
                var txtName = p.ProductId.ToString();
                var qty = int.Parse(Request[txtName]);
                ShoppingCart.Cart.Update(p.ProductId, qty);
            }
            return RedirectToAction("CreateOrder", "Orders");
        }
    }
}