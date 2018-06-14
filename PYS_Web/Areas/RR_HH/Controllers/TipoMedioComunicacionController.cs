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
    public class TipoMedioComunicacionController : Controller
    {
        private SQL_TA_TIPO_MEDI_COMU sql = new SQL_TA_TIPO_MEDI_COMU();

        public ActionResult Index()
        {
            ViewBag.List_Tipo_Medio_Comunicacion = sql.Listado();

            return View();
        }

        public ActionResult NewTipoMedioComu()
        {
            return View();
        }

        public ActionResult EditTipoMedioComu(E_TA_TIPO_MEDI_COMU obj)
        {
            ViewBag.getTipoMedioComunicacion = sql.Buscar_Por_Codigo(obj.FS_TIP_MECO);
            return View();
        }


        //public ActionResult ReportPerfil()
        //{
        //    List<E_TA_TIPO_MEDI_COMU> list = new List<E_TA_TIPO_MEDI_COMU>();
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
        public void SaveTipoMedioComu(E_TA_TIPO_MEDI_COMU obj)
        {
            obj.FS_COD_USCR = "shinta";
            sql.Insertar(obj);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_TIPO_MEDI_COMU model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveTipoMedioComu(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }


        [HttpPost]
        public JsonResult Actualizar(E_TA_TIPO_MEDI_COMU model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateTipoMedioComu(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public void UpdateTipoMedioComu(E_TA_TIPO_MEDI_COMU obj)
        {
            obj.FS_COD_USMO = "shinta";
            sql.Actualizar(obj);
        }
        public void DeleteTipoMedioComu(E_TA_TIPO_MEDI_COMU obj)
        {
            sql.Eliminar(obj);
        }

        // Validación - Verifica si Campo FS_TIP_MECO existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaTIP_MECO(E_TA_TIPO_MEDI_COMU obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_TIP_MECO);
            if (obj.FS_TIP_MECO == "")
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}