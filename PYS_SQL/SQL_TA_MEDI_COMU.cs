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
    public class SQL_TA_MEDI_COMU
    {
        private SQL_Action_Config s_sql_action = new SQL_Action_Config();
        private DataSet ds;

        public void Insertar(E_TA_MEDI_COMU O_TA_MEDI_COMU)

        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_AD01", O_TA_MEDI_COMU.FS_COD_MECO, O_TA_MEDI_COMU.FS_NOM_MECO, 
                                                 O_TA_MEDI_COMU.FS_DES_DIRE_MECO, O_TA_MEDI_COMU.FS_TIP_MECO, O_TA_MEDI_COMU.FS_NOM_CONT,
                                                 O_TA_MEDI_COMU.FS_COD_PAIS, O_TA_MEDI_COMU.FS_COD_UBIC_GEOG, O_TA_MEDI_COMU.FS_NUM_TEL1,
                                                  O_TA_MEDI_COMU.FS_NUM_TEL2, O_TA_MEDI_COMU.FS_NUM_FAXS, O_TA_MEDI_COMU.FS_NOM_MAIL,
                                                   O_TA_MEDI_COMU.FS_DIR_WEBB, O_TA_MEDI_COMU.FS_NUM_RUCS, O_TA_MEDI_COMU.FS_COD_USCR);
            s_sql_action.ExecuteNonQuery(cmd);
        }


        public void Actualizar(E_TA_MEDI_COMU O_TA_MEDI_COMU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_AC01", O_TA_MEDI_COMU.FS_COD_MECO, O_TA_MEDI_COMU.FS_NOM_MECO, 
                                                 O_TA_MEDI_COMU.FS_DES_DIRE_MECO, O_TA_MEDI_COMU.FS_TIP_MECO, O_TA_MEDI_COMU.FS_NOM_CONT, 
                                                 O_TA_MEDI_COMU.FS_COD_PAIS, O_TA_MEDI_COMU.FS_COD_UBIC_GEOG, O_TA_MEDI_COMU.FS_NUM_TEL1
                                                 , O_TA_MEDI_COMU.FS_NUM_TEL2, O_TA_MEDI_COMU.FS_NUM_FAXS, O_TA_MEDI_COMU.FS_NOM_MAIL
                                                 , O_TA_MEDI_COMU.FS_DIR_WEBB, O_TA_MEDI_COMU.FS_NUM_RUCS, O_TA_MEDI_COMU.FS_COD_USMO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public void Eliminar(E_TA_MEDI_COMU O_TA_MEDI_COMU)
        {
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_EL01", O_TA_MEDI_COMU.FS_COD_MECO);
            s_sql_action.ExecuteNonQuery(cmd);
        }

        public E_TA_MEDI_COMU Buscar_Por_Codigo(string P_FS_COD_MECO)
        {
            E_TA_MEDI_COMU O_TA_MEDI_COMU = new E_TA_MEDI_COMU();
            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_BU01", P_FS_COD_MECO);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0)
            {
                O_TA_MEDI_COMU.FS_COD_MECO = "";
            }
            else
            {
                O_TA_MEDI_COMU.FS_COD_MECO = ds.Tables[0].Rows[0]["FS_COD_MECO"].ToString();
                O_TA_MEDI_COMU.FS_NOM_MECO = ds.Tables[0].Rows[0]["FS_NOM_MECO"].ToString();
                O_TA_MEDI_COMU.FS_DES_DIRE_MECO = ds.Tables[0].Rows[0]["FS_DES_DIRE_MECO"].ToString();
                O_TA_MEDI_COMU.FS_TIP_MECO = ds.Tables[0].Rows[0]["FS_TIP_MECO"].ToString();
                O_TA_MEDI_COMU.FS_NOM_CONT = ds.Tables[0].Rows[0]["FS_NOM_CONT"].ToString();
                O_TA_MEDI_COMU.FS_COD_PAIS = ds.Tables[0].Rows[0]["FS_COD_PAIS"].ToString();
                O_TA_MEDI_COMU.FS_COD_UBIC_GEOG = ds.Tables[0].Rows[0]["FS_COD_UBIC_GEOG"].ToString();
                O_TA_MEDI_COMU.FS_NUM_TEL1 = ds.Tables[0].Rows[0]["FS_NUM_TEL1"].ToString();
                O_TA_MEDI_COMU.FS_NUM_TEL2 = ds.Tables[0].Rows[0]["FS_NUM_TEL2"].ToString();
                O_TA_MEDI_COMU.FS_NUM_FAXS = ds.Tables[0].Rows[0]["FS_NUM_FAXS"].ToString();
                O_TA_MEDI_COMU.FS_NOM_MAIL = ds.Tables[0].Rows[0]["FS_NOM_MAIL"].ToString();
                O_TA_MEDI_COMU.FS_DIR_WEBB = ds.Tables[0].Rows[0]["FS_DIR_WEBB"].ToString();
                O_TA_MEDI_COMU.FS_NUM_RUCS = ds.Tables[0].Rows[0]["FS_NUM_RUCS"].ToString();

                O_TA_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[0]["FS_COD_USCR"].ToString();
                O_TA_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USCR"].ToString());
                O_TA_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[0]["FS_COD_USMO"].ToString();
                O_TA_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[0]["FD_FEC_USMO"].ToString());
            }
            return O_TA_MEDI_COMU;
        }

        public List<E_TA_MEDI_COMU> Listado(int P_FI_COD_EMPR)
        {

            s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
            var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_CA01", P_FI_COD_EMPR);
            ds = new DataSet();
            ds = s_sql_action.ExecuteDataSet(cmd);

            List<E_TA_MEDI_COMU> list = new List<E_TA_MEDI_COMU>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                E_TA_MEDI_COMU O_TA_MEDI_COMU = new E_TA_MEDI_COMU();
                O_TA_MEDI_COMU.FS_COD_MECO = ds.Tables[0].Rows[i]["FS_COD_MECO"].ToString();
                O_TA_MEDI_COMU.FS_NOM_MECO = ds.Tables[0].Rows[i]["FS_NOM_MECO"].ToString();
                O_TA_MEDI_COMU.FS_DES_DIRE_MECO = ds.Tables[0].Rows[i]["FS_DES_DIRE_MECO"].ToString();
                O_TA_MEDI_COMU.FS_TIP_MECO = ds.Tables[0].Rows[i]["FS_TIP_MECO"].ToString();
                O_TA_MEDI_COMU.FS_NOM_CONT = ds.Tables[0].Rows[i]["FS_NOM_CONT"].ToString();
                O_TA_MEDI_COMU.FS_COD_PAIS = ds.Tables[0].Rows[i]["FS_COD_PAIS"].ToString();
                O_TA_MEDI_COMU.FS_COD_UBIC_GEOG = ds.Tables[0].Rows[i]["FS_COD_UBIC_GEOG"].ToString();
                O_TA_MEDI_COMU.FS_NUM_TEL1 = ds.Tables[0].Rows[i]["FS_NUM_TEL1"].ToString();
                O_TA_MEDI_COMU.FS_NUM_TEL2 = ds.Tables[0].Rows[i]["FS_NUM_TEL2"].ToString();
                O_TA_MEDI_COMU.FS_NUM_FAXS = ds.Tables[0].Rows[i]["FS_NUM_FAXS"].ToString();
                O_TA_MEDI_COMU.FS_NOM_MAIL = ds.Tables[0].Rows[i]["FS_NOM_MAIL"].ToString();
                O_TA_MEDI_COMU.FS_DIR_WEBB = ds.Tables[0].Rows[i]["FS_DIR_WEBB"].ToString();
                O_TA_MEDI_COMU.FS_NUM_RUCS = ds.Tables[0].Rows[i]["FS_NUM_RUCS"].ToString();

                O_TA_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
                O_TA_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
                O_TA_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
                O_TA_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

                list.Add(O_TA_MEDI_COMU);
            }

            return list;

        }

        //public List<E_TA_MEDI_COMU> Reporte(int P_FI_COD_EMPR)
        //{
        //    s_sql_action.Data_Base_Name = s_sql_action.val_BD_PLAN;
        //    var cmd = s_sql_action.GetProcedure("PR_MEDI_COMU_RE01", P_FI_COD_EMPR);
        //    ds = new DataSet();
        //    ds = s_sql_action.ExecuteDataSet(cmd);

        //    List<E_TA_MEDI_COMU> list = new List<E_TA_MEDI_COMU>();

        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        E_TA_MEDI_COMU O_TA_MEDI_COMU = new E_TA_MEDI_COMU();
        //        O_TA_MEDI_COMU.FS_COD_MECO = ds.Tables[0].Rows[i]["FS_COD_MECO"].ToString();
        //        O_TA_MEDI_COMU.FS_TIP_EVAL = ds.Tables[0].Rows[i]["FS_TIP_EVAL"].ToString();
        //        O_TA_MEDI_COMU.FS_COD_CCAR = ds.Tables[0].Rows[i]["FS_COD_CCAR"].ToString();

        //        O_TA_MEDI_COMU.FI_COD_EMPR = Convert.ToInt32(ds.Tables[0].Rows[i]["FI_COD_EMPR"].ToString());

        //        O_TA_MEDI_COMU.FS_DES_EVAL_DESE = ds.Tables[0].Rows[i]["FS_DES_EVAL_DESE"].ToString();
        //        O_TA_MEDI_COMU.FS_DES_OBSE = ds.Tables[0].Rows[i]["FS_DES_OBSE"].ToString();

        //        O_TA_MEDI_COMU.FS_COD_USCR = ds.Tables[0].Rows[i]["FS_COD_USCR"].ToString();
        //        O_TA_MEDI_COMU.FD_FEC_USCR = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USCR"].ToString());
        //        O_TA_MEDI_COMU.FS_COD_USMO = ds.Tables[0].Rows[i]["FS_COD_USMO"].ToString();
        //        O_TA_MEDI_COMU.FD_FEC_USMO = Convert.ToDateTime(ds.Tables[0].Rows[i]["FD_FEC_USMO"].ToString());

        //        list.Add(O_TA_MEDI_COMU);
        //    }

        //    return list;

        //}



    }
}
