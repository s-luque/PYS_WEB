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
    public class CategoriaCargoController : Controller
    {
        private SQL_TA_CATE_CARG sql = new SQL_TA_CATE_CARG();
        public ActionResult Index()
        {
            ViewBag.List_Categoria_Cargo = sql.Listado(1);
            return View();
        }

        public ActionResult NewCategoriaCargo()
        {
            return View();
        }

        public ActionResult EditCategoriaCargo(E_TA_CATE_CARG obj)
        {
            obj.FI_COD_EMPR = 1;
            ViewBag.getCategoriaCargo = sql.Buscar_Por_Codigo(obj.FS_COD_CCAR, obj.FI_COD_EMPR);
            return View();
        }


        //public ActionResult ReportCategoriaCargo()
        //{
        //    List<E_TA_CATE_CARG> list = new List<E_TA_CATE_CARG>();
        //    list = sql.Reporte(1);

        //    string ruta_capa_rep = "\\PYS_Reportes";
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
        public void SaveCategoriaCargo(E_TA_CATE_CARG obj)
        {
            obj.FS_COD_USCR = "shinta";
            obj.FI_COD_EMPR = 1;
            sql.Insertar(obj);
        }

        [HttpPost]
        public JsonResult Guardar(E_TA_CATE_CARG model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                SaveCategoriaCargo(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }
        public JsonResult Actualizar(E_TA_CATE_CARG model)
        {
            var resp = new ResponseModel
            {
                response = true,
                //redirect="Home/Index",
                error = ""
            };

            if (ModelState.IsValid)
            {
                UpdateCategoriaCargo(model);
            }
            else
            {
                resp.response = false;
            }

            return Json(resp);
        }




        public void UpdateCategoriaCargo(E_TA_CATE_CARG obj)
        {
            obj.FS_COD_USMO = "shinta";
            obj.FI_COD_EMPR = 1;
            sql.Actualizar(obj);
        }
        public void DeleteCategoriaCargo(E_TA_CATE_CARG obj)
        {
            obj.FI_COD_EMPR = 1;
            sql.Eliminar(obj);
        }

        // Validación - Verifica si Campo FS_COD_CCAR existe en DB 
        [HttpPost]
        public JsonResult validaExistenciaCOD_CCAR(E_TA_CATE_CARG obj)
        {
            obj = sql.Buscar_Por_Codigo(obj.FS_COD_CCAR, 1);
            if (obj.FS_COD_CCAR == "")
            {
                return Json(true);
            }
            else
                return Json("Código ya existe");
        }
    }
}