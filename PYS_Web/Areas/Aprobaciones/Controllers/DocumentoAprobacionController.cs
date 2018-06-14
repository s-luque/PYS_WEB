using System;
using PYS_Entidad;
using PYS_SQL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace PYS_Web.Areas.Aprobaciones.Controllers
{
    public class DocumentoAprobacionController : Controller
    {
        private SQL_TA_TIDO_APRO sql = new SQL_TA_TIDO_APRO();
        private SQL_TA_TIPO_DOCU_SIST sqlApoyo = new SQL_TA_TIPO_DOCU_SIST();
        // GET: DocumentoAprobacion
        public ActionResult Index()
        {
            ViewBag.List_Documento = sql.Listado(1);
            return View();
        }

        public ActionResult NewDocumento()
        {
            return View();
        }

        public ActionResult EditDocumento(E_TA_TIDO_APRO obj)
        {
            obj.FI_COD_EMPR = 1;
            ViewBag.getDocumento = sql.Buscar_Por_Codigo(obj.FS_COD_TIDO_SIST, obj.FI_COD_EMPR);
            return View();
        }

        //public ActionResult ReportDocumento()
        //{
        //    List<E_TA_TIDO_APRO> list = new List<E_TA_TIDO_APRO>();
        //    list = sql.Reporte(1);

        //    string ruta_capa_rep = "\\PYP_Reportes";
        //    string rptRuta = Path.GetDirectoryName(Path.GetDirectoryName(Server.MapPath(""))) + ruta_capa_rep;
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(rptRuta, "Rpt_DocumentoAprobacion.rpt"));

        //    rd.SetDataSource(list);
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    //Response.AddHeader("Content-Disposition", "inline; filename=Authorization.pdf");
        //    return File(stream, "application/pdf", "Reporte_Documento_Aprobación.pdf");
        //}



        //public JsonResult validaExistenciaCod(string FS_COD_TIDO_SIST)
        //{
        //    return Json(!String.Equals(FS_COD_TIDO_SIST, "ABL"));
        //}

        public void SaveDocumento(E_TA_TIDO_APRO obj)
        {
            obj.FS_COD_USCR = "SHINTA";
            obj.FI_COD_EMPR = 1;
            sql.Insertar(obj);
        }

        // Validación - Verifica si Campo ya existe en DB y si existe en tabla de Apoyo
        [HttpPost]
        public JsonResult validaExistenciaCod(E_TA_TIDO_APRO obj, E_TA_TIPO_DOCU_SIST obj2)

        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_TIDO_SIST, 1);
            obj2 = sqlApoyo.Buscar_Por_Codigo(obj2.FS_COD_TIDO_SIST, 1);
            if (obj.FS_COD_TIDO_SIST != "")
            {          
                return Json("Código ya existe en tabla");            
            }
            else if(obj2.FS_COD_TIDO_SIST == "")
            {
                return Json("Código de Doc. no existe");
            }
            else
                return Json(true);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_TIDO_APRO model)
        {



            var resp = new ResponseModel
            {
                response = true,
                error = ""
            };
            if (ModelState.IsValid)
            {
                SaveDocumento(model);
            }
            else
            {
                resp.response = false;
            }
            return Json(resp);
        }
        [HttpPost]
        public JsonResult Actualizar(E_TA_TIDO_APRO model)
        {



            var resp = new ResponseModel
            {
                response = true,
                error = ""
            };
            if (ModelState.IsValid)
            {
                UpdateDocumento(model);
            }
            else
            {
                resp.response = false;
            }
            return Json(resp);
        }
        public void UpdateDocumento(E_TA_TIDO_APRO obj)
        {
            obj.FS_COD_USMO = "SHINTA";
            obj.FI_COD_EMPR = 1;
            sql.Actualizar(obj);
        }

        public void DeleteDocumento(E_TA_TIDO_APRO obj)
        {
            obj.FI_COD_EMPR = 1;
            sql.Eliminar(obj);
        }
    }
}