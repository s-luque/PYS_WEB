using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_ESTA_APRO
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(3, ErrorMessage = "Debe ingresar como maximo 3 Caracteres")]
        [Remote("validaExistenciaCOD_ESTA", "EstadoAprobacion", HttpMethod = "POST")]
        public String FS_COD_ESTA { get; set; }

        public int FI_COD_EMPR { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripción")]
        [StringLength(100, ErrorMessage = "Debe ingresar como máximo 100 caracteres")]
        public String FS_DES_ESTA { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Estado")]

        public String FS_IND_ESTA { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
