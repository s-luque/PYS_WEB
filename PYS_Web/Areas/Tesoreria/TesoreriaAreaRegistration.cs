using System.Web.Mvc;

namespace PYS_Web.Areas.Tesoreria
{
    public class TesoreriaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Tesoreria";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Tesoreria_default",
                "Tesoreria/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.Tesoreria.Controllers" }
            );
        }
    }
}