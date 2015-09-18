using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PublicMethod
    {
        //提取数据库中的数据
        public static DataTable DAL_SelectDB_Par(string sqlstr, SqlParameter[] SQlCMDpas)
        {
            //创建链接对象
            DataPublicVar.sqlcn = new SqlConnection(DataPublicVar.jcglstr.ToString());
            DataPublicVar.sqlcn.Open();
            //创建cmd
            DataPublicVar.sqlstr = sqlstr;
            DataPublicVar.sqlcmd = new SqlCommand(DataPublicVar.sqlstr, DataPublicVar.sqlcn);
            DataPublicVar.sqlcmd.CommandType = CommandType.StoredProcedure;
            //利用数组动态参数化存储过程的参数
            foreach (SqlParameter var in SQlCMDpas)
            {
                DataPublicVar.sqlcmd.Parameters.Add(var);
            }

            SqlDataReader dr = DataPublicVar.sqlcmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataPublicVar.sqlcn.Close();
            dr.Close();
            return dt;
            //创建链接对象

            //DataPublicVar.sqlcn = new SqlConnection(DataPublicVar.jcglstr.ToString());
            ////创建cmd
            //DataPublicVar.sqlstr = sqlstr;
            //DataPublicVar.sqlcmd = new SqlCommand(DataPublicVar.sqlstr, DataPublicVar.sqlcn);
            //DataPublicVar.sqlcmd.CommandType = CommandType.StoredProcedure;
            ////  //利用数组动态参数化存储过程的参数
            //foreach (SqlParameter var in SQlCMDpas)
            //{
            //    DataPublicVar.sqlcmd.Parameters.Add(var);
            //}

            //DataTable dt = new DataTable();
            ////执行SqlDataAdapter
            //DataPublicVar.sqlda = new SqlDataAdapter(DataPublicVar.sqlcmd);
            ////填充数据到dt，并返回
            //DataPublicVar.sqlda.Fill(dt);
            // return dt;

        }


        //插入、更新、删除数据库中的数据
        public static void DAL_OPTableDB_Par(string sqlstr, SqlParameter[] SQlCMDpas)
        {
            //创建链接对象
            DataPublicVar.sqlcn = new SqlConnection(DataPublicVar.jcglstr.ToString());
            DataPublicVar.sqlcn.Open();
            //创建cmd

            DataPublicVar.sqlstr = sqlstr;
            DataPublicVar.sqlcmd = new SqlCommand(DataPublicVar.sqlstr, DataPublicVar.sqlcn);
            DataPublicVar.sqlcmd.CommandType = CommandType.StoredProcedure;
            //利用数组动态参数化存储过程的参数
            foreach (SqlParameter var in SQlCMDpas)
            {
                DataPublicVar.sqlcmd.Parameters.Add(var);
            }
            DataPublicVar.sqlcmd.ExecuteNonQuery();
            DataPublicVar.sqlcn.Close();
            //return i;

        }
    }
}
