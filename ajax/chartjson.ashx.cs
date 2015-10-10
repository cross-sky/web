using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Script.Serialization;
using System.Data;
using WebApplication1.BLL;

namespace WebApplication1.ajax
{
    /// <summary>
    /// chartjson 的摘要说明
    /// </summary>
    public class chartjson : IHttpHandler
    {
        DataTable fc;

        public void ProcessRequest(HttpContext context)
        {
            // context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            //fc = fruitdatable();

            BLL_PubClient BllChart = new BLL_PubClient();

            string strcurrent = DateTime.Now.ToString("yyyy-MM-dd");
            //string strcurrent = "2015-09-16";

            fc = BllChart.ChartValue("dbgprs.gprs", strcurrent);
            string callback = context.Request["callback"];

           // string jsonstring = DataTableToJson(fc);

            string jsonstring = ChartDataToJson(fc);            
            context.Response.Write(callback + "('" + jsonstring + "')");
            // context.Response.Write(callback  + jsonstring );
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public DataTable fruitdatable()
        {
            DataTable dt = new DataTable("fruit");
            dt.Columns.Add("name", System.Type.GetType("System.String"));
            dt.Columns.Add("t0", System.Type.GetType("System.String"));

            DataRow dRow = dt.NewRow();
            dRow["name"] = "出水";
            dRow["t0"] = "10";
            dt.Rows.Add(dRow);

            dRow = dt.NewRow();
            dRow["name"] = "进水";
            dRow["t0"] = "20";
            dt.Rows.Add(dRow);

            dRow = dt.NewRow();
            dRow["name"] = "水箱";
            dRow["t0"] = "30";
            dt.Rows.Add(dRow);

            return dt;

            /*
            for (int i = 0; i < 3; i++)
            {
                DataRow dRow = dt.NewRow();
                dRow["number"] = i.ToString();
                dRow["type"] = "apple";
                dt.Rows.Add(dRow);
            }
             * */
        }

        public string DataTableToJson(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(list);
        }

        public string ChartDataToJson(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();


            Dictionary<string, object> dict1 = new Dictionary<string, object>();
            Dictionary<string, object> dict2 = new Dictionary<string, object>();
            Dictionary<string, object> dict3 = new Dictionary<string, object>();

            dict1.Add("name","水箱温度");
            dict2.Add("name","出水温度");
            dict3.Add("name","回水温度");

            string ttemp="";
            for (int k = 0; k < dt.Rows.Count; k++ )
            {
                ttemp = "t"+k;
                if (dt.Rows[k][0].ToString() == k.ToString())
                {
                    dict1.Add(ttemp, dt.Rows[k][1].ToString());
                    dict2.Add(ttemp, dt.Rows[k][2].ToString());
                    dict3.Add(ttemp, dt.Rows[k][3].ToString());
                }
                else
                {
                    dict1.Add(ttemp,"null");
                    dict2.Add(ttemp,"null");
                    dict3.Add(ttemp,"null");
                }
            }
            list.Add(dict1);
            list.Add(dict2);
            list.Add(dict3);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(list);
        }
    }
}