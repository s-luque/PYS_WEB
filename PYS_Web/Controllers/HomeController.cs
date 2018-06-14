using PYS_Entidad;
using PYS_SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.VisualBasic;
using System.Web.Security;

namespace PYS_Web.Controllers
{
    public class HomeController : Controller
    {
        private SQL_TA_USUA_SIST sql = new SQL_TA_USUA_SIST();

        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        [Authorize]
        public ActionResult Index()
        {
            var VS_FS_COD_USUA = User.Identity.Name;
            ViewBag.User = VS_FS_COD_USUA;
            return View();
        }

        public ActionResult Login()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session["V_FS_COD_USUA"] = "";
            return View();
        } 



        [HttpPost]
        public JsonResult Ingresar(E_TA_USUA_SIST model)
        {      
            var resp = new ResponseModel
            {
                response = true,
                redirect="Index",
                error = null
            };

            E_TA_USUA_SIST obj = new E_TA_USUA_SIST();
            obj = sql.buscar_usuarioSistema_por_codigo(model.FS_COD_USUA);
            if (obj.FS_CLA_USUA != cryption(model.FS_CLA_USUA))
            {                
                resp.response = false;
                resp.error = "Contraseña incorrecta";
            }

            if (!ModelState.IsValid)
            {
                resp.response = false;
            }
            else
            {
               
                var G_TA_USUA_SIST = new E_TA_USUA_SIST() { FS_COD_USUA = model.FS_COD_USUA, FS_CLA_USUA = cryption(model.FS_CLA_USUA) };
                var serializedUser = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                var ticket = new FormsAuthenticationTicket(1, model.FS_COD_USUA, DateTime.Now, DateTime.Now.AddHours(3),false, serializedUser);
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var isSsl = Request.IsSecureConnection; // if we are running in SSL mode then make the cookie secure only

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    HttpOnly = true, // always set this to true!
                    Secure = isSsl,
                };

                Response.Cookies.Set(cookie);
               // FormsAuthentication.SetAuthCookie(model.FS_COD_USUA, false);                           
            }
            return Json(resp);
        }    

    [HttpPost]
        public JsonResult validaExistenciaCOD_USUA(E_TA_USUA_SIST obj)
        {
            obj = sql.buscar_usuarioSistema_por_codigo(obj.FS_COD_USUA);
            if (obj.FS_COD_USUA != "")
            {
                return Json(true);
            }
            else
                return Json("Usuario no existe");
        }

        public string cryption(string text)
        {
            string strtempchar = null;
            string strencrypted = null;
            int i;
            for (i = 1; (i <= text.Length); i++)
            {
                if ((Strings.Asc(text.Substring((i - 1), 1)) < 128))
                {
                    strtempchar = (Strings.Asc(text.Substring((i - 1), 1)) + 128).ToString();
                }
                else if ((Strings.Asc(text.Substring((i - 1), 1)) > 128))
                {
                    strtempchar = (Strings.Asc(text.Substring((i - 1), 1)) - 128).ToString();
                }
                var a = text.Substring((i - 1), 1);
                var b = (Strings.Chr(Int32.Parse(strtempchar))).ToString();
                a = b;
                strencrypted = strencrypted + a;
            }

            return strencrypted;
        }
    }
}
