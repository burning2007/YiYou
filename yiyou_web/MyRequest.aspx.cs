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

namespace ICUPro.Portal
{
    public partial class MyRequest : System.Web.UI.Page
    {

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
                V_Sys_UserMdl model = V_Sys_UserDAL.GetModel(Session["USER_GUID"].ToString());
                this.txtName.Text = model.name;
                this.txtMobile.Text = model.login_name;
                this.txtEmail.Text = model.email;
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
                ApplicationAllInOneMdl model = this.GetMdlFromGUI();
                Consult_ApplicationMdl mdl = model.Consult_ApplicationMdl;
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();

                if (!dal.IsExist(mdl.guid))
                {
                    // Add Consult_ApplicationMdl
                    dal.Add(mdl);
                    // Add consult_application_consultant
                    dal.Add_application_consultant(model.Consult_Application_ConsultantMdlCollection);

                    Page.Response.Redirect("MyWorklist.aspx");
                }
                else
                {
                    // Update Consult_ApplicationMdl
                    dal.Update(mdl);
                    // Update consult_application_consultant
                    dal.Update_application_consultant(model.Consult_Application_ConsultantMdlCollection);

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

        private ApplicationAllInOneMdl GetMdlFromGUI()
        {
            ApplicationAllInOneMdl totalMdl = new ApplicationAllInOneMdl();

            Consult_ApplicationMdl consultAppMdl = new Consult_ApplicationMdl();

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

            // 
            consultAppMdl.user_guid = Session["USER_GUID"].ToString();
            consultAppMdl.user_name = this.txtName.Text.Trim();
            consultAppMdl.purpose = this.txtApplicationPurpose.Text;

            EMR_PatientMdl emrMdl = new EMR_PatientMdl();

            emrMdl.user_guid = Session["USER_GUID"].ToString(); // Pateint belongs to User
            emrMdl.name = this.txtName.Text.Trim();
            emrMdl.gender = int.Parse(this.ddlGender.SelectedValue);

            string strDOB = this.txtDOB.Text;
            DateTime dtDOB = DateTime.Now;
            DateTime.TryParse(strDOB, out dtDOB);
            emrMdl.birthday = dtDOB;



            List<Consult_Application_ConsultantMdl> consultantMdlCollection = new List<Consult_Application_ConsultantMdl>();

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

            totalMdl.Consult_ApplicationMdl = consultAppMdl;
            totalMdl.EMR_PatientMdl = emrMdl;
            totalMdl.Consult_Application_ConsultantMdlCollection = consultantMdlCollection;
            return totalMdl;
        }

        private void BindGUI(Consult_ApplicationMdl mdl)
        {

            this.hidGUID.Value = mdl.guid;

            if (mdl.status == 1)
            {
                lblStatus.Text = "已提交";
            }

            // Bind System User Info
            V_Sys_UserMdl model = V_Sys_UserDAL.GetModel(mdl.user_guid);
            this.txtName.Text = model.name;
            this.txtMobile.Text = model.login_name;
            this.txtEmail.Text = model.email;

            // Bind Patient Info
            DataSet ds = Consult_ApplicationDAL.GetApplication(mdl.guid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.txtPatientName.Text = ds.Tables[0].Rows[0]["name"].ToString().Trim();
                WebCtrlUtil.SetDropDownText(this.ddlGender, ds.Tables[0].Rows[0]["gender"].ToString().Trim());

                DateTime dtDOB = DateTime.Now;
                DateTime.TryParse(ds.Tables[0].Rows[0]["birthday"].ToString().Trim(), out dtDOB);
                this.txtDOB.Text = dtDOB.ToString("yyyy-MM-dd");
                this.txtApplicationPurpose.Text = ds.Tables[0].Rows[0]["purpose"].ToString().Trim();
                // Location type
                WebCtrlUtil.SetDropDownText(this.ddlLocalType, ds.Tables[0].Rows[0]["location_type"].ToString().Trim());
            }

            // Bind consult_application_consultant Info
            ds = Consult_ApplicationDAL.GetApplicationConsultant(mdl.guid);
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
        }

        protected void ddlHospitalCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CreateDropdownListGroup();
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

        protected void btnUploadPurpose_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            string path = Server.MapPath("~/Temp/");
            String fileExtension = string.Empty;
            if (this.FileUpload_Purpose.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(FileUpload_Purpose.FileName).ToLower();
                String[] allowedExtensions = { ".jpg", ".png", ".bmp", ".jpeg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }

            // Check file type
            if (!fileOK)
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('仅支持上传图片格式的文件！');");
                ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                return;
            }

            // Check length, can't exceed 4M
            if (FileUpload_Purpose.FileBytes.Length > 4 * 1024 * 1024)
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件大小超过限制，请编辑后重试！');");
                ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                return;
            }

            try
            {
                string strFileName = Guid.NewGuid().ToString() + fileExtension;
                string strFilePath = path + strFileName;
                FileUpload_Purpose.SaveAs(strFilePath);
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件上传成功');");
                ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                this.litPurposeImg.Text = string.Format("<img width=\"100\" height=\"100\" src=\"/temp/{0}\" />", strFileName);
            }
            catch
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件上传失败！请重试！');");
                ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
            }
        }

    }
}