using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Librerias;
using PYS_Entidad;
using System.Data;
namespace PYS_SQL
{
    public class SQL_TA_CATE_DOCU
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public void Insertar(E_TA_CATE_DOCU O_TA_CATE_DOCU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_AD01", O_TA_CATE_DOCU.FS_COD_CATE_DOCU, O_TA_CATE_DOCU.FS_DES_CATE_DOCU, O_TA_CATE_DOCU.FI_COD_EMPR, O_TA_CATE_DOCU.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_CATE_DOCU O_TA_CATE_DOCU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_AC01", O_TA_CATE_DOCU.FS_COD_CATE_DOCU, O_TA_CATE_DOCU.FS_DES_CATE_DOCU, O_TA_CATE_DOCU.FI_COD_EMPR, O_TA_CATE_DOCU.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_CATE_DOCU O_TA_CATE_DOCU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_EL01", O_TA_CATE_DOCU.FS_COD_CATE_DOCU, O_TA_CATE_DOCU.FI_COD_EMPR);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_CATE_DOCU Buscar_Por_Codigo(string P_FS_COD_CATE_DOCU, int P_FI_COD_EMPR)
        {
            E_TA_CATE_DOCU O_TA_CATE_DOCU = new E_TA_CATE_DOCU();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_BU01", P_FS_COD_CATE_DOCU, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_CATE_DOCU.FS_COD_CATE_DOCU = "";
            }
            else
            {
                O_TA_CATE_DOCU.FS_COD_CATE_DOCU = ds.Tables[0].Rows[0]["FS_COD_CATE_DOCU"].ToString();
                O_TA_CATE_DOCU.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_COD_EMPR"].ToString());
                O_TA_CATE_DOCU.FS_DES_CATE_DOCU = ds.Tables[0].Rows[0]["FS_DES_CATE_DOCU"].ToString();
                O_TA_CATE_DOCU.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_CATE_DOCU.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_CATE_DOCU;
        }

        public List<E_TA_CATE_DOCU> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_DOCU> list = new List<E_TA_CATE_DOCU>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_DOCU O_TA_CATE_DOCU = new E_TA_CATE_DOCU();
                O_TA_CATE_DOCU.FS_COD_CATE_DOCU = ds.Tables[0].Rows[i]["FS_COD_CATE_DOCU"].ToString();
                O_TA_CATE_DOCU.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_DOCU.FS_DES_CATE_DOCU = ds.Tables[0].Rows[i]["FS_DES_CATE_DOCU"].ToString();
                O_TA_CATE_DOCU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_DOCU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_DOCU);
            }

            return list;

        }

        public List<E_TA_CATE_DOCU> Reporte(int P_FI_COD_EMPR)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_CRMM;
            var cmd = s_sql_action.GetProcedure("PR_CATE_DOCU_RE01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_DOCU> list = new List<E_TA_CATE_DOCU>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_DOCU O_TA_CATE_DOCU = new E_TA_CATE_DOCU();
                O_TA_CATE_DOCU.FS_COD_CATE_DOCU = ds.Tables[0].Rows[i]["FS_COD_CATE"].ToString();
                O_TA_CATE_DOCU.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_DOCU.FS_DES_CATE_DOCU = ds.Tables[0].Rows[i]["FS_DES_CATE"].ToString();
                O_TA_CATE_DOCU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_DOCU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_DOCU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_DOCU);
            }

            return list;

        }
    }
}
