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
    public class SQL_TA_PERF_USUA
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;
  

    public void Insertar(PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA)
    {
        s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
        var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_AD01", O_TA_PERF_USUA.FS_COD_PFUS, O_TA_PERF_USUA.FS_DES_PFUS, O_TA_PERF_USUA.FS_COD_USCR);
        s_sql_action.ExecuteNonQuery(cmd);
    }


        public void Actualizar(PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_AC01", O_TA_PERF_USUA.FS_COD_PFUS, O_TA_PERF_USUA.FS_DES_PFUS, O_TA_PERF_USUA.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_EL01", O_TA_PERF_USUA.FS_COD_PFUS);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_PERF_USUA Buscar_Por_Codigo(string P_FS_COD_PFUS)
        {
            PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA = new PYS_Entidad.E_TA_PERF_USUA();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_BUS02", P_FS_COD_PFUS);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_PERF_USUA.FS_COD_PFUS = "";
            }
            else
            {
                O_TA_PERF_USUA.FS_COD_PFUS = ds.Tables[0].Rows[0]["FS_COD_PFUS"].ToString();
                O_TA_PERF_USUA.FS_DES_PFUS = ds.Tables[0].Rows[0]["FS_DES_PFUS"].ToString();
                O_TA_PERF_USUA.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_PERF_USUA.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_PERF_USUA.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_PERF_USUA.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_PERF_USUA;
        }


        public List<PYS_Entidad.E_TA_PERF_USUA> Listado()
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_CA01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<PYS_Entidad.E_TA_PERF_USUA> list = new List<PYS_Entidad.E_TA_PERF_USUA>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA = new PYS_Entidad.E_TA_PERF_USUA();
                O_TA_PERF_USUA.FS_COD_PFUS = ds.Tables[0].Rows[i]["FS_COD_PFUS"].ToString();
                O_TA_PERF_USUA.FS_DES_PFUS = ds.Tables[0].Rows[i]["FS_DES_PFUS"].ToString();
                O_TA_PERF_USUA.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_PERF_USUA.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());

                list.Add(O_TA_PERF_USUA);
            }

            return list;

        }

        public List<PYS_Entidad.E_TA_PERF_USUA> Reporte()
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_SEGU;
            var cmd = s_sql_action.GetProcedure("PR_PERF_USUA_RE01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<PYS_Entidad.E_TA_PERF_USUA> list = new List<PYS_Entidad.E_TA_PERF_USUA>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                PYS_Entidad.E_TA_PERF_USUA O_TA_PERF_USUA = new PYS_Entidad.E_TA_PERF_USUA();
                O_TA_PERF_USUA.FS_COD_PFUS = ds.Tables[0].Rows[i]["FS_COD_PFUS"].ToString();
                O_TA_PERF_USUA.FS_DES_PFUS = ds.Tables[0].Rows[i]["FS_DES_PFUS"].ToString();
                O_TA_PERF_USUA.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_PERF_USUA.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_PERF_USUA.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_PERF_USUA.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_PERF_USUA);
            }

            return list;

        }
    }
}
