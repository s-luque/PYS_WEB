using PYS_Entidad;
using PYS_SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;


namespace PYS_Web.Areas.RR_HH.Controllers
{
    public class MotivoEvaluacionController : Controller
    {
        private SQL_TA_MOTI_EVAL sql = new SQL_TA_MOTI_EVAL();

        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.List_Motivo_Evaluacion = sql.Listado();

            return View();
        }

        public ActionResult NewMotivoEvaluacion()
        {
            return View();
        }

        public ActionResult EditMotivoEvaluacion(E_TA_MOTI_EVAL obj)
        {
            ViewBag.getMotivoEvaluacion = sql.Buscar_Por_Codigo(obj.FS_COD_MOTI_EVAL);
            return View();
        }


        //public ActionResult ReportPerfil()
        //{
        //    List<E_TA_MOTI_EVAL> list = new List<E_TA_MOTI_EVAL>();
        //    list = sql.Reporte();

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
        //    return File(stream, "application/pdf", "Reporte_Categoria.pdf");
        //}
        public void SaveMotivoEvaluacion(E_TA_MOTI_EVAL obj)
        {
            obj.FS_COD_USCR = "shinta";
            sql.Insertar(obj);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_MOTI_EVAL model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveMotivoEvaluacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        [HttpPost]
        public JsonResult Actualizar(E_TA_MOTI_EVAL model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateMotivoEvaluacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public void UpdateMotivoEvaluacion(E_TA_MOTI_EVAL obj)
        {
            obj.FS_COD_USMO = "shinta";
            sql.Actualizar(obj);
        }
        public void DeleteMotivoEvaluacion(E_TA_MOTI_EVAL obj)
        {
            sql.Eliminar(obj);
        }
        // Validación - Verifica si Campo FS_COD_MOTI_EVAL existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_MOTI_EVAL(E_TA_MOTI_EVAL obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_MOTI_EVAL);
            if (obj.FS_COD_MOTI_EVAL == "" )
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}