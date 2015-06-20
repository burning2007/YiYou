///
/// Add by Xiaoming.Zhao
/// New Application Request Page
/// 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yiyou.SQLServerDAL;

namespace ICUPro.Portal
{
    public partial class MyWorklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefreshGUI();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGUI();
        }
        /// <summary>
        /// 状态
        // 0—未提交（开始用户阶段）
        // 1—已提交
        // 10—已审核（客服介入阶段）
        // 11—已签约
        // 12—已付款
        // 20—已递交（开始专家阶段）
        // 21—已拒绝
        // 22—已出结论
        // 99—已完成（客服确认）
        /// </summary>
        private void RefreshApplicationStatusCnt()
        {
            this.lblStatus_All.Text = WorklistDAL.GetApplicationCount("");
            this.lblStatus_0.Text = WorklistDAL.GetApplicationCount("0");
            this.lblStatus_1.Text = WorklistDAL.GetApplicationCount("1");
            this.lblStatus_10.Text = WorklistDAL.GetApplicationCount("10");
            this.lblStatus_11.Text = WorklistDAL.GetApplicationCount("11");
            this.lblStatus_12.Text = WorklistDAL.GetApplicationCount("12");
            this.lblStatus_21.Text = WorklistDAL.GetApplicationCount("21");
            this.lblStatus_99.Text = WorklistDAL.GetApplicationCount("99");
        }

        private void RefreshGUI()
        {
            this.RefreshApplicationStatusCnt();


            string strFilterStatus = "";
            if (this.hidFilter.Value.Trim() != string.Empty)
            {
                strFilterStatus = this.hidFilter.Value;
            }
            DataSet ds = WorklistDAL.GetWorklist(strFilterStatus);
            ds.Tables[0].Columns.Add("CommandText");
            ds.Tables[0].Columns.Add("StatusText");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["CommandText"] = "详情";

                string Status = item["Status"].ToString();
                item["StatusText"] = Status; // Default
                if (Status == "0")
                    item["StatusText"] = "未提交";
                else if (Status == "1")
                    item["StatusText"] = "已提交";
                else if (Status == "10")
                    item["StatusText"] = "已审核";
                else if (Status == "11")
                    item["StatusText"] = "已签约";
                else if (Status == "12")
                    item["StatusText"] = "已付款";
                else if (Status == "20")
                    item["StatusText"] = "已递交";
                else if (Status == "21")
                    item["StatusText"] = "已拒绝";
                else if (Status == "22")
                    item["StatusText"] = "已出结论";
                else if (Status == "99")
                    item["StatusText"] = "已完成";
            }
            this.GridView1.PageIndex = 0;
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();

            Session["gridData"] = ds;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.Compare(e.CommandName, "PageIndexPage", true) == 0)
            {
                int nCurrentPageIndex = this.GridView1.PageIndex;
                if (e.CommandArgument.ToString() == "Prev")
                {
                    if (nCurrentPageIndex >= 1)
                    {
                        this.GridView1.PageIndex--;
                    }
                }
                else if (e.CommandArgument.ToString() == "Next")
                {
                    if (nCurrentPageIndex < this.GridView1.PageCount - 1)
                    {
                        this.GridView1.PageIndex++;
                    }
                }
                else if (e.CommandArgument.ToString() == "Last")
                {
                    this.GridView1.PageIndex = this.GridView1.PageCount - 1;
                }
                else if (e.CommandArgument.ToString() == "First")
                {
                    this.GridView1.PageIndex = 0;
                }
                else if (e.CommandArgument.ToString() == "First")
                {
                    this.GridView1.PageIndex = 0;
                }
                else if (e.CommandArgument.ToString() == "Goto")
                {
                    this.GridView1.PageIndex = int.Parse(this.hidPageIndex.Value) - 1;
                }
                this.GridView1.DataSource = Session["gridData"] as DataSet;
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                int nCurrentIndex = this.GridView1.PageIndex + 1;
                int nTotalPage = this.GridView1.PageCount;
                string strActivePagerTemplate = "<li class=\"active\"><a class=\"bg-main\">{0}</a></li>";
                string strTemplate = " <li><a onclick=\"$('#MainContent_hidPageIndex').val('{0}');$('#MainContent_GridView1_btnGotoPage').click();return false;\">{0}</a></li>";
                StringBuilder sb = new StringBuilder();
                for (int i = -5; i <= 5; i++)
                {
                    int nNewPager = nCurrentIndex + i;
                    if (nNewPager >= 1 && nNewPager <= nTotalPage)
                    {
                        if (i == 0)
                        {
                            sb.Append(string.Format(strActivePagerTemplate, nNewPager));
                        }
                        else
                        {
                            sb.Append(string.Format(strTemplate, nNewPager));
                        }
                    }
                }
                (e.Row.FindControl("litPagerIndexList") as Literal).Text = sb.ToString();
            }
        }
    }
}