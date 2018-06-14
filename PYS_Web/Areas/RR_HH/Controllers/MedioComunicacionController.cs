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
    public class MedioComunicacionController : Controller
    {
        private SQL_TA_MEDI_COMU sql = new SQL_TA_MEDI_COMU();
        private SQL_TA_TIPO_MEDI_COMU sqlApoyo = new SQL_TA_TIPO_MEDI_COMU();

        public ActionResult Index()
        {
            ViewBag.List_Medio_Comunicacion = sql.Listado(1);

            return View();
        }

        public ActionResult NewMedioComunicacion()
        {
            return View();
        }

        public ActionResult EditMedioComunicacion(E_TA_MEDI_COMU obj)
        {
            ViewBag.getMedioComunicacion = sql.Buscar_Por_Codigo(obj.FS_COD_MECO);
            return View();
        }

        //public ActionResult ReportEvaluacion()
        //{
        //    List<E_TA_MEDI_COMU> list = new List<E_TA_MEDI_COMU>();
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
        public void SaveMedioComunicacion(E_TA_MEDI_COMU obj)
        {
            obj.FS_COD_USCR = "shinta";
            sql.Insertar(obj);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_MEDI_COMU model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveMedioComunicacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }

        [HttpPost]
        public JsonResult Actualizar(E_TA_MEDI_COMU model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateMedioComunicacion(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public void UpdateMedioComunicacion(E_TA_MEDI_COMU obj)
        {
            obj.FS_COD_USMO = "shinta";
            sql.Actualizar(obj);
        }
        public void DeleteMedioComunicacion(E_TA_MEDI_COMU obj)
        {
            sql.Eliminar(obj);
        }

        // Validación - Verifica si Campo FS_TIP_MECO existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaTIP_MECO(E_TA_TIPO_MEDI_COMU obj)
        {
            obj = sqlApoyo.Buscar_Por_Codigo(obj.FS_TIP_MECO);
            if (obj.FS_TIP_MECO != "")
            {
                return Json(true);
            }
            else
                return Json("Código no existe");
        }

        // Validación - Verifica si Campo FS_COD_MECO existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_MECO(E_TA_MEDI_COMU obj)
        {         
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_MECO);
            if (obj.FS_COD_MECO == "" )
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}