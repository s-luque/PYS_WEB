using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_MEDI_COMU
    {
       
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(4, ErrorMessage = "Ingrese como máximo 4 Caracteres")]
        [Remote("validaExistenciaCOD_MECO", "MedioComunicacion", HttpMethod = "POST")]
        public String FS_COD_MECO { get; set; }
       
        [Required(ErrorMessage = "Campo requerido")]
        public String FS_NOM_MECO { get; set; }

        public String FS_NOM_CONT { get; set; }
        public String FS_DES_DIRE_MECO { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Remote("validaExistenciaTIP_MECO", "MedioComunicacion", HttpMethod = "POST")]
        public String FS_TIP_MECO { get; set; }

        public String FS_COD_UBIC_GEOG { get; set; }

        public String FS_COD_PAIS { get; set; }
        public String FS_NUM_TEL1 { get; set; }
        public String FS_NUM_TEL2 { get; set; }
        public String FS_NUM_FAXS { get; set; }
        public String FS_NOM_MAIL { get; set; }
        public String FS_DIR_WEBB { get; set; }
       
        public String FS_NUM_RUCS { get; set; } 
        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }



    }
}
