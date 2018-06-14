using System.Web.Mvc;

namespace PYS_Web.Areas.Aprobaciones
{
    public class AprobacionesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Aprobaciones";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Aprobaciones_default",
                "Aprobaciones/{controller}/{action}/{id}",
                new { controller="Home",action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.Aprobaciones.Controllers" }
            );
        }
    }
}