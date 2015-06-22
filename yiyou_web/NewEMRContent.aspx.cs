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
    public partial class NewEMRContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet dsEMRType = EMR_PatientMdlDAL.GetEMRType();
                this.ddlEMRType.DataTextField = "name";
                this.ddlEMRType.DataValueField = "guid";
                this.ddlEMRType.DataSource = dsEMRType.Tables[0];
                this.ddlEMRType.DataBind();
            }
        }

        protected void btnUploadEMR_Click(object sender, EventArgs e)
        {
            string strSavedFile = ImageUtils.uploadImageFile(this.FileUpload_EMR, litEMRImg, Page);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strSavedFile = ImageUtils.uploadImageFile(this.FileUpload_EMR, litEMRImg, Page);

        }


    }
}