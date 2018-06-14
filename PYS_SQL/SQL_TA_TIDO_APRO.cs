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
    public class SQL_TA_TIDO_APRO
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;
      

        public void Insertar(E_TA_TIDO_APRO O_TA_TIDO_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_AD01", O_TA_TIDO_APRO.FS_COD_TIDO_SIST, O_TA_TIDO_APRO.FI_COD_EMPR, O_TA_TIDO_APRO.FS_IND_APRO_ANEX, O_TA_TIDO_APRO.FS_IND_APRO_ENTI, O_TA_TIDO_APRO.FI_CAN_NIVE, O_TA_TIDO_APRO.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_TIDO_APRO O_TA_TIDO_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_AC01", O_TA_TIDO_APRO.FS_COD_TIDO_SIST, O_TA_TIDO_APRO.FI_COD_EMPR, O_TA_TIDO_APRO.FS_IND_APRO_ANEX, O_TA_TIDO_APRO.FS_IND_APRO_ENTI, O_TA_TIDO_APRO.FI_CAN_NIVE, O_TA_TIDO_APRO.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_TIDO_APRO O_TA_TIDO_APRO)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_EL01", O_TA_TIDO_APRO.FS_COD_TIDO_SIST, O_TA_TIDO_APRO.FI_COD_EMPR);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_TIDO_APRO Buscar_Por_Codigo(string P_FS_COD_TIDO_SIST, int P_FI_COD_EMPR)
        {
            E_TA_TIDO_APRO O_TA_TIDO_APRO = new E_TA_TIDO_APRO();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_BU01", P_FS_COD_TIDO_SIST, P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_TIDO_APRO.FS_COD_TIDO_SIST = "";
            }
            else
            {
                O_TA_TIDO_APRO.FS_COD_TIDO_SIST = ds.Tables[0].Rows[0]["FS_COD_TIDO_SIST"].ToString();
                O_TA_TIDO_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_COD_EMPR"].ToString());
                O_TA_TIDO_APRO.FS_IND_APRO_ANEX = ds.Tables[0].Rows[0]["FS_IND_APRO_ANEX"].ToString();
                O_TA_TIDO_APRO.FS_IND_APRO_ENTI = ds.Tables[0].Rows[0]["FS_IND_APRO_ENTI"].ToString();
                O_TA_TIDO_APRO.FI_CAN_NIVE = Convert.ToInt32(ds.Tables[0].Rows[0]["FI_CAN_NIVE"].ToString());
                O_TA_TIDO_APRO.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_TIDO_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_TIDO_APRO.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_TIDO_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_TIDO_APRO;
        }

        public List<E_TA_TIDO_APRO> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_TIDO_APRO> list = new List<E_TA_TIDO_APRO>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_TIDO_APRO O_TA_TIDO_APRO = new E_TA_TIDO_APRO();
                O_TA_TIDO_APRO.FS_COD_TIDO_SIST = ds.Tables[0].Rows[i]["FS_COD_TIDO_SIST"].ToString();
                O_TA_TIDO_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_TIDO_APRO.FS_IND_APRO_ANEX = ds.Tables[0].Rows[i]["FS_IND_APRO_ANEX"].ToString();
                O_TA_TIDO_APRO.FS_IND_APRO_ENTI = ds.Tables[0].Rows[i]["FS_IND_APRO_ENTI"].ToString();
                O_TA_TIDO_APRO.FI_CAN_NIVE = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_CAN_NIVE"].ToString());
                //O_TA_TIDO_APRO.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                //O_TA_TIDO_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                //O_TA_TIDO_APRO.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                //O_TA_TIDO_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_TIDO_APRO);
            }

            return list;

        }

        public List<E_TA_TIDO_APRO> Reporte(int P_FI_COD_EMPR)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_TIDO_APRO_RE01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_TIDO_APRO> list = new List<E_TA_TIDO_APRO>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_TIDO_APRO O_TA_TIDO_APRO = new E_TA_TIDO_APRO();
                O_TA_TIDO_APRO.FS_COD_TIDO_SIST = ds.Tables[0].Rows[i]["FS_COD_TIDO_SIST"].ToString();
                O_TA_TIDO_APRO.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());
                O_TA_TIDO_APRO.FS_IND_APRO_ANEX = ds.Tables[0].Rows[i]["FS_IND_APRO_ANEX"].ToString();
                O_TA_TIDO_APRO.FS_IND_APRO_ENTI = ds.Tables[0].Rows[i]["FS_IND_APRO_ENTI"].ToString();
                O_TA_TIDO_APRO.FI_CAN_NIVE = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_CAN_NIVE"]);
                O_TA_TIDO_APRO.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_TIDO_APRO.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_TIDO_APRO.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_TIDO_APRO.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_TIDO_APRO);
            }

            return list;

        }
    }

    
}
