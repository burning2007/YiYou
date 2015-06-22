using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yiyou.Log;
using Yiyou.Model;
using Yiyou.SQLServerDAL;
using System.Text;
using Yiyou.Util;
using System.IO;

namespace ICUPro.Portal
{
    public partial class MyCase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitUI();
            }
        }

        private void InitUI()
        {
            if (Page.Request.QueryString["patname"] != null)
            {
                this.txtName.Text = Page.Request.QueryString["patname"];
            }
            if (Page.Request.QueryString["gender"] != null)
            {
                this.txtGender.Text = Page.Request.QueryString["gender"];
            }
            if (Page.Request.QueryString["dob"] != null)
            {
                this.txtAge.Text = Page.Request.QueryString["dob"];
            }

            string userGUID = "";
            string patientName = "";
            if (Page.Request.QueryString["userid"] != null)
            {
                userGUID = Page.Request.QueryString["userid"];
            }
            if (Page.Request.QueryString["patname"] != null)
            {
                patientName = Page.Request.QueryString["patname"];
            }


            DataSet ds = EMR_PatientMdlDAL.GetEMRDetailList(userGUID, patientName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("imgthumbnail", typeof(string));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["thumbnail"] is DBNull)
                    {
                        row["imgthumbnail"] = "";
                    }
                    else
                    {
                        string strTempFolder = ImageUtils.GetTempFolderPath();
                        byte[] bImage = (byte[])(row["thumbnail"]);
                        string strFileName = Guid.NewGuid().ToString() + ".jpg";
                        string strFilePath = Path.Combine(strTempFolder, strFileName);
                        File.WriteAllBytes(strFilePath, bImage);
                        string strThumbnailCtrl = string.Format("<img width=\"100\" height=\"100\" src=\"/temp/{0}\" />", strFileName);
                        row["imgthumbnail"] = strThumbnailCtrl;
                    }
                }
            }
            this.rptList.DataSource = ds.Tables[0];
            this.rptList.DataBind();
        }
    }
}