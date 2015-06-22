///
/// Add by Xiaoming.Zhao
/// New Worklist Page
/// 
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
    public partial class MyRequest : System.Web.UI.Page
    {

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.InitCtrl();
                }
                else
                {
                    this.CreateDropdownListGroup();
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                this.lblErrorMsg.Text = ex.Message;
            }
        }

        private void InitCtrl()
        {
            //DataSet dsProject = ApplicationDAL.GetProjectList();
            //this.ddlProject.DataSource = dsProject;
            //this.ddlProject.DataBind();
            //Session["dsProject"] = dsProject;      

            this.CreateDropdownListGroup();

            //DataSet dsLoction = ApplicationDAL.GetLoctionList("1");
            //this.ddlLocation.DataSource = dsLoction;
            //this.ddlLocation.DataBind();
            //Session["dsLoction"] = dsLoction;
            //ddlLocation_SelectedIndexChanged(null, null);

            lblStatus.Text = "未提交";


            this.txtName.Enabled = false;
            this.txtMobile.Enabled = false;
            this.txtEmail.Enabled = false;
            // New app
            if (Request.QueryString["guid"] == null)
            {
                // When create new application, using current login user context
                // When view and update, should use last saved user context
                V_Sys_UserMdl model = V_Sys_UserDAL.GetModel(Session["USER_GUID"].ToString());
                this.txtName.Text = model.name;
                this.txtMobile.Text = model.login_name;
                this.txtEmail.Text = model.email;
                this.hidUserGUID.Value = Session["USER_GUID"].ToString();
            }

            // View and update app
            if (Request.QueryString["guid"] != null)
            {
                string guid = Request.QueryString["guid"];
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();
                Consult_ApplicationMdl mdl = dal.GetModel(guid);
                BindGUI(mdl);
            }
        }

        protected void ddlLocalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Location by Location Type
            //this.ddlLocation.DataSource = ApplicationDAL.GetLoctionList(this.ddlLocalType.SelectedValue);
            //this.ddlLocation.DataBind();

            this.CreateDropdownListGroup();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Hospital by Location
            //this.ddlHospital.DataSource = ApplicationDAL.GetHospitalList(this.ddlLocation.SelectedValue);
            //this.ddlHospital.DataBind();
            //ddlHospital_SelectedIndexChanged(null, null);

            DropDownList ddl = sender as DropDownList;
            string id = ddl.ID.Replace("ddlLocation", "");
            DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + id) as DropDownList;
            ddlHospital.DataSource = Consult_ApplicationDAL.GetHospitalListByLoacationUID(ddl.SelectedValue);
            ddlHospital.DataBind();
            //ddlHospital_SelectedIndexChanged(null, null);
        }

        protected void ddlHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Doctor by Hospital
            //this.ddlDoctor.DataSource = ApplicationDAL.GetDoctorList(this.ddlHospital.SelectedValue, "");
            //this.ddlDoctor.DataBind();

            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                string id = ddl.ID.Replace("ddlHospital", "");
                DropDownList ddlDoctor = this.panDoctorGroup.FindControl("ddlDoctor" + id) as DropDownList;
                ddlDoctor.DataSource = Consult_ApplicationDAL.GetDoctorList(ddl.SelectedValue, "");
                ddlDoctor.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationAllInOneMdl totalMdl = this.GetMdlFromGUI();
                Consult_ApplicationMdl mdl = totalMdl.Consult_ApplicationMdl;
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();

                // Save/Update the Patient info first
                #region MyRegion
                string patient_guid = EMR_PatientMdlDAL.GetPatientGUID(totalMdl.EMR_PatientMdl.name, totalMdl.EMR_PatientMdl.user_guid);
                if (string.IsNullOrEmpty(patient_guid))
                {
                    // New
                    totalMdl.EMR_PatientMdl.patient_guid = Guid.NewGuid().ToString();  // Create new GUID
                    totalMdl.Consult_ApplicationMdl.patient_guid = totalMdl.EMR_PatientMdl.patient_guid;  // Copy GUID
                    EMR_PatientMdlDAL.Add(totalMdl.EMR_PatientMdl);
                }
                else
                {
                    // Update
                    totalMdl.EMR_PatientMdl.patient_guid = patient_guid;  // Create new GUID
                    totalMdl.Consult_ApplicationMdl.patient_guid = totalMdl.EMR_PatientMdl.patient_guid;  // Copy GUID
                    EMR_PatientMdlDAL.Update(totalMdl.EMR_PatientMdl);
                }
                #endregion


                // Continue save the others info
                if (!dal.IsExist(mdl.guid))
                {
                    // Add Consult_ApplicationMdl
                    dal.Add_consult_application(mdl);
                    // Add consult_application_consultant
                    dal.Add_consult_application_consultant(totalMdl.Consult_Application_ConsultantMdlCollection);
                    // Add the Purpose Image
                    dal.Add_consult_application_accessory(totalMdl.consult_application_accessoryMdl);

                    Page.Response.Redirect("MyWorklist.aspx");
                }
                else
                {
                    // Update Consult_ApplicationMdl
                    dal.Update_consult_application(mdl);
                    // Update consult_application_consultant
                    dal.Update_consult_application_consultant(totalMdl.Consult_Application_ConsultantMdlCollection);
                    // Update the Purpose Image
                    dal.Update_consult_application_accessory(totalMdl.consult_application_accessoryMdl);

                    Page.Response.Redirect("MyWorklist.aspx");
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                this.lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Upload image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUploadPurpose_Click(object sender, EventArgs e)
        {
            string strSavedFile = ImageUtils.uploadImageFile(FileUpload_Purpose, litPurposeImg, Page);
            if (!string.IsNullOrEmpty(strSavedFile))
            {
                this.hidPurposeImg.Value = strSavedFile;
            }
        }

        protected void ddlHospitalCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CreateDropdownListGroup();
        }
        #endregion



        #region Method
        private ApplicationAllInOneMdl GetMdlFromGUI()
        {
            ApplicationAllInOneMdl totalMdl = new ApplicationAllInOneMdl();

            // Basic info
            Consult_ApplicationMdl consultAppMdl = new Consult_ApplicationMdl();
            #region MyRegion
            // Try to get guid
            consultAppMdl.guid = this.hidGUID.Value.Trim();
            if (string.IsNullOrEmpty(consultAppMdl.guid))
            {
                // New Application Request
                consultAppMdl.guid = Guid.NewGuid().ToString();
                consultAppMdl.created_dt = DateTime.Now;
                consultAppMdl.status = 1; // After save, the status will be changed to 1;
            }
            else
            {
                // Get exists data first, then using new GUI to update
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();
                consultAppMdl = dal.GetModel(consultAppMdl.guid);
            }

            consultAppMdl.location_type = int.Parse(this.ddlLocalType.SelectedValue);
            consultAppMdl.user_guid = Session["USER_GUID"].ToString();
            consultAppMdl.user_name = this.txtName.Text.Trim();
            consultAppMdl.purpose = this.txtApplicationPurpose.Text;
            #endregion


            // Patient Info
            EMR_PatientMdl patientMdl = new EMR_PatientMdl();
            #region MyRegion
            patientMdl.user_guid = this.hidUserGUID.Value; // Pateint belongs to User
            patientMdl.name = this.txtPatientName.Text.Trim();
            patientMdl.gender = int.Parse(this.ddlGender.SelectedValue);
            string strDOB = this.txtDOB.Text;
            DateTime dtDOB = DateTime.Now;
            DateTime.TryParse(strDOB, out dtDOB);
            patientMdl.birthday = dtDOB;
            #endregion


            // Hospital Info
            List<Consult_Application_ConsultantMdl> consultantMdlCollection = new List<Consult_Application_ConsultantMdl>();
            #region MyRegion
            int HospitalCount = int.Parse(this.ddlHospitalCount.SelectedValue);
            for (int i = 1; i <= HospitalCount; i++)
            {
                Consult_Application_ConsultantMdl consultantMdl = new Consult_Application_ConsultantMdl();
                DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + i.ToString()) as DropDownList;
                if (ddlHospital.SelectedItem != null)
                {
                    consultantMdl.hospital_guid = ddlHospital.SelectedValue;
                    consultantMdl.hospital_name = ddlHospital.SelectedItem.Text;
                    string location_guid = "";
                    string location_name = "";
                    Consult_ApplicationDAL.GetLocationInfoByHospitalUID(consultantMdl.hospital_guid, ref location_guid, ref location_name);
                    consultantMdl.location_guid = location_guid;
                    consultantMdl.location_name = location_name;
                }

                DropDownList ddlDoctor = this.panDoctorGroup.FindControl("ddlDoctor" + i.ToString()) as DropDownList;
                if (ddlDoctor.SelectedItem != null)
                {
                    consultantMdl.doctor_guid = ddlDoctor.SelectedValue;
                    consultantMdl.doctor_name = ddlDoctor.SelectedItem.Text;
                }
                consultantMdl.consult_application_guid = consultAppMdl.guid;
                consultantMdlCollection.Add(consultantMdl);
            }
            #endregion


            // consult_application_accessory info
            #region MyRegion
            consult_application_accessoryMdl thumbnailMdl = null;
            if (!string.IsNullOrEmpty(this.hidPurposeImg.Value) && File.Exists(this.hidPurposeImg.Value))
            {
                thumbnailMdl = new consult_application_accessoryMdl();
                if (string.IsNullOrEmpty(this.hidPurposeImgGUID.Value))
                {
                    thumbnailMdl.guid = Guid.NewGuid().ToString();
                }
                else
                {
                    thumbnailMdl.guid = this.hidPurposeImgGUID.Value;
                }

                thumbnailMdl.consult_application_guid = consultAppMdl.guid;
                thumbnailMdl.type = 0;
                thumbnailMdl.content = File.ReadAllBytes(this.hidPurposeImg.Value);
                thumbnailMdl.thumbnail = ImageUtils.getThumbnail(thumbnailMdl.content);
            }
            #endregion



            totalMdl.Consult_ApplicationMdl = consultAppMdl;
            totalMdl.EMR_PatientMdl = patientMdl;
            totalMdl.Consult_Application_ConsultantMdlCollection = consultantMdlCollection;
            totalMdl.consult_application_accessoryMdl = thumbnailMdl;
            return totalMdl;
        }

        private void BindGUI(Consult_ApplicationMdl applicationMdl)
        {
            // Very importand, remember the uid
            this.hidGUID.Value = applicationMdl.guid;
            this.hidUserGUID.Value = applicationMdl.user_guid;

            if (applicationMdl.status == 1)
            {
                lblStatus.Text = "已提交";
            }

            // Bind System User Info
            #region MyRegion
            V_Sys_UserMdl model = V_Sys_UserDAL.GetModel(applicationMdl.user_guid);
            this.txtName.Text = model.name;
            this.txtMobile.Text = model.login_name;
            this.txtEmail.Text = model.email;
            #endregion

            // Bind Patient Info
            #region MyRegion
            DataSet ds = Consult_ApplicationDAL.GetApplication(applicationMdl.guid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.txtPatientName.Text = ds.Tables[0].Rows[0]["name"].ToString().Trim();
                WebCtrlUtil.SetDropDownText(this.ddlGender, ds.Tables[0].Rows[0]["gender"].ToString().Trim());

                DateTime dtDOB = DateTime.Now;
                if (!(ds.Tables[0].Rows[0]["birthday"] is DBNull))
                {
                    DateTime.TryParse(ds.Tables[0].Rows[0]["birthday"].ToString().Trim(), out dtDOB);
                }

                this.txtDOB.Text = dtDOB.ToString("yyyy-MM-dd");
                this.txtApplicationPurpose.Text = ds.Tables[0].Rows[0]["purpose"].ToString().Trim();
                // Location type
                WebCtrlUtil.SetDropDownText(this.ddlLocalType, ds.Tables[0].Rows[0]["location_type"].ToString().Trim());
            }
            #endregion

            // Bind consult_application_consultant Info
            #region MyRegion
            ds = Consult_ApplicationDAL.GetApplicationConsultant(applicationMdl.guid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                WebCtrlUtil.SetDropDownText(this.ddlHospitalCount, ds.Tables[0].Rows.Count.ToString());
                CreateDropdownListGroup();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // Bind Hospital
                    DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + (i + 1)) as DropDownList;
                    WebCtrlUtil.SetDropDownText(ddlHospital, ds.Tables[0].Rows[i]["hospital_guid"].ToString().Trim());
                    ddlHospital_SelectedIndexChanged(ddlHospital, null);
                    // Bind Doctor
                    DropDownList ddlDoctor = this.panDoctorGroup.FindControl("ddlDoctor" + (i + 1)) as DropDownList;
                    WebCtrlUtil.SetDropDownText(ddlDoctor, ds.Tables[0].Rows[i]["doctor_guid"].ToString().Trim());
                }
            }
            #endregion

            // Bind the PurposeImage
            ds = Consult_ApplicationDAL.GetPurposeThumbnail(applicationMdl.guid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string strTempFolder = ImageUtils.GetTempFolderPath();
                byte[] bImage = (byte[])(ds.Tables[0].Rows[0]["thumbnail"]);
                string strFileName = Guid.NewGuid().ToString() + ".jpg";
                string strFilePath = Path.Combine(strTempFolder, strFileName);
                File.WriteAllBytes(strFilePath, bImage);
                ImageUtils.ShowThumbnail(this.litPurposeImg, strFileName);
                this.hidPurposeImg.Value = strFilePath;
                this.hidPurposeImgGUID.Value = ds.Tables[0].Rows[0]["guid"].ToString();
            }
        }

        private void CreateDropdownListGroup()
        {
            this.panDoctorGroup.Controls.Clear();

            int hospitalCount = this.GetApplicationDoctorCount();

            for (int i = 0; i < hospitalCount; i++)
            {
                CreateSingleHospitalDoctorGroup(i + 1);
            }

        }

        private void CreateSingleHospitalDoctorGroup(int i)
        {
            // 1: 国内  2: 国外
            string strLocationType = this.ddlLocalType.SelectedItem.Value;

            //Label lbl = new Label();
            //lbl.Text = "目的地";
            //lbl.CssClass = "fg-gray";
            //panDoctorGroup.Controls.Add(lbl);

            //DropDownList ddl = new DropDownList();
            //ddl.ID = "ddlLocation" + i.ToString();
            //ddl.AutoPostBack = true;
            //ddl.SelectedIndexChanged += new EventHandler(ddlLocation_SelectedIndexChanged);//给ddl添加事件
            //ddl.CssClass = "input-control select";
            //ddl.DataSource = Consult_ApplicationDAL.GetLoctionList(this.ddlLocalType.SelectedValue);
            //ddl.DataTextField = "name";
            //ddl.DataValueField = "guid";
            //ddl.DataBind();
            //panDoctorGroup.Controls.Add(ddl);


            Label lblHospital = new Label();
            lblHospital.Text = "医院";
            lblHospital.CssClass = "fg-gray";
            panDoctorGroup.Controls.Add(lblHospital);

            DropDownList ddlHospital = new DropDownList();
            ddlHospital.ID = "ddlHospital" + i.ToString();
            ddlHospital.AutoPostBack = true;
            ddlHospital.SelectedIndexChanged += new EventHandler(ddlHospital_SelectedIndexChanged);//给ddl添加事件
            ddlHospital.CssClass = "input-control select";
            ddlHospital.DataSource = Consult_ApplicationDAL.GetHospitalListByLocationType(strLocationType);
            ddlHospital.DataTextField = "name";
            ddlHospital.DataValueField = "guid";
            ddlHospital.DataBind();
            panDoctorGroup.Controls.Add(ddlHospital);

            Label lblDoctor = new Label();
            lblDoctor.Text = "医生";
            lblDoctor.CssClass = "fg-gray";
            panDoctorGroup.Controls.Add(lblDoctor);

            DropDownList ddlDoctor = new DropDownList();
            ddlDoctor.ID = "ddlDoctor" + i.ToString();
            ddlDoctor.CssClass = "input-control select";
            ddlDoctor.DataSource = Consult_ApplicationDAL.GetDoctorList(ddlHospital.SelectedValue, strLocationType);
            ddlDoctor.DataTextField = "name";
            ddlDoctor.DataValueField = "guid";
            ddlDoctor.DataBind();
            panDoctorGroup.Controls.Add(ddlDoctor);
        }

        private int GetApplicationDoctorCount()
        {
            int hospitalCount = 3;
            string selectedCount = this.ddlHospitalCount.SelectedValue;
            hospitalCount = int.Parse(selectedCount);

            return hospitalCount;
        }
        #endregion



    }
}