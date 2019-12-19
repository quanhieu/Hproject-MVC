using HProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HProject.Controllers
{
    public class BaseController : Controller
    {
        protected HCosmeticEntities2 dbc = new HCosmeticEntities2();
        // GET: Base
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}