using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_TIPO_EVAL
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(4, ErrorMessage = "Máximo 4 Caracteres")]
        [Remote("validaExistenciaTIP_EVAL", "TipoEvaluacion", HttpMethod = "POST")]
        public String FS_TIP_EVAL { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public String FS_DES_TIPO_EVAL { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
