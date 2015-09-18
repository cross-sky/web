using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace WebApplication1.BLL
{
    public class BLL_client
    {
        public static DataTable SelectLatestValue(string dbstring)
        {
            //string strcurrent = DateTime.Now.;
            //string strcurrent = DateTime.Now.ToString("yyyy-MM-dd");
            //strcurrent += " :00:00:00";
            //call slvalue("sLatestValue", "dbgprs.gprs");
            MySqlParameter[] SqlCmdPas = {
                                             new MySqlParameter("name", MySqlDbType.VarChar),
                                             //new MySqlParameter("datastr", MySqlDbType.DateTime),
                                             new MySqlParameter("dbstring", MySqlDbType.VarChar),
                                         };

            SqlCmdPas[0].Value = "sLatestValue";
            SqlCmdPas[1].Value = dbstring;
            DataTable dt = WebApplication1.DAL.mysqlMethod.DalSelectDBpar("slvalue", SqlCmdPas);
            return dt;
        }
    }
}