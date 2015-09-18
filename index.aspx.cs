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

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt_userinfo = BLL.BLL_Index.SelectUserinfo();
            //GridView1.DataSource = dt_userinfo;
            // tableVar.dbvar = dt_userinfo;
            // GridView1.DataBind();
            if (!IsPostBack)
            {
                string data1 = this.d12.Value.Trim();
                string data2 = this.d13.Value.Trim();

                DaltableVar daldb = new BLL.DaltableVar();
                daldb = BLL.BLL_Index.SelectDays(data1, data2);
                GridView1.DataSource = daldb.dbvar;
                tableVar.dbvar = daldb.dbvar;
                tableVar.sfile = daldb.sfile;
                tableVar.stitle = daldb.stitle;
                GridView1.DataBind();
                Label1t1.Text = "kalaok0";

            }


        }


        protected void B_que1_Click(object sender, EventArgs e)
        {
            string data1 = this.d12.Value.Trim();
            string data2 = this.d13.Value.Trim();

            Label1t1.Text = "natsuki";

            DaltableVar daldb = new BLL.DaltableVar();
            daldb = BLL.BLL_Index.SelectDays(data1, data2);
            GridView1.DataSource = daldb.dbvar;
            tableVar.dbvar = daldb.dbvar;
            tableVar.sfile = daldb.sfile;
            tableVar.stitle = daldb.stitle;
            //DataTable dt_cur = BLL.BLL_Index.SelectCurrentDay();
            //GridView1.DataSource = dt_cur;
            //tableVar.dbvar = dt_cur;
            GridView1.DataBind();       
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = tableVar.dbvar;
            GridView1.DataBind();
            //InitPage(); //重新绑定GridView数据的函数
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*
         * http://blog.csdn.net/drr789/article/details/7949018
          protected void getRefSet(DataSet ds)
        {
            lblCurrentIndex.Text = "第 " + (GridView1.PageIndex + 1).ToString() + " 页";
            lblPageCount.Text = "共 " + GridView1.PageCount.ToString() + " 页";
            lblRecordCount.Text = "总共 " + ds.Tables[0].Rows.Count.ToString() + " 条";

            if (ds.Tables[0].Rows.Count == 0)
            {
                lnkbtnFirst.Visible = false;
                lnkbtnPre.Visible = false;
                lnkbtnNext.Visible = false;
                lnkbtnLast.Visible = false;

                lblCurrentIndex.Visible = false;
                lblPageCount.Visible = false;
                lblRecordCount.Visible = false;
            }
            else if (GridView1.PageCount == 1)
            {
                lnkbtnFirst.Visible = false;
                lnkbtnPre.Visible = false;
                lnkbtnNext.Visible = false;
                lnkbtnLast.Visible = false;
            }
            lnkbtnFirst.CommandArgument = "1";
            lnkbtnPre.CommandArgument = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());
            lnkbtnNext.CommandArgument = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
            lnkbtnLast.CommandArgument = GridView1.PageCount.ToString(); 
        }
         * 
         *         protected void PagerButtonClick(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument) - 1;
            GridView1.DataSource = tableVar.dbvar;
            GridView1.DataBind();
        }

        protected void lnkbtnJumpPage_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = int.Parse(txtJumpPage.Text) - 1;
            lblCurrentIndex.Text = "第 " + (GridView1.PageIndex + 1).ToString() + " 页";
            GridView1.DataSource = tableVar.dbvar;
            GridView1.DataBind();
        }
         * 
         * 
         */





        public class tableVar
        {
            public static DataTable dbvar;
            public static string stitle;
            public static string sfile;
        }

        protected void B_save_Click(object sender, EventArgs e)
        {

            string filename = tableVar.stitle;
            string filepath = tableVar.sfile;

            BLL.BLL_Index.DataToCsv(tableVar.dbvar, filepath);
            FileInfo infofile = new FileInfo(filepath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.AddHeader("Content-Length", infofile.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(infofile.FullName);
            Response.Flush();
            Response.End();

        }


    }
}


