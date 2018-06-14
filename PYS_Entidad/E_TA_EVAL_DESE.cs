using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_EVAL_DESE
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(4, ErrorMessage = "Debe ingresar como máximo 4 Caracteres")]
        [Remote("validaExistenciaCOD_EVAL_DESE", "EvaluacionDesempeño", HttpMethod = "POST")]
        public String FS_COD_EVAL_DESE { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Código")]
        [Remote("validaExistenciaTIP_EVAL", "EvaluacionDesempeño", HttpMethod = "POST")]
        public String FS_TIP_EVAL { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Código")]
        [Remote("validaExistenciaCOD_CCAR", "EvaluacionDesempeño", HttpMethod = "POST")]
        public String FS_COD_CCAR { get; set; }

        public int FI_COD_EMPR { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        [StringLength(50, ErrorMessage = "Debe ingresar como maximo 50 caracteres")]
        public String FS_DES_EVAL_DESE { get; set; }

        [StringLength(50, ErrorMessage = "Debe ingresar como maximo 50 caracteres")]
        public String FS_DES_OBSE { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }



    }
}
