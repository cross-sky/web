using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using WebApplication1.DAL;

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

    public class BLL_PubClient
    {
        public DataTable ChartValue(string dbstring, string ctime)
        {
            MySqlParameter[] sqlCmdPas = {
                                             new MySqlParameter("name", MySqlDbType.VarChar),
                                             new MySqlParameter("dbstring", MySqlDbType.VarChar),
                                             new MySqlParameter("stime", MySqlDbType.DateTime)
                                         };
            sqlCmdPas[0].Value = "ChartValue";
            sqlCmdPas[1].Value = dbstring;
            sqlCmdPas[2].Value = ctime;

            PubMysqlMethod mychart = new PubMysqlMethod();

            DataTable dt = mychart.pDalSelectDBpar("chartvalue", sqlCmdPas);
            return dt;
        }
    }
}