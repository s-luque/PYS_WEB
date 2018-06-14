using PYS_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Librerias;
using System.Data;

namespace PYS_SQL
{
    public class SQL_TA_CATE_PRES
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public void Insertar(E_TA_CATE_PRES O_TA_CATE_PRES)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_AD01", O_TA_CATE_PRES.FS_COD_CATE, O_TA_CATE_PRES.FI_COD_EMPR, O_TA_CATE_PRES.FS_DES_CATE, O_TA_CATE_PRES.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_CATE_PRES O_TA_CATE_PRES)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_AC01", O_TA_CATE_PRES.FS_COD_CATE, O_TA_CATE_PRES.FI_COD_EMPR, O_TA_CATE_PRES.FS_DES_CATE, O_TA_CATE_PRES.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_CATE_PRES O_TA_CATE_PRES)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_EL01", O_TA_CATE_PRES.FS_COD_CATE, O_TA_CATE_PRES.FI_COD_EMPR);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_CATE_PRES Buscar_Por_Codigo(string P_FS_COD_CATE, int P_FI_COD_EMPR)
        {
            E_TA_CATE_PRES O_TA_CATE_PRES = new E_TA_CATE_PRES();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_BU01", P_FS_COD_CATE, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_CATE_PRES.FS_COD_CATE = "";
            }
            else
            {
                O_TA_CATE_PRES.FS_COD_CATE = ds.Tables[0].Rows[0]["FS_COD_CATE"].ToString();
                O_TA_CATE_PRES.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_COD_EMPR"].ToString());
                O_TA_CATE_PRES.FS_DES_CATE = ds.Tables[0].Rows[0]["FS_DES_CATE"].ToString();
                O_TA_CATE_PRES.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_CATE_PRES.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_CATE_PRES.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_CATE_PRES.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_CATE_PRES;
        }

        public List<E_TA_CATE_PRES> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_PRES> list = new List<E_TA_CATE_PRES>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_PRES O_TA_CATE_PRES = new E_TA_CATE_PRES();
                O_TA_CATE_PRES.FS_COD_CATE = ds.Tables[0].Rows[i]["FS_COD_CATE"].ToString();
                O_TA_CATE_PRES.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_PRES.FS_DES_CATE = ds.Tables[0].Rows[i]["FS_DES_CATE"].ToString();
                O_TA_CATE_PRES.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_PRES.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_PRES.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_PRES.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_PRES);
            }

            return list;

        }

        public List<E_TA_CATE_PRES> Reporte(int P_FI_COD_EMPR)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PRES;
            var cmd = s_sql_action.GetProcedure("PR_CATE_PRES_RE01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_CATE_PRES> list = new List<E_TA_CATE_PRES>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_CATE_PRES O_TA_CATE_PRES = new E_TA_CATE_PRES();
                O_TA_CATE_PRES.FS_COD_CATE = ds.Tables[0].Rows[i]["FS_COD_CATE"].ToString();
                O_TA_CATE_PRES.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_CATE_PRES.FS_DES_CATE = ds.Tables[0].Rows[i]["FS_DES_CATE"].ToString();
                O_TA_CATE_PRES.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_CATE_PRES.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_CATE_PRES.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_CATE_PRES.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_CATE_PRES);
            }

            return list;

        }



    }
}
