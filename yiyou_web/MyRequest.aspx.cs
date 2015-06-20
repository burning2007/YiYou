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

            V_Sys_UserMdl model = V_Sys_UserDAL.GetModel(Session["USER_GUID"].ToString());
            this.txtName.Text = model.name;
            this.txtMobile.Text = model.login_name;
            this.txtEmail.Text = model.email;
            this.txtName.Enabled = false;
            this.txtMobile.Enabled = false;
            this.txtEmail.Enabled = false;
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
            string id = ddl.ID.Replace("ddlLocation","");
            DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + id) as DropDownList;
            ddlHospital.DataSource = Consult_ApplicationDAL.GetHospitalList(ddl.SelectedValue);
            ddlHospital.DataBind();
            //ddlHospital_SelectedIndexChanged(null, null);
        }

        protected void ddlHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Doctor by Hospital
            //this.ddlDoctor.DataSource = ApplicationDAL.GetDoctorList(this.ddlHospital.SelectedValue, "");
            //this.ddlDoctor.DataBind();

            DropDownList ddl = sender as DropDownList;
            if (ddl != null) { 
                string id = ddl.ID.Replace("ddlHospital", "");
                DropDownList ddlDoctor = this.panDoctorGroup.FindControl("ddlDoctor" + id) as DropDownList;
                ddlDoctor.DataSource = Consult_ApplicationDAL.GetDoctorList(ddl.SelectedValue, "");
                ddlDoctor.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string fileName = FileUpload1.FileName;
                }

                ApplicationMdl model = this.GetMdlFromGUI();
                Consult_ApplicationMdl mdl = model.Consult_ApplicationMdl;
                mdl.status = 0;   // 0—未提交（开始用户阶段 )

                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();

                if (dal.IsExist(mdl.guid))
                {
                    if (dal.Add(mdl))
                    {
                        Page.Response.Redirect("MyWorklist.aspx");
                    }
                }
                else
                {
                    if (dal.Update(mdl))
                    {
                        Page.Response.Redirect("MyWorklist.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                this.lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationMdl model = this.GetMdlFromGUI();

                Consult_ApplicationMdl mdl = model.Consult_ApplicationMdl;
                mdl.status = 1;   // 1—已提交           
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();

                if (dal.IsExist(mdl.guid))
                {
                    if (dal.Add(mdl))
                    {
                        Page.Response.Redirect("MyWorklist.aspx");
                    }
                }
                else
                {
                    if (dal.Update(mdl))
                    {
                        Page.Response.Redirect("MyWorklist.aspx");
                    }
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

        private ApplicationMdl GetMdlFromGUI()
        {
            ApplicationMdl model = new ApplicationMdl();

            Consult_ApplicationMdl consultMdl = new Consult_ApplicationMdl();           

            // Try to get guid
            consultMdl.guid = this.hidGUID.Value.Trim();
            if (string.IsNullOrEmpty(consultMdl.guid))
            {
                // New Application Request
                consultMdl.guid = Guid.NewGuid().ToString();
                consultMdl.created_dt = DateTime.Now;
                consultMdl.status = 0;
            }
            else
            {
                // Get exists data first, then using new GUI to update
                Consult_ApplicationDAL dal = new Consult_ApplicationDAL();
                consultMdl = dal.GetModel(consultMdl.guid);
            }

            consultMdl.location_type = int.Parse(this.ddlLocalType.SelectedValue);
            consultMdl.local_hospital = this.txtLocalHospital.Text;
         

            // 
            consultMdl.user_guid = Session["USER_GUID"].ToString();
            consultMdl.user_name = this.txtName.Text.Trim();

            EMR_PatientMdl emrMdl = new EMR_PatientMdl();

            emrMdl.user_guid = Session["USER_GUID"].ToString();
            emrMdl.name = this.txtName.Text.Trim();
            emrMdl.gender = int.Parse(this.ddlGender.SelectedValue);
            int year = 0;
            if (this.txtPatientAge.Text.Trim().Length == 0)
            {
                year = 0 - int.Parse(this.txtPatientAge.Text.Trim());
            }
            emrMdl.birthday = DateTime.Now.AddYears(year);
            

            Consult_Application_ConsultantMdl consultantMdl = new Consult_Application_ConsultantMdl();
            List<Consult_Application_ConsultantMdl> consultantMdlCollection = new List<Consult_Application_ConsultantMdl>();

            int HospitalCount = int.Parse( this.ddlHospitalCount.SelectedValue );

            for (int i = 1; i <= HospitalCount; i++ )
            {
                DropDownList ddlLocaltion = this.panDoctorGroup.FindControl("ddlLocation" + i.ToString()) as DropDownList;
                consultantMdl.location_guid = ddlLocaltion.SelectedValue;
                consultantMdl.location_name = ddlLocaltion.SelectedItem.Text;

                DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + i.ToString()) as DropDownList;
                consultantMdl.hospital_guid = ddlHospital.SelectedValue;
                consultantMdl.hospital_name = ddlHospital.SelectedItem.Text;

                DropDownList ddlDoctor = this.panDoctorGroup.FindControl("ddlDoctor" + i.ToString()) as DropDownList;
                consultantMdl.doctor_guid = ddlDoctor.SelectedValue;
                consultantMdl.doctor_name = ddlDoctor.SelectedItem.Text;

                consultantMdlCollection.Add(consultantMdl);
            }

            model.Consult_ApplicationMdl = consultMdl;
            model.EMR_PatientMdl = emrMdl;
            model.Consult_Application_ConsultantMdlCollection = consultantMdlCollection;
            return model;
        }

        private Consult_ApplicationMdl BindGUI(Consult_ApplicationMdl mdl)
        {            

            this.hidGUID.Value = mdl.guid;

            //WebCtrlUtil.SetDropDownText(this.ddlProject, mdl.project_name);

            //WebCtrlUtil.SetDropDownText(this.ddlLocation, mdl.location_name);
            //this.ddlLocation_SelectedIndexChanged(null, null);

            //WebCtrlUtil.SetDropDownText(this.ddlHospital, mdl.hospital_name);
            //this.ddlHospital_SelectedIndexChanged(null, null);

            //WebCtrlUtil.SetDropDownText(this.ddlDoctor, mdl.doctor_name);

            this.txtLocalHospital.Text = mdl.local_hospital;            

            //this.hidStatus.Value = mdl.status.ToString();
            if (mdl.status == 1)
            {
                lblStatus.Text = "已提交";
            }

            // 
            mdl.user_guid = "DUMMY";
            mdl.user_name = "DUMMY";

            return mdl;
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
                CreateApplicationDoctorGroup(i+1);
            }
           
        }

        private void CreateApplicationDoctorGroup(int i)
        {
            Label lbl = new Label();
            lbl.Text = "目的地";
            lbl.CssClass = "fg-gray";
            panDoctorGroup.Controls.Add(lbl);

            DropDownList ddl = new DropDownList();
            ddl.ID = "ddlLocation" + i.ToString();          
            ddl.AutoPostBack = true;
            ddl.SelectedIndexChanged += new EventHandler(ddlLocation_SelectedIndexChanged);//给ddl添加事件
            ddl.CssClass = "input-control select";
            ddl.DataSource = Consult_ApplicationDAL.GetLoctionList(this.ddlLocalType.SelectedValue);
            ddl.DataTextField = "name";
            ddl.DataValueField = "guid";
            ddl.DataBind();
            panDoctorGroup.Controls.Add(ddl);


            lbl = new Label();
            lbl.Text = "医院";
            lbl.CssClass = "fg-gray";
            panDoctorGroup.Controls.Add(lbl);

            ddl = new DropDownList();
            ddl.ID = "ddlHospital" + i.ToString();
            ddl.AutoPostBack = true;
            ddl.SelectedIndexChanged += new EventHandler(ddlHospital_SelectedIndexChanged);//给ddl添加事件
            ddl.CssClass = "input-control select";

            DropDownList ddlLocal = this.panDoctorGroup.FindControl("ddlLocation" + i.ToString()) as DropDownList;
            ddl.DataSource = Consult_ApplicationDAL.GetHospitalList(ddlLocal.SelectedValue);
            ddl.DataTextField = "name";
            ddl.DataValueField = "guid";
            ddl.DataBind();
            panDoctorGroup.Controls.Add(ddl);

            lbl = new Label();
            lbl.Text = "医生";
            lbl.CssClass = "fg-gray";
            panDoctorGroup.Controls.Add(lbl);

            ddl = new DropDownList();
            ddl.ID = "ddlDoctor" + i.ToString();
            ddl.CssClass = "input-control select";

            DropDownList ddlHospital = this.panDoctorGroup.FindControl("ddlHospital" + i.ToString()) as DropDownList;
            ddl.DataSource = Consult_ApplicationDAL.GetDoctorList(ddlHospital.SelectedValue, "");
            ddl.DataTextField = "name";
            ddl.DataValueField = "guid";
            ddl.DataBind();
            panDoctorGroup.Controls.Add(ddl);
        }

        private int GetApplicationDoctorCount()
        {
            int hospitalCount = 3;
            string selectedCount = this.ddlHospitalCount.SelectedValue;
            hospitalCount = int.Parse(selectedCount);

            return hospitalCount;
        }
  
    }
}