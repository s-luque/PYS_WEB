using System;
using PYS_Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PYS_SQL
{
    public class SQL_TA_MEDI_CAPT
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;


        public void Insertar(E_TA_MEDI_CAPT O_TA_MEDI_CAPT)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_AD01", O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT, O_TA_MEDI_CAPT.FS_DES_MEDI_CAPT, O_TA_MEDI_CAPT.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_MEDI_CAPT O_TA_MEDI_CAPT)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_AC01", O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT, O_TA_MEDI_CAPT.FS_DES_MEDI_CAPT, O_TA_MEDI_CAPT.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_MEDI_CAPT O_TA_MEDI_CAPT)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_EL01", O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_MEDI_CAPT Buscar_Por_Codigo(string P_FS_COD_MEDI_CAPT)
        {
            E_TA_MEDI_CAPT O_TA_MEDI_CAPT = new E_TA_MEDI_CAPT();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_BU01", P_FS_COD_MEDI_CAPT);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT = "";
            }
            else
            {
                O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT = ds.Tables[0].Rows[0]["FS_COD_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_DES_MEDI_CAPT = ds.Tables[0].Rows[0]["FS_DES_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_MEDI_CAPT.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_MEDI_CAPT.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_MEDI_CAPT.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_MEDI_CAPT;
        }


        public List<E_TA_MEDI_CAPT> Listado()
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_CA01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_MEDI_CAPT> list = new List<E_TA_MEDI_CAPT>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_MEDI_CAPT O_TA_MEDI_CAPT = new E_TA_MEDI_CAPT();
                O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT = ds.Tables[0].Rows[i]["FS_COD_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_DES_MEDI_CAPT = ds.Tables[0].Rows[i]["FS_DES_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_MEDI_CAPT.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());

                list.Add(O_TA_MEDI_CAPT);
            }

            return list;

        }

        public List<E_TA_MEDI_CAPT> Reporte()
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_CAPT_RE01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_MEDI_CAPT> list = new List<E_TA_MEDI_CAPT>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_MEDI_CAPT O_TA_MEDI_CAPT = new E_TA_MEDI_CAPT();
                O_TA_MEDI_CAPT.FS_COD_MEDI_CAPT = ds.Tables[0].Rows[i]["FS_COD_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_DES_MEDI_CAPT = ds.Tables[0].Rows[i]["FS_DES_MEDI_CAPT"].ToString();
                O_TA_MEDI_CAPT.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_MEDI_CAPT.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_MEDI_CAPT.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_MEDI_CAPT.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_MEDI_CAPT);
            }

            return list;

        }
    }

}
