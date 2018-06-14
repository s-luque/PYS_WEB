using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PYS_Entidad
{
    public class E_TA_CATE_CARG
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(10, ErrorMessage = "Debe ingresar como maximo 10 Caracteres")]
        [Remote("validaExistenciaCOD_CCAR", "CategoriaCargo", HttpMethod = "POST")]
        public String FS_COD_CCAR { get; set; }


        public int FI_COD_EMPR { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripción")]
        [StringLength(50, ErrorMessage = "Debe ingresar como máximo 50 caracteres")]
        public String FS_DES_CCAR { get; set; }


        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }



    }
}
