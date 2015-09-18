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
    public class BLL_Index
    {
        public static DataTable SelectUserinfo()
        {
            MySqlParameter[] SQLCMDpas ={
                                           new MySqlParameter("name",MySqlDbType.VarChar),
                                       };
            SQLCMDpas[0].Value = "select_user";
            DataTable dt = WebApplication1.DAL.mysqlMethod.DalSelectDBpar("lgprs", SQLCMDpas);//存储过程名字？
            return dt;
        }

        public static DataTable SelectCurrentDay()
        {
            //string strcurrent = DateTime.Now.;
            string strcurrent = DateTime.Now.ToString("yyyy-MM-dd");
            //strcurrent += " :00:00:00";

            MySqlParameter[] SqlCmdPas = {
                                             new MySqlParameter("name", MySqlDbType.VarChar),
                                             new MySqlParameter("datastr", MySqlDbType.DateTime),
                                         };

            SqlCmdPas[0].Value = "select_current";
            SqlCmdPas[1].Value = strcurrent;
            DataTable dt = WebApplication1.DAL.mysqlMethod.DalSelectDBpar("scgprs", SqlCmdPas);
            return dt;
        }

        public static DataTable SelectDay()
        {
            //string strcurrent = DateTime.Now.;
            string strcurrent = DateTime.Now.ToString("yyyy-MM-dd");
            //strcurrent += " :00:00:00";

            MySqlParameter[] SqlCmdPas = {
                                             new MySqlParameter("name", MySqlDbType.VarChar),
                                             new MySqlParameter("datastr", MySqlDbType.DateTime),
                                         };

            SqlCmdPas[0].Value = "select_current";
            SqlCmdPas[1].Value = strcurrent;
            DataTable dt = WebApplication1.DAL.mysqlMethod.DalSelectDBpar("scgprs", SqlCmdPas);
            return dt;
            
        }

        public static void DataToCsv(DataTable db,  string file)
        {
            string title="";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            for (int i = 0; i < db.Columns.Count; i++ )
            {
                title += db.Columns[i].ColumnName + ",\t";

            }

            title = title.Substring(0, title.Length - 1) + "\n";

            sw.Write(title);

            foreach (DataRow row in db.Rows)
            {
                string line = "";
                for (int i = 0; i < db.Columns.Count; i++ )
                {
                    line += row[i].ToString().Trim() + ",\t";
                }
                line = line.Substring(0, line.Length - 1) + "\n";
                sw.Write(line);
            }
            sw.Close();
            fs.Close();

        }

        //data1  null sele1 >curr
        //data2  null sele2 >curr
        //9种状态

        //小于零 x 小于 y。 或 x 为 空引用,
        // 0 x 等于 y
        //>0 x 大于 y。 或 y 为 空引用
        public static DaltableVar SelectDays(string data1, string data2)
        {
            DaltableVar dvar=new BLL.DaltableVar();
            string strcurrent = DateTime.Now.ToString("yyyy-MM-dd");
            int s1cur = string.Compare(data1, strcurrent);
            int s2cur = string.Compare(data2, strcurrent);
            int s1s2 = string.Compare(data1,data2);

            string day1="", day2="";


            if ( s1s2 >0  )
            {
                if (s1cur > 0)
                {
                    dvar.selectmodes = 0;
                    dvar.stitle = strcurrent + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    dvar.dbvar = SelectCurrentDay();
                    return dvar;
                }
                else
                {
                    dvar.selectmodes = 1;
                    dvar.stitle = data1 + "-" + strcurrent + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    day1 = data1;
                    day2 = strcurrent;
                }             
            }
            else if (data1 == "")
            {
                if (data2 == "" || s2cur > 0)
                {
                    dvar.selectmodes = 0;
                    dvar.stitle = strcurrent + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    dvar.dbvar = SelectCurrentDay();
                    return dvar;
                }
                else
                {
                    dvar.selectmodes = 2;
                    dvar.stitle = data2 + "-" + strcurrent + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    day1 = data2;
                    day2 = strcurrent;
                    //dvar.dbvar = BLL.BLL_Index.SelectCurrentDay();
                    //return dvar;

                }
            }
            else if (s1cur <= 0)
            {
                if (data2 == "" || s2cur > 0)
                {
                    dvar.selectmodes = 1;
                    dvar.stitle = data1 + "-" + strcurrent + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    day1 = data1;
                    day2 = strcurrent;
                }
                else
                {
                    dvar.selectmodes = 3;
                    dvar.stitle = data1 + "-" + data2 + @".csv";
                    dvar.sfile = @"e:\save\" + dvar.stitle ;
                    day1 = data1;
                    day2 = data2;
                }
            }

            dvar.dbvar = SelecBetween(day1, day2);

            return dvar;

        }


        public static DataTable SelecBetween(string data1, string data2)
        {
            MySqlParameter[] SqlCmdPas = {
                                             new MySqlParameter("name", MySqlDbType.VarChar),
                                             new MySqlParameter("datastr1", MySqlDbType.DateTime),
                                             new MySqlParameter("datastr2", MySqlDbType.DateTime),
                                         };

            SqlCmdPas[0].Value = "select_between";
            SqlCmdPas[1].Value = data1;
            SqlCmdPas[2].Value = data2;
            DataTable dt = WebApplication1.DAL.mysqlMethod.DalSelectDBpar("sbtgprs", SqlCmdPas);
            return dt;
            
        }




        //internal static DaltableVar SelectDay(string data1, string data2)
        //{
       //     throw new NotImplementedException();
       // }
    }

    public class DaltableVar
    {
        public  DataTable dbvar;
        public  string stitle;
        public  string sfile;
        public  int selectmodes;
    }
}