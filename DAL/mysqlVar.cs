using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;


namespace WebApplication1.DAL
{
    public class mysqlVar
    {
        public static string connstr;
        public static MySqlCommand sqlcmd;//定义命令语句
        public static string sqlstr;
        public static MySqlDataAdapter sqlda;//定义识别器
        public static DataSet ds = new DataSet();//定义数据集
        public static MySqlDataReader sqldr;//定义只读器
        public static DataTable dt;//定义数据表
        public static DataRow dr;//定义行
        public static MySqlConnection sqlconn;
    }

    public class pubsqlVar
    {
        public  string connstr;
        public  MySqlCommand sqlcmd;//定义命令语句
        public  string sqlstr;
        public  MySqlDataAdapter sqlda;//定义识别器
        public  DataSet ds = new DataSet();//定义数据集
        public  MySqlDataReader sqldr;//定义只读器
        public  DataTable dt;//定义数据表
        public  DataRow dr;//定义行
        public  MySqlConnection sqlconn;
    }
}