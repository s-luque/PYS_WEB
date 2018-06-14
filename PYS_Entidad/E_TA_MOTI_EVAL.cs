using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_MOTI_EVAL
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(4, ErrorMessage = "Debe ingresar como máximo 4 Caracteres")]
        [Remote("validaExistenciaCOD_MOTI_EVAL", "MotivoEvaluacion", HttpMethod = "POST")]
        public String FS_COD_MOTI_EVAL { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripción")]
        [StringLength(50, ErrorMessage = "Debe ingresar como máximo 50 caracteres")]
        public String FS_DES_MOTI_EVAL { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
