using PYS_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PYS_SQL
{
    public class SQL_TA_CATE_CARG
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public void Insertar(E_TA_CATE_CARG O_TA_CATE_CARG)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_AD01", O_TA_CATE_CARG.FS_COD_CCAR, O_TA_CATE_CARG.FI_COD_EMPR, O_TA_CATE_CARG.FS_DES_CCAR, O_TA_CATE_CARG.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_CATE_CARG O_TA_CATE_CARG)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_AC01", O_TA_CATE_CARG.FS_COD_CCAR, O_TA_CATE_CARG.FI_COD_EMPR, O_TA_CATE_CARG.FS_DES_CCAR, O_TA_CATE_CARG.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_CATE_CARG O_TA_CATE_CARG)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_EL01", O_TA_CATE_CARG.FS_COD_CCAR, O_TA_CATE_CARG.FI_COD_EMPR);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_CATE_CARG Buscar_Por_Codigo(string P_FS_COD_CCAR, int P_FI_COD_EMPR)
        {
            E_TA_CATE_CARG O_TA_CATE_CARG = new E_TA_CATE_CARG();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_BU01", P_FS_COD_CCAR, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_CATE_CARG.FS_COD_CCAR = "";
            }
            else
            {
                O_TA_CATE_CARG.FS_COD_CCAR = ds.Tables[0].Rows[0]["FS_COD_CCAR"].ToString();
                O_TA_CATE_CARG.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_COD_EMPR"].ToString());
                O_TA_CATE_CARG.FS_DES_CCAR = ds.Tables[0].Rows[0]["FS_DES_CCAR"].ToString();
                O_TA_CATE_CARG.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_CATE_CARG.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_CATE_CARG.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_CATE_CARG.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_CATE_CARG;
        }

        public List<E_TA_CATE_CARG> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_CARG> list = new List<E_TA_CATE_CARG>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_CARG O_TA_CATE_CARG = new E_TA_CATE_CARG();
                O_TA_CATE_CARG.FS_COD_CCAR = ds.Tables[0].Rows[i]["FS_COD_CCAR"].ToString();
                O_TA_CATE_CARG.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_CARG.FS_DES_CCAR = ds.Tables[0].Rows[i]["FS_DES_CCAR"].ToString();
                O_TA_CATE_CARG.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_CARG.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_CARG.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_CARG.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_CARG);
            }

            return list;

        }

        public List<E_TA_CATE_CARG> Reporte(int P_FI_COD_EMPR)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_CATE_CARG_RE01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_CARG> list = new List<E_TA_CATE_CARG>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_CARG O_TA_CATE_CARG = new E_TA_CATE_CARG();
                O_TA_CATE_CARG.FS_COD_CCAR = ds.Tables[0].Rows[i]["FS_COD_CCAR"].ToString();
                O_TA_CATE_CARG.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_CARG.FS_DES_CCAR = ds.Tables[0].Rows[i]["FS_DES_CCAR"].ToString();
                O_TA_CATE_CARG.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_CARG.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_CARG.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_CARG.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_CARG);
            }

            return list;

        }



    }
}
