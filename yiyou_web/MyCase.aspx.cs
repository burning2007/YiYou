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
                if (Page.Request.QueryString["patient_guid"] != null
                    && Page.Request.QueryString["type"] != null && Page.Request.QueryString["type"] == "new")
                {
                    // createNewEMR()
                    Page.ClientScript.RegisterStartupScript(typeof(string), "createNewEMR", "createNewEMR();", true);
                }
            }
            else
            {

            }
        }

        protected void btnUploadEMR_Click(object sender, EventArgs e)
        {
            string strSavedFile = ImageUtils.uploadImageFile(this.FileUpload_EMR, this.litEMRImg, Page);
            if (!string.IsNullOrEmpty(strSavedFile))
            {
                this.hidEMRImageURL.Value = strSavedFile;
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), "createNewEMR", "createNewEMR();", true);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            this.RefreshEMRListByPatientUidAndEMRType();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            emr_indexMdl emr_indexMdl = new emr_indexMdl();
            emr_indexMdl.guid = Guid.NewGuid().ToString();
            emr_indexMdl.patient_guid = this.hidPatientGUID.Value;
            emr_indexMdl.type_guid = this.ddlEMRType.SelectedValue;
            emr_indexMdl.type_name = this.ddlEMRType.SelectedItem.Text;
            emr_indexMdl.content = this.txtContent.Text;

            if (this.hidEMRImageURL.Value != "" && File.Exists(this.hidEMRImageURL.Value))
                emr_indexMdl.img_count = 1;
            else
                emr_indexMdl.img_count = 0;

            // Save EMR Basic
            EMR_PatientMdlDAL.Add_emr_index(emr_indexMdl);

            if (this.hidEMRImageURL.Value != "" && File.Exists(this.hidEMRImageURL.Value))
            {
                emr_imageMdl emr_imageMdl = new emr_imageMdl();
                emr_imageMdl.guid = Guid.NewGuid().ToString();
                emr_imageMdl.emr_guid = emr_indexMdl.guid;
                emr_imageMdl.img_type = 0;
                emr_imageMdl.img_content = File.ReadAllBytes(this.hidEMRImageURL.Value);
                emr_imageMdl.thumbnail = ImageUtils.getThumbnail(emr_imageMdl.img_content);

                // Save EMR Image
                EMR_PatientMdlDAL.Add_emr_image(emr_imageMdl);
            }

            // Clear filter
            this.hidFilterType.Value = "";

            // After save, refresh the EMR list
            this.RefreshEMRListByPatientUidAndEMRType();

            // Clear input
            this.txtContent.Text = "";
            this.txtContent_t.Text = "";
            this.litEMRImg.Text = "";
        }


        private void InitUI()
        {
            DataSet dsEMRType = EMR_PatientMdlDAL.GetEMRType();
            this.rptEMRType.DataSource = dsEMRType.Tables[0];
            this.rptEMRType.DataBind();
            this.ddlEMRType.DataTextField = "name";
            this.ddlEMRType.DataValueField = "guid";
            this.ddlEMRType.DataSource = dsEMRType.Tables[0];
            this.ddlEMRType.DataBind();


            if (Page.Request.QueryString["patient_guid"] != null)
            {
                #region Come from the Worklist
                this.hidPatientGUID.Value = Page.Request.QueryString["patient_guid"];
                RefreshEMRListByPatientUidAndEMRType();
                EMR_PatientMdl mdl = EMR_PatientMdlDAL.GetModel(this.hidPatientGUID.Value);
                this.txtName.Text = mdl.name;
                if (mdl.gender == 0)
                {
                    this.txtGender.Text = "未知";
                }
                if (mdl.gender == 1)
                {
                    this.txtGender.Text = "女";
                }
                if (mdl.gender == 2)
                {
                    this.txtGender.Text = "男";
                }
                DateTime dtDOB = Convert.ToDateTime(mdl.birthday);
                this.txtAge.Text = dtDOB.ToString("yyyy-MM-dd");
                #endregion
            }
            else
            {
                #region Come from the Application Request Page
                if (Page.Request.QueryString["patname"] != null && Page.Request.QueryString["patname"].Trim().Length > 0)
                {
                    this.txtName.Text = Page.Request.QueryString["patname"];
                }
                else
                    return;
                if (Page.Request.QueryString["gender"] != null)
                {
                    this.txtGender.Text = Page.Request.QueryString["gender"];
                }
                else
                    return;
                if (Page.Request.QueryString["dob"] != null)
                {
                    this.txtAge.Text = Page.Request.QueryString["dob"];
                }
                else
                    return;

                string userGUID = "";
                string patientName = "";
                if (Page.Request.QueryString["userid"] != null)
                {
                    userGUID = Page.Request.QueryString["userid"];
                }
                else
                    return;
                if (Page.Request.QueryString["patname"] != null)
                {
                    patientName = Page.Request.QueryString["patname"];
                }
                else
                    return;


                // First, check if the patient is exist or not
                #region Check Patient and Create New Patient
                if (EMR_PatientMdlDAL.IsExist(patientName, userGUID))
                {
                    this.hidPatientGUID.Value = EMR_PatientMdlDAL.GetPatientGUID(patientName, userGUID);
                }
                else
                {
                    // This patient is not exist, create new one
                    EMR_PatientMdl newPatient = new EMR_PatientMdl();
                    newPatient.patient_guid = Guid.NewGuid().ToString();
                    newPatient.user_guid = userGUID;
                    newPatient.name = patientName;
                    int nGender = 0;
                    int.TryParse(Page.Request.QueryString["genderType"], out nGender);
                    newPatient.gender = nGender;
                    DateTime dtDOB = DateTime.Now;
                    DateTime.TryParse(Page.Request.QueryString["dob"], out dtDOB);
                    newPatient.birthday = dtDOB;
                    EMR_PatientMdlDAL.Add(newPatient);
                    this.hidPatientGUID.Value = newPatient.patient_guid;
                }
                #endregion


                // Bind EMR Detail List
                RefreshEMRListByPatientUidAndEMRType();


                #endregion
            }


        }

        private void RefreshEMRListByPatientUidAndEMRType()
        {
            DataSet ds = EMR_PatientMdlDAL.GetEMRDetailListByPatientUID(this.hidPatientGUID.Value, this.hidFilterType.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.hidPatientGUID.Value = ds.Tables[0].Rows[0]["patient_guid"].ToString();
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
                this.rptList.DataSource = ds.Tables[0];
                this.rptList.DataBind();
            }
            else
            {
                this.rptList.DataSource = null;
                this.rptList.DataBind();
            }
        }

    }
}