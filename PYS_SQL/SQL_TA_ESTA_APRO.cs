using PYS_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Librerias;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace PYS_SQL
{
    public class SQL_TA_ESTA_APRO
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public void Insertar(E_TA_ESTA_APRO O_TA_ESTA_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_AD01", O_TA_ESTA_APRO.FS_COD_ESTA, O_TA_ESTA_APRO.FI_COD_EMPR, O_TA_ESTA_APRO.FS_DES_ESTA, O_TA_ESTA_APRO.FS_IND_ESTA, O_TA_ESTA_APRO.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
    
        }


        public void Actualizar(E_TA_ESTA_APRO O_TA_ESTA_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_AC01", O_TA_ESTA_APRO.FS_COD_ESTA, O_TA_ESTA_APRO.FI_COD_EMPR, O_TA_ESTA_APRO.FS_DES_ESTA, O_TA_ESTA_APRO.FS_IND_ESTA, O_TA_ESTA_APRO.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_ESTA_APRO O_TA_ESTA_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_EL01", O_TA_ESTA_APRO.FS_COD_ESTA, O_TA_ESTA_APRO.FI_COD_EMPR);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_ESTA_APRO Buscar_Por_Codigo(string P_FS_COD_ESTA, int P_FI_COD_EMPR)
        {
            E_TA_ESTA_APRO O_TA_ESTA_APRO = new E_TA_ESTA_APRO();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_BU01", P_FS_COD_ESTA, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_ESTA_APRO.FS_COD_ESTA = "";
            }
            else
            {
                O_TA_ESTA_APRO.FS_COD_ESTA = ds.Tables[0].Rows[0]["FS_COD_ESTA"].ToString();
                O_TA_ESTA_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_COD_EMPR"].ToString());
                O_TA_ESTA_APRO.FS_DES_ESTA = ds.Tables[0].Rows[0]["FS_DES_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_IND_ESTA = ds.Tables[0].Rows[0]["FS_IND_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_ESTA_APRO.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_ESTA_APRO;
        }

        public List<E_TA_ESTA_APRO> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_ESTA_APRO> list = new List<E_TA_ESTA_APRO>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_ESTA_APRO O_TA_ESTA_APRO = new E_TA_ESTA_APRO();
                O_TA_ESTA_APRO.FS_COD_ESTA = ds.Tables[0].Rows[i]["FS_COD_ESTA"].ToString();
                //O_TA_ESTA_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_ESTA_APRO.FS_DES_ESTA = ds.Tables[0].Rows[i]["FS_DES_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_IND_ESTA = ds.Tables[0].Rows[i]["FS_IND_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_ESTA_APRO.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_ESTA_APRO);
            }

            return list;

        }

        public List<E_TA_ESTA_APRO> Reporte(int P_FI_COD_EMPR)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_ESTA_APRO_RE01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_ESTA_APRO> list = new List<E_TA_ESTA_APRO>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_ESTA_APRO O_TA_ESTA_APRO = new E_TA_ESTA_APRO();
                O_TA_ESTA_APRO.FS_COD_ESTA = ds.Tables[0].Rows[i]["FS_COD_ESTA"].ToString();
                O_TA_ESTA_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_ESTA_APRO.FS_DES_ESTA = ds.Tables[0].Rows[i]["FS_DES_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_IND_ESTA = ds.Tables[0].Rows[i]["FS_IND_ESTA"].ToString();
                O_TA_ESTA_APRO.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_ESTA_APRO.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_ESTA_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_ESTA_APRO);
            }

            return list;

        }



    }
}
