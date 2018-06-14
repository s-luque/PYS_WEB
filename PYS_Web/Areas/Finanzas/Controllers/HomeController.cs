using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PYS_Web.Areas.Finanzas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Finanzas/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}