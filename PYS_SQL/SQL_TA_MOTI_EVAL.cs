using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PYS_Entidad;

namespace PYS_SQL
{
    public class SQL_TA_MOTI_EVAL
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;


        public void Insertar(E_TA_MOTI_EVAL O_TA_MOTI_EVAL)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_AD01", O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL, O_TA_MOTI_EVAL.FS_DES_MOTI_EVAL, O_TA_MOTI_EVAL.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_MOTI_EVAL O_TA_MOTI_EVAL)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_AC01", O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL, O_TA_MOTI_EVAL.FS_DES_MOTI_EVAL, O_TA_MOTI_EVAL.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_MOTI_EVAL O_TA_MOTI_EVAL)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_EL01", O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_MOTI_EVAL Buscar_Por_Codigo(string P_FS_COD_MOTI_EVAL)
        {
            E_TA_MOTI_EVAL O_TA_MOTI_EVAL = new E_TA_MOTI_EVAL();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_BU01", P_FS_COD_MOTI_EVAL);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL = "";
            }
            else
            {
                O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL = ds.Tables[0].Rows[0]["FS_COD_MOTI_EVAL"].ToString();
                O_TA_MOTI_EVAL.FS_DES_MOTI_EVAL = ds.Tables[0].Rows[0]["FS_DES_MOTI_EVAL"].ToString();
                O_TA_MOTI_EVAL.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_MOTI_EVAL.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_MOTI_EVAL.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_MOTI_EVAL.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_MOTI_EVAL;
        }


        public List<E_TA_MOTI_EVAL> Listado()
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_CA01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_MOTI_EVAL> list = new List<E_TA_MOTI_EVAL>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_MOTI_EVAL O_TA_MOTI_EVAL = new E_TA_MOTI_EVAL();
                O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL = ds.Tables[0].Rows[i]["FS_COD_MOTI_EVAL"].ToString();
                O_TA_MOTI_EVAL.FS_DES_MOTI_EVAL = ds.Tables[0].Rows[i]["FS_DES_MOTI_EVAL"].ToString();
                O_TA_MOTI_EVAL.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_MOTI_EVAL.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_MOTI_EVAL.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_MOTI_EVAL.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_MOTI_EVAL);
            }

            return list;

        }

        public List<E_TA_MOTI_EVAL> Reporte()
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MOTI_EVAL_RE01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_MOTI_EVAL> list = new List<E_TA_MOTI_EVAL>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_MOTI_EVAL O_TA_MOTI_EVAL = new E_TA_MOTI_EVAL();
                O_TA_MOTI_EVAL.FS_COD_MOTI_EVAL = ds.Tables[0].Rows[i]["FS_COD_MOTI_EVAL"].ToString();
                O_TA_MOTI_EVAL.FS_DES_MOTI_EVAL = ds.Tables[0].Rows[i]["FS_DES_MOTI_EVAL"].ToString();

                list.Add(O_TA_MOTI_EVAL);
            }

            return list;

        }
    }
}
