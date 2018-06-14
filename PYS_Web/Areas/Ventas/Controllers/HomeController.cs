using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PYS_Web.Areas.Ventas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ventas/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}