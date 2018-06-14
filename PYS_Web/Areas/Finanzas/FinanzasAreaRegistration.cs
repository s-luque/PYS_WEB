using System.Web.Mvc;

namespace PYS_Web.Areas.Finanzas
{
    public class FinanzasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Finanzas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Finanzas_default",
                "Finanzas/{controller}/{action}/{id}",
                new { controller="Home",action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PYS_Web.Areas.Finanzas.Controllers" }
            );
        }
    }
}