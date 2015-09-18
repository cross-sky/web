using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DataPublicVar
    {
        //public static string jcglstr = Properties.Settings.Default.Setting;driver={SQL Server};server=主机ip地址; uid=用户名;pwd=密码;database=数据库名
        public static string jcglstr = @"Data Source=(local);Initial Catalog=WebSite1;Integrated Security=True";
        public static SqlCommand sqlcmd;//定义命令语句
        public static string sqlstr;
        public static SqlDataAdapter sqlda;//定义识别器
        public static DataSet ds = new DataSet();//定义数据集
        public static SqlDataReader sqldr;//定义只读器
        public static DataTable dt;//定义数据表
        public static DataRow dr;//定义行
        public static SqlConnection sqlcn;
    }
}
