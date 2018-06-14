using System;
using System.Collections.Generic;
using PYS_SQL;
using PYS_Entidad;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace PYS_Web.Areas.RR_HH.Controllers
{
    public class MedioCaptacionController : Controller
    { 
    private SQL_TA_MEDI_CAPT sql = new SQL_TA_MEDI_CAPT();
    public ActionResult Index()
    {
        ViewBag.List_Medio = sql.Listado();

        return View();
    }

    public ActionResult NewMedio()
    {
        return View();
    }

    public ActionResult EditMedio(E_TA_MEDI_CAPT obj)
    {
        ViewBag.getMedio = sql.Buscar_Por_Codigo(obj.FS_COD_MEDI_CAPT);
        return View();
    }


        //public ActionResult ReportMedio()
        //{
        //    List<E_TA_MEDI_CAPT> list = new List<E_TA_MEDI_CAPT>();
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
        //    return File(stream, "application/pdf", "Reporte_Medio_Captacion.pdf");
        //}
        [HttpPost]
        public JsonResult Guardar(E_TA_MEDI_CAPT model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveMedio(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public void SaveMedio(E_TA_MEDI_CAPT obj)
    {
        obj.FS_COD_USCR = "shinta";
        sql.Insertar(obj);
    }

        [HttpPost]
        public JsonResult Actualizar(E_TA_MEDI_CAPT model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateMedio(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public void UpdateMedio(E_TA_MEDI_CAPT obj)
        {
            obj.FS_COD_USMO = "shinta";
            sql.Actualizar(obj);

        }

        public void DeleteMedio(E_TA_MEDI_CAPT obj)
    {
        sql.Eliminar(obj);
    }
        // Validación - Verifica si Campo FS_COD_MEDI_CAPT existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaMEDI_CAPT(E_TA_MEDI_CAPT obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_MEDI_CAPT);
            if (obj.FS_COD_MEDI_CAPT == "")
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}