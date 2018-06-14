﻿using System.Web.Mvc;

namespace PYS_Web.Areas.Ventas
{
    public class VentasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ventas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ventas_default",
                "Ventas/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.Ventas.Controllers" }
            );
        }
    }
}