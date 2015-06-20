﻿///
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
                Session["USER_GUID"] = "7";

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
        // ********** Update Status ********** 
        //0—未提交（开始用户阶段）
        //1—已提交
        //2—已接受（待付初审费）
        //3—已付初审费
        //4—初审中
        //5—已初审（待付会诊费）
        //6—已付会诊费
        //7—会诊中
        //8—已出结论
        //9—已翻译
        //99—已完成

        /// </summary>
        private void RefreshApplicationStatusCnt()
        {
            this.lblStatus_All.Text = WorklistDAL.GetApplicationCount("");
            this.lblStatus_0.Text = WorklistDAL.GetApplicationCount("0");
            this.lblStatus_1.Text = WorklistDAL.GetApplicationCount("1");
            this.lblStatus_2.Text = WorklistDAL.GetApplicationCount("2");
            this.lblStatus_3.Text = WorklistDAL.GetApplicationCount("3");
            this.lblStatus_4.Text = WorklistDAL.GetApplicationCount("4");
            this.lblStatus_5.Text = WorklistDAL.GetApplicationCount("5");
            this.lblStatus_6.Text = WorklistDAL.GetApplicationCount("6");
            this.lblStatus_7.Text = WorklistDAL.GetApplicationCount("7");
            this.lblStatus_8.Text = WorklistDAL.GetApplicationCount("8");
            this.lblStatus_9.Text = WorklistDAL.GetApplicationCount("9");
            this.lblStatus_99.Text = WorklistDAL.GetApplicationCount("99");
            this.lblStatus_100.Text = WorklistDAL.GetApplicationCount("100");
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
                string gender = item["gender"].ToString();
                if (gender == "")
                    item["gendertext"] = "未知";
                else if (gender == "0")
                    item["gendertext"] = "未知";
                else if (gender == "1")
                    item["gendertext"] = "女";
                else if (gender == "2")
                    item["gendertext"] = "男";

                string Status = item["Status"].ToString();
                item["StatusText"] = Status; // Default
                if (Status == "0")
                    item["StatusText"] = "未提交";
                else if (Status == "1")
                    item["StatusText"] = "已提交";
                else if (Status == "2")
                    item["StatusText"] = "已接受";
                else if (Status == "3")
                    item["StatusText"] = "已付初审费";
                else if (Status == "4")
                    item["StatusText"] = "初审中";
                else if (Status == "5")
                    item["StatusText"] = "已初审";
                else if (Status == "6")
                    item["StatusText"] = "已付会诊费";
                else if (Status == "7")
                    item["StatusText"] = "会诊中";
                else if (Status == "8")
                    item["StatusText"] = "已出结论";
                else if (Status == "9")
                    item["StatusText"] = "已翻译";        
                else if (Status == "99")
                    item["StatusText"] = "已完成";
                else if (Status == "100")
                    item["StatusText"] = "已拒绝";
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