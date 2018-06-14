using PYS_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PYS_SQL
{
    public class SQL_TA_USUA_SIST
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public E_TA_USUA_SIST buscar_usuarioSistema_por_codigo(string P_FS_COD_USUA)
        {
            E_TA_USUA_SIST O_TA_USUA_SIST = new E_TA_USUA_SIST();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_USUA_SIST_BUS01", P_FS_COD_USUA);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_USUA_SIST.FS_COD_USUA = "";
            }
            else
            {
                O_TA_USUA_SIST.FS_COD_USUA = ds.Tables[0].Rows[0]["FS_COD_USUA"].ToString();
                O_TA_USUA_SIST.FS_IND_PERS = ds.Tables[0].Rows[0]["FS_IND_PERS"].ToString();
                O_TA_USUA_SIST.FS_NOM_PRIM = ds.Tables[0].Rows[0]["FS_NOM_PRIM"].ToString();
                O_TA_USUA_SIST.FS_NOM_SECU = ds.Tables[0].Rows[0]["FS_APE_PATE"].ToString();
                O_TA_USUA_SIST.FS_APE_PATE = ds.Tables[0].Rows[0]["FS_APE_PATE"].ToString();
                O_TA_USUA_SIST.FS_APE_MATE = ds.Tables[0].Rows[0]["FS_APE_MATE"].ToString();
                O_TA_USUA_SIST.FS_USU_NOPE = ds.Tables[0].Rows[0]["FS_USU_NOPE"].ToString();
                O_TA_USUA_SIST.FS_CLA_USUA = ds.Tables[0].Rows[0]["FS_CLA_USUA"].ToString();
            }
            return O_TA_USUA_SIST;
        }

    }
}
