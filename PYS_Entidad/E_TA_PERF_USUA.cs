using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PYS_Entidad
{
    public class E_TA_PERF_USUA

    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(5, ErrorMessage = "Debe ingresar como maximo 5 Caracteres")]
        public String FS_COD_PFUS { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Descripción")]
        [StringLength(100, ErrorMessage = "Debe ingresar como maximo 100 caracteres")]
        public String FS_DES_PFUS { get; set; }

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
