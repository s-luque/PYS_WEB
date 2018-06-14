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
    public class E_TA_USUA_SIST
    {
 
        [Required(ErrorMessage = "Campo requerido")]
        [Remote("validaExistenciaCOD_USUA", "Home", HttpMethod = "POST")]
        public string FS_COD_USUA { get; set; }
        public string FS_IND_PERS { get; set; }
        public string FS_NOM_PRIM { get; set; }
        public string FS_NOM_SECU { get; set; }
        public string FS_APE_PATE { get; set; }
        public string FS_APE_MATE { get; set; }
        public string FS_USU_NOPE { get; set; }
        //[Remote("validaExistenciaCLA_USUA", "Home", HttpMethod = "POST")]
        public string FS_CLA_USUA { get; set; }
        public string FS_COD_PFUS { get; set; }
        public string FS_DES_PFUS { get; set; }
        public string FS_NUM_TEL1 { get; set; }
        public string FS_NUM_TEL2 { get; set; }
        public string FS_COR_ELEC { get; set; }
        public string FS_IND_FEC_EXCL { get; set; }
        public int FI_NUM_DIEX { get; set; } = 0;
        public int  FI_DIEX_VIME { get; set; } = 0;
        public DateTime FD_INI_EXCL { get; set; }
        public DateTime FD_FEC_EXCL  { get; set; }
        public string  FS_IND_NUM_CONE { get; set; }
        public int  FI_NUM_CONE { get; set; } = 0;
        public string  FS_IND_EMPR_SUCU { get; set; }
        public string FI_COD_EMPR { get; set; } = "";
        public string  FS_NOM_CORT { get; set; }
        public string FI_COD_OFIC { get; set; } = "";
        public string  FS_DES_OFIC { get; set; }
        public string  FS_SIT_USUA { get; set; }
        public int FI_IDE_USUA { get; set; }
        public string  FS_IND_OBCU_DEAN { get; set; }
        public string  FS_IND_ACTU_MODU { get; set; }
        public string FS_IND_VISU_ACDI { get; set; } = "N";
        public string  FS_IND_PROD_DESA { get; set; }
        public string  FS_COD_USCR { get; set; }
        public string  FS_COD_USMO { get; set; }
        public DateTime  FD_FEC_USCR { get; set; }
        public DateTime FD_FEC_USMO { get; set; }
    }
}
