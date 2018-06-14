using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PYS_SQL;

namespace PYS_Web.Areas.Aprobaciones.Controllers
{
    public class AyudaBusquedaController : Controller
    {
        private SQL_TA_PERF_USUA sql = new SQL_TA_PERF_USUA();
        private SQL_TA_TIPO_DOCU_SIST sql2 = new SQL_TA_TIPO_DOCU_SIST();
        private SQL_TA_TIPO_EVAL sql3 = new SQL_TA_TIPO_EVAL();
        private SQL_TA_CATE_CARG sql4 = new SQL_TA_CATE_CARG();
        private SQL_TA_TIPO_MEDI_COMU sql5 = new SQL_TA_TIPO_MEDI_COMU();

        // GET: AyudaTabla
        public ActionResult Ayuda_Perfil()
        {
            ViewBag.buscar_TA_PERF_USUA = true;
            ViewBag.V_VB_LIST_TA_PERF_USUA = sql.Listado();
            ViewBag.title = "Tabla Perfil";
            return View("Index");
        }
        public ActionResult Ayuda_Documento()
        {
            ViewBag.buscar_TA_TIPO_DOCU_SIST = true;
            ViewBag.V_VB_LIST_TA_TIPO_DOCU_SIST = sql2.Listado(1);
            ViewBag.title = "Tabla Documentos";
            return View("Index");
        }
        public ActionResult Ayuda_Evaluacion()
        {
            ViewBag.buscar_TA_TIPO_EVAL = true;
            ViewBag.V_VB_LIST_TA_TIPO_EVAL = sql3.Listado();
            ViewBag.title = "Tabla Tipo Evaluación";
            return View("Index");
        }
        public ActionResult Ayuda_Cargo()
        {
            ViewBag.buscar_TA_CATE_CARG = true;
            ViewBag.V_VB_LIST_TA_CATE_CARG = sql4.Listado(1);
            ViewBag.title = "Tabla Categoría Cargo";
            return View("Index");
        }
        public ActionResult Ayuda_Tipo_Medio()
        {
            ViewBag.buscar_TA_TIPO_MEDI_COMU = true;
            ViewBag.V_VB_LIST_TA_TIPO_MEDI_COMU = sql5.Listado();
            ViewBag.title = "Tabla Tipo Medio Comunicación";
            return View("Index");
        }
    }
}