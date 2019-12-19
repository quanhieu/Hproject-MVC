using HProjectStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HProjectStaff.Controllers
{
    public class AccountController : Controller
    {
        private HCosmeticEntities db = new HCosmeticEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String UserId, String Password)
        {
            try
            {
                var user = db.SalePersons.Single(s => s.UserId == UserId && s.Password == Password);
                Session["User"] = user;
            }
            catch
            {
                ModelState.AddModelError("", "Email or password has wrong!");
                return View();
            }
            return RedirectToAction("CreateOrder", "Orders");
        }
        public ActionResult Logout()
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
            else
            {
                ModelState.AddModelError("", "You have not logged in yet");
            }
            return RedirectToAction("Index","Home");
        }
    }
}