using System;
using PYS_Entidad;
using PYS_SQL;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using System.Web;



namespace PYS_Web.Areas.Aprobaciones.Controllers
{
    public class EstadoAprobacionController : Controller
    {
        private SQL_TA_ESTA_APRO sql = new SQL_TA_ESTA_APRO();
        // GET: EstadoAprobacion
        public ActionResult Index()
        {
            ViewBag.List_Estado = sql.Listado(1);
            return View();
        }

        public ActionResult NewEstado()
        {
            return View();
        }

        public ActionResult EditEstado(E_TA_ESTA_APRO obj)
        {
            obj.FI_COD_EMPR = 1;
            ViewBag.getEstado = sql.Buscar_Por_Codigo(obj.FS_COD_ESTA, obj.FI_COD_EMPR);
            return View();
        }

        //public ActionResult ReportEstado()
        //{
        //    List<E_TA_ESTA_APRO> list = new List<E_TA_ESTA_APRO>();
        //    list = sql.Reporte(1);

        //    string ruta_capa_rep = "\\PYP_Reportes";
        //    string rptRuta = Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath(""))) + ruta_capa_rep;
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(rptRuta, "Rpt_Categoria.rpt"));

        //    rd.SetDataSource(list);
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    //Response.AddHeader("Content-Disposition", "inline; filename=Authorization.pdf");
        //    return File(stream, "application/pdf", "Reporte_Estado.pdf");
        //}


        public void SaveEstado(E_TA_ESTA_APRO obj)
        {
            obj.FS_COD_USCR = "SHINTA";
            obj.FI_COD_EMPR = 1;
            sql.Insertar(obj);
        }
        [HttpPost]
        public JsonResult Guardar(E_TA_ESTA_APRO model)
        {
            var resp = new ResponseModel
            {
                response = true,
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveEstado(model);
            }
            else
            {
                resp.response = false;
            }
            return Json(resp);
        }
        public JsonResult Actualizar(E_TA_ESTA_APRO model)
        {
            var resp = new ResponseModel
            {
                response = true,
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateEstado(model);
            }
            else
            {
                resp.response = false;
            }
            return Json(resp);
        }

        public void UpdateEstado(E_TA_ESTA_APRO obj)
        {
            obj.FS_COD_USMO = "SHINTA";
            obj.FI_COD_EMPR = 1;
            sql.Actualizar(obj);
        }

        public void DeleteEstado(E_TA_ESTA_APRO obj)
        {
            obj.FI_COD_EMPR = 1;
            sql.Eliminar(obj);
        }
        // Validación - Verifica si Campo FS_COD_ESTA existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_ESTA(E_TA_ESTA_APRO obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_ESTA, 1);
            if (obj.FS_COD_ESTA == "")
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}