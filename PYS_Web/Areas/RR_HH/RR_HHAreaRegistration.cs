using System.Web.Mvc;

namespace PYS_Web.Areas.RR_HH
{
    public class RR_HHAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RR_HH";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RR_HH_default",
                "RR_HH/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.RR_HH.Controllers" }
            );
        }
    }
}