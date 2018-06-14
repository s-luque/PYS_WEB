using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS_SQL
{
    public class SQL_Setting
    {
        private SQL_Setting(SQL_Action_Config sql_action)
        {
            Util.s_sql_action = sql_action;
        }
    }
}
