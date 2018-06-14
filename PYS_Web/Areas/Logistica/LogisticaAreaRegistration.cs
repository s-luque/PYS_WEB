using System.Web.Mvc;

namespace PYS_Web.Areas.Logistica
{
    public class LogisticaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Logistica";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Logistica_default",
                "Logistica/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.Logistica.Controllers" }

            );
        }
    }
}