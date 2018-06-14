using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_TIPO_MEDI_COMU
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(4, ErrorMessage = "Debe ingresar como máximo 4 Caracteres")]
        [Remote("validaExistenciaTIP_MECO", "TipoMedioComunicacion", HttpMethod = "POST")]
        public String FS_TIP_MECO { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripción")]
        [StringLength(49, ErrorMessage = "Debe ingresar como máximo 50 caracteres")]
        public String FS_DES_TIPO_MECO { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
