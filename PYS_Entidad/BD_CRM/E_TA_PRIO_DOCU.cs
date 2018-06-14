using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PYS_Entidad
{
    public class E_TA_PRIO_DOCU
    {
        [Required(ErrorMessage = "Debe ingresar un Codigo")]
        [StringLength(4, ErrorMessage = "Debe ingresar como maximo 4 Caracteres")]
        public String FS_COD_PRIO_DOCU { get; set; }
        public int FI_COD_EMPR { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        [StringLength(50, ErrorMessage = "Debe ingresar como maximo 50 caracteres")]
        public String FS_DES_PRIO_DOCU { get; set; }
        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
