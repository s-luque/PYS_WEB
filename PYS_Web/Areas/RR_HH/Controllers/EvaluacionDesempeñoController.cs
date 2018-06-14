using PYS_Entidad;
using PYS_SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace PYS_Web.Areas.RR_HH.Controllers
{
    public class EvaluacionDesempeñoController : Controller
    {
        private SQL_TA_EVAL_DESE sql = new SQL_TA_EVAL_DESE();
        private SQL_TA_TIPO_EVAL sqlApoyo = new SQL_TA_TIPO_EVAL();
        private SQL_TA_CATE_CARG sqlApoyo_2 = new SQL_TA_CATE_CARG();

        public ActionResult Index()
        {
            ViewBag.List_Evaluación = sql.Listado(1);

            return View();
        }

        public ActionResult NewEvaluacion()
        {
            return View();
        }

        public ActionResult EditEvaluacion(E_TA_EVAL_DESE obj)
        {   obj.FI_COD_EMPR = 1;
            ViewBag.getEvaluacion = sql.Buscar_Por_Codigo(obj.FS_COD_EVAL_DESE, obj.FI_COD_EMPR);
            return View();
        }


        //public ActionResult ReportEvaluacion()
        //{
        //    List<E_TA_EVAL_DESE> list = new List<E_TA_EVAL_DESE>();
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
        public void SaveEvaluacion(E_TA_EVAL_DESE obj)
        {
            obj.FS_COD_USCR = "shinta";
            obj.FI_COD_EMPR = 1;
            sql.Insertar(obj);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_EVAL_DESE model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveEvaluacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        [HttpPost]
        public JsonResult Actualizar(E_TA_EVAL_DESE model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateEvaluacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }

        public void UpdateEvaluacion(E_TA_EVAL_DESE obj)
        {
            obj.FS_COD_USMO = "shinta";
            obj.FI_COD_EMPR = 1;
            sql.Actualizar(obj);
        }
        public void DeleteEvaluacion(E_TA_EVAL_DESE obj)
        {
            obj.FI_COD_EMPR = 1;
            sql.Eliminar(obj);
        }
        // Validación - Verifica si Campo FS_TIP_EVAL existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaTIP_EVAL(E_TA_TIPO_EVAL obj)
        { 
            obj = sqlApoyo.Buscar_Por_Codigo(obj.FS_TIP_EVAL);
            if (obj.FS_TIP_EVAL != "")
            {
                return Json(true);             
            }
            else
                return Json("Código no existe");
        }
        // Validación - Verifica si Campo FS_COD_CCAR existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_CCAR(E_TA_CATE_CARG obj)
        {
            obj = sqlApoyo_2.Buscar_Por_Codigo(obj.FS_COD_CCAR, 1);
            if (obj.FS_COD_CCAR != "")
            {
                return Json(true);
            }
            else
                return Json("Código no existe");
        }
        // Validación - Verifica si Campo FS_COD_EVAL_DESE existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_EVAL_DESE(E_TA_EVAL_DESE obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_EVAL_DESE, 1);
            if (obj.FS_COD_EVAL_DESE == "")
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
   
}