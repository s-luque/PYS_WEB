using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PYS_Web.Areas.Aprobaciones.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Aprobaciones/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}