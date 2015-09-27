using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication1.DAL;
using WebApplication1.BLL;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;


namespace WebApplication1
{
    public partial class client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ULLselectLastValue();
                
            }

        }

        /*
         * 
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]// 如果要使用Get方式请求，去掉这个标记
        public static string jlvalue()
        {
            ites++;
            return ites.ToString();
        }
         * */

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]// 如果要使用Get方式请求，去掉这个标记
        public static string jlvalue()
        {
            //ites++;
            return ites.ToString();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]// 如果要使用Get方式请求，去掉这个标记
        public static IList<string> jlvalue1()
        {
            dbcvar = BLL.BLL_client.SelectLatestValue(dbstring);
            ites++;
            mlist.Clear();
            mlist.Add(ites.ToString());
            string stre;
            for (int i = 8; i <= 10; i++ )
            {
                stre = dbcvar.Rows[0][i].ToString();
                mlist.Add(stre);
            }          
            return mlist;
        }

        public  void ULLselectLastValue()
        {
            
            dbcvar = BLL.BLL_client.SelectLatestValue(dbstring);
            Lat4.Text = dbcvar.Rows[0][8].ToString() + "℃";
            Lat2.Text = dbcvar.Rows[0][9].ToString() + "℃";
            Lat3.Text = dbcvar.Rows[0][10].ToString() + "℃";

            mlist.Add(Lat2.Text);
            mlist.Add(Lat3.Text);
            mlist.Add(Lat4.Text);

           // return "ok";
        }

        public static string dbstring = "dbgprs.gprs";
        public static int ites=0;
        public static DataTable dbcvar;
        public static IList<string> mlist = new List<string>();

    }
}