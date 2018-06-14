using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_MEDI_CAPT
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(4, ErrorMessage = "Debe ingresar como máximo 4 caracteres")]
        [Remote("validaExistenciaMEDI_CAPT", "MedioCaptacion", HttpMethod = "POST")]

        public String FS_COD_MEDI_CAPT { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Debe ingresar como máximo 50 caracteres")]
        public String FS_DES_MEDI_CAPT { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
