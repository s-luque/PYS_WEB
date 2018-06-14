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
    public class E_TA_TIDO_APRO
    {
        [Required(ErrorMessage = "Debe ingresar un Código")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Debe ingresar 3 caracteres en este campo")]
        [Remote("validaExistenciaCod", "DocumentoAprobacion", HttpMethod = "POST")]


        public String FS_COD_TIDO_SIST { get; set; }

        public int FI_COD_EMPR { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Debe ingresar solo números en este campo")]
        [Required(ErrorMessage = "Debe ingresar cantidad de Nivel")]

        public int FI_CAN_NIVE { get; set; }
        
        public String FS_IND_APRO_ANEX { get; set; } = "N";
        public String FS_IND_APRO_ENTI { get; set; } = "N";

        //public string SelectedSetting
        //{
        //    get
        //    {
        //        if (FS_IND_APRO_ANEX == "S") return "FS_IND_APRO_ANEX";
        //        if (FS_IND_APRO_ENTI == "S") return "FS_IND_APRO_ENTI";
        //        return null; // or you can set a default here
        //    }
        //    set
        //    {
        //        switch (value)
        //        {
        //            case "FS_IND_APRO_ANEX":
        //                FS_IND_APRO_ANEX = "S";
        //                break;
        //            case "FS_IND_APRO_ENTI":
        //                FS_IND_APRO_ENTI = "S";
        //                break;              
        //        }
        //    }
        //}

        public String FS_COD_USCR { get; set; }
        public DateTime FD_FEC_USCR { get; set; }
        public String FS_COD_USMO { get; set; }
        public DateTime FD_FEC_USMO { get; set; }



    }

}
