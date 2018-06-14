using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PYS_Entidad;

namespace PYS_SQL
{
    public class SQL_TA_TIPO_MEDI_COMU
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;


        public void Insertar(E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_AD01", O_TA_TIPO_MEDI_COMU.FS_TIP_MECO, O_TA_TIPO_MEDI_COMU.FS_DES_TIPO_MECO, O_TA_TIPO_MEDI_COMU.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_AC01", O_TA_TIPO_MEDI_COMU.FS_TIP_MECO, O_TA_TIPO_MEDI_COMU.FS_DES_TIPO_MECO, O_TA_TIPO_MEDI_COMU.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_EL01", O_TA_TIPO_MEDI_COMU.FS_TIP_MECO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_TIPO_MEDI_COMU Buscar_Por_Codigo(string P_FS_TIP_MECO)
        {
            E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU = new E_TA_TIPO_MEDI_COMU();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_BU01", P_FS_TIP_MECO);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_TIPO_MEDI_COMU.FS_TIP_MECO = "";
            }
            else
            {
                O_TA_TIPO_MEDI_COMU.FS_TIP_MECO = ds.Tables[0].Rows[0]["FS_TIP_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_DES_TIPO_MECO = ds.Tables[0].Rows[0]["FS_DES_TIPO_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_TIPO_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_TIPO_MEDI_COMU;
        }


        public List<E_TA_TIPO_MEDI_COMU> Listado()
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_CA01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_TIPO_MEDI_COMU> list = new List<E_TA_TIPO_MEDI_COMU>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU = new E_TA_TIPO_MEDI_COMU();
                O_TA_TIPO_MEDI_COMU.FS_TIP_MECO = ds.Tables[0].Rows[i]["FS_TIP_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_DES_TIPO_MECO = ds.Tables[0].Rows[i]["FS_DES_TIPO_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_TIPO_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_TIPO_MEDI_COMU);
            }

            return list;

        }

        public List<E_TA_TIPO_MEDI_COMU> Reporte()
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_TIPO_MEDI_COMU_RE01");
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_TIPO_MEDI_COMU> list = new List<E_TA_TIPO_MEDI_COMU>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_TIPO_MEDI_COMU O_TA_TIPO_MEDI_COMU = new E_TA_TIPO_MEDI_COMU();
                O_TA_TIPO_MEDI_COMU.FS_TIP_MECO = ds.Tables[0].Rows[i]["FS_TIP_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_DES_TIPO_MECO = ds.Tables[0].Rows[i]["FS_DES_TIPO_MECO"].ToString();
                O_TA_TIPO_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_TIPO_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_TIPO_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_TIPO_MEDI_COMU);
            }

            return list;

        }
    }
}
