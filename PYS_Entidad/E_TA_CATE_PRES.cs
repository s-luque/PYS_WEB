using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PYS_Entidad
{
    public class E_TA_CATE_PRES
    {
        [Required(ErrorMessage ="Debe ingresar un Codigo")]
        [StringLength(2,ErrorMessage ="Debe ingresar como maximo 2 Caracteres")]
        public String FS_COD_CATE { get; set; }


        public int FI_COD_EMPR { get; set; }

        [Required(ErrorMessage ="Debe ingresar una Descripcion")]
        [StringLength(100,ErrorMessage ="Debe ingresar como maximo 100 caracteres")]
        public String FS_DES_CATE { get; set; } 


        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }



    }
}
