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
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                this.lblErrorMsg.Text = ex.Message;
            }
        }

        private void InitCtrl()
        {
            DataSet dsProject = ApplicationDAL.GetProjectList();
            this.ddlProject.DataSource = dsProject;
            this.ddlProject.DataBind();
            Session["dsProject"] = dsProject;

            DataSet dsLoction = ApplicationDAL.GetLoctionList();
            this.ddlLocation.DataSource = dsLoction;
            this.ddlLocation.DataBind();
            Session["dsLoction"] = dsLoction;

            ddlLocation_SelectedIndexChanged(null, null);
            lblStatus.Text = "未提交";

            if (Request.QueryString["guid"] != null)
            {
                string guid = Request.QueryString["guid"];
                ApplicationDAL dal = new ApplicationDAL();
                ApplicationMdl mdl = dal.GetModel(guid);
                BindGUI(mdl);
            }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Hospital by Location
            this.ddlHospital.DataSource = ApplicationDAL.GetHospitalList(this.ddlLocation.SelectedValue);
            this.ddlHospital.DataBind();
            ddlHospital_SelectedIndexChanged(null, null);
        }

        protected void ddlHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the Doctor by Hospital
            this.ddlDoctor.DataSource = ApplicationDAL.GetDoctorList(this.ddlHospital.SelectedValue, "");
            this.ddlDoctor.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationMdl mdl = GetMdlFromGUI();
                mdl.status = 0;   // 0—未提交（开始用户阶段 )
                ApplicationDAL dal = new ApplicationDAL();


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
                ApplicationMdl mdl = GetMdlFromGUI();
                mdl.status = 1;   // 1—已提交           
                ApplicationDAL dal = new ApplicationDAL();

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
            ApplicationMdl mdl = new ApplicationMdl();

            // Try to get guid
            mdl.guid = this.hidGUID.Value.Trim();
            if (string.IsNullOrEmpty(mdl.guid))
            {
                // New Application Request
                mdl.guid = Guid.NewGuid().ToString();
                mdl.created_dt = DateTime.Now;
            }
            else
            {
                // Get exists data first, then using new GUI to update
                ApplicationDAL dal = new ApplicationDAL();
                mdl = dal.GetModel(mdl.guid);
            }

            mdl.project_guid = this.ddlProject.SelectedValue;
            mdl.project_name = this.ddlProject.SelectedItem.Text;
            mdl.location_guid = this.ddlLocation.SelectedValue;
            mdl.location_name = this.ddlLocation.SelectedItem.Text;
            mdl.hospital_guid = this.ddlHospital.SelectedValue;
            mdl.hospital_name = this.ddlHospital.SelectedItem.Text;
            mdl.doctor_guid = this.ddlDoctor.SelectedValue;
            mdl.doctor_name = this.ddlDoctor.SelectedItem.Text;
            mdl.local_hospital = this.txtLocalHospital.Text;
            mdl.purpose = this.txtLocalDiagnosis.Text;

            // 
            mdl.user_guid = "DUMMY";
            mdl.user_name = "DUMMY";

            return mdl;
        }

        private ApplicationMdl BindGUI(ApplicationMdl mdl)
        {
            this.hidGUID.Value = mdl.guid;

            WebCtrlUtil.SetDropDownText(this.ddlProject, mdl.project_name);

            WebCtrlUtil.SetDropDownText(this.ddlLocation, mdl.location_name);
            this.ddlLocation_SelectedIndexChanged(null, null);

            WebCtrlUtil.SetDropDownText(this.ddlHospital, mdl.hospital_name);
            this.ddlHospital_SelectedIndexChanged(null, null);

            WebCtrlUtil.SetDropDownText(this.ddlDoctor, mdl.doctor_name);


            this.txtLocalHospital.Text = mdl.local_hospital;
            this.txtLocalDiagnosis.Text = mdl.purpose;

            this.hidStatus.Value = mdl.status.ToString();
            if (mdl.status == 1)
            {
                lblStatus.Text = "已提交";
            }

            // 
            mdl.user_guid = "DUMMY";
            mdl.user_name = "DUMMY";

            return mdl;
        }
    }
}