using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.IO;

//System.Configuration.ConfigurationSettings.AppSettings["Kevin"].ToString()

namespace WebApplication1.DAL
{
    public class mysqlMethod
    {
        //提取数据库中的数据
        public static DataTable DalSelectDBpar(string sqlstr, MySqlParameter[] SQLCMDpas)
        {
            //创建链接对象
            //mysqlVar.sqlconn = new MySqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connstr"].ToString());
            mysqlVar.sqlconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString());

            try
            {
                mysqlVar.sqlconn.Open();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("open batabase error" + ex.Message);
            }
            //创建cmd
            mysqlVar.sqlstr = sqlstr;
            mysqlVar.sqlcmd = new MySqlCommand(mysqlVar.sqlstr, mysqlVar.sqlconn);
            mysqlVar.sqlcmd.CommandType = CommandType.StoredProcedure;
            //利用数组动态参数化存储过程的参数
            foreach (MySqlParameter var in SQLCMDpas)
            {
                mysqlVar.sqlcmd.Parameters.Add(var);
            }

            MySqlDataReader dr = mysqlVar.sqlcmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            mysqlVar.sqlconn.Close();
            dr.Close();
            return dt;

           // return dt;
        }

        //插入、更新、删除数据库中的数据
        public static void DalOpTablePar(string sqlstr, MySqlParameter[] SQLCMDpas)
        {
            mysqlVar.sqlconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString());

            try
            {
                mysqlVar.sqlconn.Open();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("open batabase error" + ex.Message);
            }

            mysqlVar.sqlstr = sqlstr;
            mysqlVar.sqlcmd = new MySqlCommand(mysqlVar.sqlstr, mysqlVar.sqlconn);
            mysqlVar.sqlcmd.CommandType = CommandType.StoredProcedure;

            foreach (MySqlParameter var in SQLCMDpas)
            {
                mysqlVar.sqlcmd.Parameters.Add(var);
            }

            mysqlVar.sqlcmd.ExecuteNonQuery();
            mysqlVar.sqlconn.Close();
        }  
    
    }

    public class PubMysqlMethod
    {
        public DataTable pDalSelectDBpar(string sqlstr, MySqlParameter[] SQLCMDpas)
        {
            //创建链接对象
            //mysqlVar.sqlconn = new MySqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connstr"].ToString());

            //mysqlVar chartSqlVar = new mysqlVar();
            pubsqlVar chartSqlVar = new pubsqlVar();

            chartSqlVar.sqlconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString());

            try
            {
                chartSqlVar.sqlconn.Open();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("open batabase error" + ex.Message);
            }
            //创建cmd
            chartSqlVar.sqlstr = sqlstr;
            chartSqlVar.sqlcmd = new MySqlCommand(chartSqlVar.sqlstr, chartSqlVar.sqlconn);
            chartSqlVar.sqlcmd.CommandType = CommandType.StoredProcedure;
            //利用数组动态参数化存储过程的参数
            foreach (MySqlParameter var in SQLCMDpas)
            {
                chartSqlVar.sqlcmd.Parameters.Add(var);
            }

            MySqlDataReader dr = chartSqlVar.sqlcmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            chartSqlVar.sqlconn.Close();
            dr.Close();
            return dt;

            // return dt;
        }
    }

}