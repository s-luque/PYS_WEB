using PYS_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace PYS_SQL
{
    public class SQL_TA_TIPO_DOCU_SIST
    {

        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;


        public List<E_TA_TIPO_DOCU_SIST> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_DOCU_SIST_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_TIPO_DOCU_SIST> list = new List<E_TA_TIPO_DOCU_SIST>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_TIPO_DOCU_SIST O_TA_TIPO_DOCU_SIST = new E_TA_TIPO_DOCU_SIST();
                O_TA_TIPO_DOCU_SIST.FS_COD_TIDO_SIST = ds.Tables[0].Rows[i]["FS_COD_TIDO_SIST"].ToString();
                O_TA_TIPO_DOCU_SIST.FS_DES_TIDO_SIST = ds.Tables[0].Rows[i]["FS_DES_TIDO_SIST"].ToString();
                list.Add(O_TA_TIPO_DOCU_SIST);
            }

            return list;

        }

        public E_TA_TIPO_DOCU_SIST Buscar_Por_Codigo(string P_COD_TIDO_SIST, int P_FI_COD_EMPR)
        {
            E_TA_TIPO_DOCU_SIST O_TA_TIPO_DOCU_SIST = new E_TA_TIPO_DOCU_SIST();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_DOCU_SIST_BUS01", P_COD_TIDO_SIST, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_TIPO_DOCU_SIST.FS_COD_TIDO_SIST = "";
            }
            else
            {
                O_TA_TIPO_DOCU_SIST.FS_COD_TIDO_SIST = ds.Tables[0].Rows[0]["FS_COD_TIDO_SIST"].ToString();
                O_TA_TIPO_DOCU_SIST.FS_DES_TIDO_SIST = ds.Tables[0].Rows[0]["FS_DES_TIDO_SIST"].ToString();
            }
            return O_TA_TIPO_DOCU_SIST;
        }


    }
}
