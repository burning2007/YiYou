using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yiyou.Model;

namespace Yiyou.SQLServerDAL
{
    public class Consult_ApplicationDAL
    {
        public static DataSet GetLoctionListByType(string localType)
        {
            string strSQL = @"SELECT [guid]
                                  ,[name]
                                  ,[description]
                                  ,[type]
                                  ,[avatar]
                              FROM [mhCloudEMR].[dbo].[v_dic_location] where 1=1 ";
            if (!string.IsNullOrEmpty(localType))
            {
                strSQL += " and type = " + localType;
            }
            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static DataSet GetHospitalListByLoacationUID(string location_guid)
        {
            string strSQL = @"SELECT [guid]
                                      ,[name]
                                      ,[description]
                                      ,[avatar]
                                      ,[location_guid]
                              FROM [mhCloudEMR].[dbo].[v_dic_hospital] where 1=1 ";
            if (!string.IsNullOrEmpty(location_guid))
            {
                strSQL += "and location_guid='" + location_guid + "'";
            }
            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static DataSet GetHospitalListByLocationType(string LocationType)
        {
            string strSQL = @"SELECT [guid]
                                      ,[name]
                                      ,[description]
                                      ,[avatar]
                                      ,[location_guid]
                              FROM [mhCloudEMR].[dbo].[v_dic_hospital] 
                              where location_guid in (select guid from [mhCloudEMR].[dbo].[v_dic_location] where type=" + LocationType + ")";

            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static DataSet GetDoctorList(string hospital_guid, string LocationType)
        {
            string strSQL = @"SELECT [guid]
                                  ,[name]
                                  ,[title]
                                  ,[description]
                                  ,[avatar]
                                  ,[hospital_guid]
                                  ,[location_guid]
                                  ,[contact_guid]
                              FROM [mhCloudEMR].[dbo].[v_dic_doctor] where 1=1 ";
            if (!string.IsNullOrEmpty(LocationType))
            {
                strSQL += @" and hospital_guid in (select guid from [mhCloudEMR].[dbo].v_dic_hospital 
                                                   where location_guid in (select guid from [mhCloudEMR].[dbo].[v_dic_location] where type=" + LocationType + "))";
            }
            if (!string.IsNullOrEmpty(hospital_guid))
            {
                strSQL += " and hospital_guid='" + hospital_guid + "'";
            }
            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static void GetLocationInfoByHospitalUID(string hospital_guid, ref string location_guid, ref string location_name)
        {
            string strSQL = @"SELECT loc.guid, loc.name
                              FROM [mhCloudEMR].[dbo].[v_dic_hospital] hos
                              inner join [mhCloudEMR].[dbo].v_dic_location loc on hos.location_guid=loc.guid
                              where hos.guid='" + hospital_guid + "'";
            DataSet ds = SqlHelper.ExecuteQuery(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                location_guid = ds.Tables[0].Rows[0]["guid"].ToString().Trim();
                location_name = ds.Tables[0].Rows[0]["name"].ToString().Trim();
            }
        }

        public static DataSet GetProjectList()
        {
            string strSQL = @"SELECT [guid]
                                  [guid]
                                  ,[name]
                                  ,[description]
                                  ,[avatar]
                              FROM [mhCloudEMR].[dbo].[v_dic_project]";
            return SqlHelper.ExecuteQuery(strSQL);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Consult_ApplicationMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into consult_application(");
            strSql.Append("guid,user_guid,user_name,status,patient_guid,project_guid,project_name,location_type,purpose,purpose_t,local_hospital,local_hospital_t,preliminary_conclusions,preliminary_conclusions_t,final_conclusion,final_conclusion_t,created_dt,submitted_dt,accepted_dt,approved_dt,concluded_dt,rejected_dt,completed_dt,approver_guid,approver_name,contract_content,amount_payable,amount_receivable,paid_dt,amount_payable2,amount_receivable2,paid_dt2,service_comments_for_user,service_comments_for_consultant,service_comments_for_consultant_t,specified_notes,number_of_hospitals,location_guid,location_name)");
            strSql.Append(" values (");
            strSql.Append("@guid,@user_guid,@user_name,@status,@patient_guid,@project_guid,@project_name,@location_type,@purpose,@purpose_t,@local_hospital,@local_hospital_t,@preliminary_conclusions,@preliminary_conclusions_t,@final_conclusion,@final_conclusion_t,@created_dt,@submitted_dt,@accepted_dt,@approved_dt,@concluded_dt,@rejected_dt,@completed_dt,@approver_guid,@approver_name,@contract_content,@amount_payable,@amount_receivable,@paid_dt,@amount_payable2,@amount_receivable2,@paid_dt2,@service_comments_for_user,@service_comments_for_consultant,@service_comments_for_consultant_t,@specified_notes,@number_of_hospitals,@location_guid,@location_name)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_type", SqlDbType.Int,4),
					new SqlParameter("@purpose", SqlDbType.NVarChar,-1),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@preliminary_conclusions", SqlDbType.NVarChar,-1),
					new SqlParameter("@preliminary_conclusions_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@accepted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime),
					new SqlParameter("@amount_payable2", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable2", SqlDbType.Float,8),
					new SqlParameter("@paid_dt2", SqlDbType.DateTime),
					new SqlParameter("@service_comments_for_user", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@specified_notes", SqlDbType.NVarChar,-1),
					new SqlParameter("@number_of_hospitals", SqlDbType.Int,4),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.status;
            parameters[4].Value = model.patient_guid;
            parameters[5].Value = model.project_guid;
            parameters[6].Value = model.project_name;
            parameters[7].Value = model.location_type;
            parameters[8].Value = model.purpose;
            parameters[9].Value = model.purpose_t;
            parameters[10].Value = model.local_hospital;
            parameters[11].Value = model.local_hospital_t;
            parameters[12].Value = model.preliminary_conclusions;
            parameters[13].Value = model.preliminary_conclusions_t;
            parameters[14].Value = model.final_conclusion;
            parameters[15].Value = model.final_conclusion_t;
            parameters[16].Value = model.created_dt;
            parameters[17].Value = model.submitted_dt;
            parameters[18].Value = model.accepted_dt;
            parameters[19].Value = model.approved_dt;
            parameters[20].Value = model.concluded_dt;
            parameters[21].Value = model.rejected_dt;
            parameters[22].Value = model.completed_dt;
            parameters[23].Value = model.approver_guid;
            parameters[24].Value = model.approver_name;
            parameters[25].Value = model.contract_content;
            parameters[26].Value = model.amount_payable;
            parameters[27].Value = model.amount_receivable;
            parameters[28].Value = model.paid_dt;
            parameters[29].Value = model.amount_payable2;
            parameters[30].Value = model.amount_receivable2;
            parameters[31].Value = model.paid_dt2;
            parameters[32].Value = model.service_comments_for_user;
            parameters[33].Value = model.service_comments_for_consultant;
            parameters[34].Value = model.service_comments_for_consultant_t;
            parameters[35].Value = model.specified_notes;
            parameters[36].Value = model.number_of_hospitals;
            parameters[37].Value = model.location_guid;
            parameters[38].Value = model.location_name;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Consult_ApplicationMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update consult_application set ");
            strSql.Append("guid=@guid,");
            strSql.Append("user_guid=@user_guid,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("status=@status,");
            strSql.Append("patient_guid=@patient_guid,");
            strSql.Append("project_guid=@project_guid,");
            strSql.Append("project_name=@project_name,");
            strSql.Append("location_type=@location_type,");
            strSql.Append("purpose=@purpose,");
            strSql.Append("purpose_t=@purpose_t,");
            strSql.Append("local_hospital=@local_hospital,");
            strSql.Append("local_hospital_t=@local_hospital_t,");
            strSql.Append("preliminary_conclusions=@preliminary_conclusions,");
            strSql.Append("preliminary_conclusions_t=@preliminary_conclusions_t,");
            strSql.Append("final_conclusion=@final_conclusion,");
            strSql.Append("final_conclusion_t=@final_conclusion_t,");
            strSql.Append("created_dt=@created_dt,");
            strSql.Append("submitted_dt=@submitted_dt,");
            strSql.Append("accepted_dt=@accepted_dt,");
            strSql.Append("approved_dt=@approved_dt,");
            strSql.Append("concluded_dt=@concluded_dt,");
            strSql.Append("rejected_dt=@rejected_dt,");
            strSql.Append("completed_dt=@completed_dt,");
            strSql.Append("approver_guid=@approver_guid,");
            strSql.Append("approver_name=@approver_name,");
            strSql.Append("contract_content=@contract_content,");
            strSql.Append("amount_payable=@amount_payable,");
            strSql.Append("amount_receivable=@amount_receivable,");
            strSql.Append("paid_dt=@paid_dt,");
            strSql.Append("amount_payable2=@amount_payable2,");
            strSql.Append("amount_receivable2=@amount_receivable2,");
            strSql.Append("paid_dt2=@paid_dt2,");
            strSql.Append("service_comments_for_user=@service_comments_for_user,");
            strSql.Append("service_comments_for_consultant=@service_comments_for_consultant,");
            strSql.Append("service_comments_for_consultant_t=@service_comments_for_consultant_t,");
            strSql.Append("specified_notes=@specified_notes,");
            strSql.Append("number_of_hospitals=@number_of_hospitals,");
            strSql.Append("location_guid=@location_guid,");
            strSql.Append("location_name=@location_name");
            strSql.Append(" where guid=@guid");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_type", SqlDbType.Int,4),
					new SqlParameter("@purpose", SqlDbType.NVarChar,-1),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@preliminary_conclusions", SqlDbType.NVarChar,-1),
					new SqlParameter("@preliminary_conclusions_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@accepted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime),
					new SqlParameter("@amount_payable2", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable2", SqlDbType.Float,8),
					new SqlParameter("@paid_dt2", SqlDbType.DateTime),
					new SqlParameter("@service_comments_for_user", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@specified_notes", SqlDbType.NVarChar,-1),
					new SqlParameter("@number_of_hospitals", SqlDbType.Int,4),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.status;
            parameters[4].Value = model.patient_guid;
            parameters[5].Value = model.project_guid;
            parameters[6].Value = model.project_name;
            parameters[7].Value = model.location_type;
            parameters[8].Value = model.purpose;
            parameters[9].Value = model.purpose_t;
            parameters[10].Value = model.local_hospital;
            parameters[11].Value = model.local_hospital_t;
            parameters[12].Value = model.preliminary_conclusions;
            parameters[13].Value = model.preliminary_conclusions_t;
            parameters[14].Value = model.final_conclusion;
            parameters[15].Value = model.final_conclusion_t;
            parameters[16].Value = model.created_dt;
            parameters[17].Value = model.submitted_dt;
            parameters[18].Value = model.accepted_dt;
            parameters[19].Value = model.approved_dt;
            parameters[20].Value = model.concluded_dt;
            parameters[21].Value = model.rejected_dt;
            parameters[22].Value = model.completed_dt;
            parameters[23].Value = model.approver_guid;
            parameters[24].Value = model.approver_name;
            parameters[25].Value = model.contract_content;
            parameters[26].Value = model.amount_payable;
            parameters[27].Value = model.amount_receivable;
            parameters[28].Value = model.paid_dt;
            parameters[29].Value = model.amount_payable2;
            parameters[30].Value = model.amount_receivable2;
            parameters[31].Value = model.paid_dt2;
            parameters[32].Value = model.service_comments_for_user;
            parameters[33].Value = model.service_comments_for_consultant;
            parameters[34].Value = model.service_comments_for_consultant_t;
            parameters[35].Value = model.specified_notes;
            parameters[36].Value = model.number_of_hospitals;
            parameters[37].Value = model.location_guid;
            parameters[38].Value = model.location_name;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string guid, string user_guid, string user_name, int status, string patient_guid, string project_guid, string project_name, int location_type, string purpose, string purpose_t, string local_hospital, string local_hospital_t, string preliminary_conclusions, string preliminary_conclusions_t, string final_conclusion, string final_conclusion_t, DateTime created_dt, DateTime submitted_dt, DateTime accepted_dt, DateTime approved_dt, DateTime concluded_dt, DateTime rejected_dt, DateTime completed_dt, string approver_guid, string approver_name, string contract_content, decimal amount_payable, decimal amount_receivable, DateTime paid_dt, decimal amount_payable2, decimal amount_receivable2, DateTime paid_dt2, string service_comments_for_user, string service_comments_for_consultant, string service_comments_for_consultant_t, string specified_notes, int number_of_hospitals, string location_guid, string location_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from consult_application ");
            strSql.Append(" where guid=@guid and user_guid=@user_guid and user_name=@user_name and status=@status and patient_guid=@patient_guid and project_guid=@project_guid and project_name=@project_name and location_type=@location_type and purpose=@purpose and purpose_t=@purpose_t and local_hospital=@local_hospital and local_hospital_t=@local_hospital_t and preliminary_conclusions=@preliminary_conclusions and preliminary_conclusions_t=@preliminary_conclusions_t and final_conclusion=@final_conclusion and final_conclusion_t=@final_conclusion_t and created_dt=@created_dt and submitted_dt=@submitted_dt and accepted_dt=@accepted_dt and approved_dt=@approved_dt and concluded_dt=@concluded_dt and rejected_dt=@rejected_dt and completed_dt=@completed_dt and approver_guid=@approver_guid and approver_name=@approver_name and contract_content=@contract_content and amount_payable=@amount_payable and amount_receivable=@amount_receivable and paid_dt=@paid_dt and amount_payable2=@amount_payable2 and amount_receivable2=@amount_receivable2 and paid_dt2=@paid_dt2 and service_comments_for_user=@service_comments_for_user and service_comments_for_consultant=@service_comments_for_consultant and service_comments_for_consultant_t=@service_comments_for_consultant_t and specified_notes=@specified_notes and number_of_hospitals=@number_of_hospitals and location_guid=@location_guid and location_name=@location_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_type", SqlDbType.Int,4),
					new SqlParameter("@purpose", SqlDbType.NVarChar,-1),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@preliminary_conclusions", SqlDbType.NVarChar,-1),
					new SqlParameter("@preliminary_conclusions_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@final_conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@accepted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime),
					new SqlParameter("@amount_payable2", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable2", SqlDbType.Float,8),
					new SqlParameter("@paid_dt2", SqlDbType.DateTime),
					new SqlParameter("@service_comments_for_user", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant", SqlDbType.NVarChar,-1),
					new SqlParameter("@service_comments_for_consultant_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@specified_notes", SqlDbType.NVarChar,-1),
					new SqlParameter("@number_of_hospitals", SqlDbType.Int,4),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64)			};
            parameters[0].Value = guid;
            parameters[1].Value = user_guid;
            parameters[2].Value = user_name;
            parameters[3].Value = status;
            parameters[4].Value = patient_guid;
            parameters[5].Value = project_guid;
            parameters[6].Value = project_name;
            parameters[7].Value = location_type;
            parameters[8].Value = purpose;
            parameters[9].Value = purpose_t;
            parameters[10].Value = local_hospital;
            parameters[11].Value = local_hospital_t;
            parameters[12].Value = preliminary_conclusions;
            parameters[13].Value = preliminary_conclusions_t;
            parameters[14].Value = final_conclusion;
            parameters[15].Value = final_conclusion_t;
            parameters[16].Value = created_dt;
            parameters[17].Value = submitted_dt;
            parameters[18].Value = accepted_dt;
            parameters[19].Value = approved_dt;
            parameters[20].Value = concluded_dt;
            parameters[21].Value = rejected_dt;
            parameters[22].Value = completed_dt;
            parameters[23].Value = approver_guid;
            parameters[24].Value = approver_name;
            parameters[25].Value = contract_content;
            parameters[26].Value = amount_payable;
            parameters[27].Value = amount_receivable;
            parameters[28].Value = paid_dt;
            parameters[29].Value = amount_payable2;
            parameters[30].Value = amount_receivable2;
            parameters[31].Value = paid_dt2;
            parameters[32].Value = service_comments_for_user;
            parameters[33].Value = service_comments_for_consultant;
            parameters[34].Value = service_comments_for_consultant_t;
            parameters[35].Value = specified_notes;
            parameters[36].Value = number_of_hospitals;
            parameters[37].Value = location_guid;
            parameters[38].Value = location_name;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Consult_ApplicationMdl GetModel(string guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * FROM [mhCloudEMR].[dbo].[consult_application] app left join emr_patient pat on app.patient_guid=pat.patient_guid ");
            strSql.Append(" where guid=@guid");
            SqlParameter[] parameters = { new SqlParameter("@guid", SqlDbType.VarChar, 36) };
            parameters[0].Value = guid;

            Consult_ApplicationMdl model = new Consult_ApplicationMdl();
            DataSet ds = SqlHelper.ExecuteQuery(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetApplication(string guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * FROM [mhCloudEMR].[dbo].[consult_application] app left join emr_patient pat on app.patient_guid=pat.patient_guid ");
            strSql.Append(" where guid=@guid");
            SqlParameter[] parameters = { new SqlParameter("@guid", SqlDbType.VarChar, 36) };
            parameters[0].Value = guid;

            Consult_ApplicationMdl model = new Consult_ApplicationMdl();
            DataSet ds = SqlHelper.ExecuteQuery(strSql.ToString(), parameters);
            return ds;
        }

        public static DataSet GetApplicationConsultant(string p)
        {
            string strSQL = @"SELECT [guid]
                                  ,[consult_application_guid]
                                  ,[location_guid]
                                  ,[location_name]
                                  ,[hospital_guid]
                                  ,[hospital_name]
                                  ,[doctor_guid]
                                  ,[doctor_name]
                                  ,[conclusion]
                                  ,[conclusion_t]
                                  ,[concluded_dt]
                              FROM [mhCloudEMR].[dbo].[consult_application_consultant]
                              where consult_application_guid='" + p + "'";
            return SqlHelper.ExecuteQuery(strSQL); ;
        }

        public bool IsExist(string guid)
        {
            Consult_ApplicationMdl mdl = GetModel(guid);
            return (mdl != null);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Consult_ApplicationMdl DataRowToModel(DataRow row)
        {
            Consult_ApplicationMdl model = new Consult_ApplicationMdl();
            if (row != null)
            {
                if (row["guid"] != null)
                {
                    model.guid = row["guid"].ToString();
                }
                if (row["user_guid"] != null)
                {
                    model.user_guid = row["user_guid"].ToString();
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["patient_guid"] != null)
                {
                    model.patient_guid = row["patient_guid"].ToString();
                }
                if (row["project_guid"] != null)
                {
                    model.project_guid = row["project_guid"].ToString();
                }
                if (row["project_name"] != null)
                {
                    model.project_name = row["project_name"].ToString();
                }
                if (row["location_type"] != null && row["location_type"].ToString() != "")
                {
                    model.location_type = int.Parse(row["location_type"].ToString());
                }
                if (row["purpose"] != null)
                {
                    model.purpose = row["purpose"].ToString();
                }
                if (row["purpose_t"] != null)
                {
                    model.purpose_t = row["purpose_t"].ToString();
                }
                if (row["local_hospital"] != null)
                {
                    model.local_hospital = row["local_hospital"].ToString();
                }
                if (row["local_hospital_t"] != null)
                {
                    model.local_hospital_t = row["local_hospital_t"].ToString();
                }
                if (row["preliminary_conclusions"] != null)
                {
                    model.preliminary_conclusions = row["preliminary_conclusions"].ToString();
                }
                if (row["preliminary_conclusions_t"] != null)
                {
                    model.preliminary_conclusions_t = row["preliminary_conclusions_t"].ToString();
                }
                if (row["final_conclusion"] != null)
                {
                    model.final_conclusion = row["final_conclusion"].ToString();
                }
                if (row["final_conclusion_t"] != null)
                {
                    model.final_conclusion_t = row["final_conclusion_t"].ToString();
                }
                if (row["created_dt"] != null && row["created_dt"].ToString() != "")
                {
                    model.created_dt = DateTime.Parse(row["created_dt"].ToString());
                }
                if (row["submitted_dt"] != null && row["submitted_dt"].ToString() != "")
                {
                    model.submitted_dt = DateTime.Parse(row["submitted_dt"].ToString());
                }
                if (row["accepted_dt"] != null && row["accepted_dt"].ToString() != "")
                {
                    model.accepted_dt = DateTime.Parse(row["accepted_dt"].ToString());
                }
                if (row["approved_dt"] != null && row["approved_dt"].ToString() != "")
                {
                    model.approved_dt = DateTime.Parse(row["approved_dt"].ToString());
                }
                if (row["concluded_dt"] != null && row["concluded_dt"].ToString() != "")
                {
                    model.concluded_dt = DateTime.Parse(row["concluded_dt"].ToString());
                }
                if (row["rejected_dt"] != null && row["rejected_dt"].ToString() != "")
                {
                    model.rejected_dt = DateTime.Parse(row["rejected_dt"].ToString());
                }
                if (row["completed_dt"] != null && row["completed_dt"].ToString() != "")
                {
                    model.completed_dt = DateTime.Parse(row["completed_dt"].ToString());
                }
                if (row["approver_guid"] != null)
                {
                    model.approver_guid = row["approver_guid"].ToString();
                }
                if (row["approver_name"] != null)
                {
                    model.approver_name = row["approver_name"].ToString();
                }
                if (row["contract_content"] != null)
                {
                    model.contract_content = row["contract_content"].ToString();
                }
                if (row["amount_payable"] != null && row["amount_payable"].ToString() != "")
                {
                    model.amount_payable = decimal.Parse(row["amount_payable"].ToString());
                }
                if (row["amount_receivable"] != null && row["amount_receivable"].ToString() != "")
                {
                    model.amount_receivable = decimal.Parse(row["amount_receivable"].ToString());
                }
                if (row["paid_dt"] != null && row["paid_dt"].ToString() != "")
                {
                    model.paid_dt = DateTime.Parse(row["paid_dt"].ToString());
                }
                if (row["amount_payable2"] != null && row["amount_payable2"].ToString() != "")
                {
                    model.amount_payable2 = decimal.Parse(row["amount_payable2"].ToString());
                }
                if (row["amount_receivable2"] != null && row["amount_receivable2"].ToString() != "")
                {
                    model.amount_receivable2 = decimal.Parse(row["amount_receivable2"].ToString());
                }
                if (row["paid_dt2"] != null && row["paid_dt2"].ToString() != "")
                {
                    model.paid_dt2 = DateTime.Parse(row["paid_dt2"].ToString());
                }
                if (row["service_comments_for_user"] != null)
                {
                    model.service_comments_for_user = row["service_comments_for_user"].ToString();
                }
                if (row["service_comments_for_consultant"] != null)
                {
                    model.service_comments_for_consultant = row["service_comments_for_consultant"].ToString();
                }
                if (row["service_comments_for_consultant_t"] != null)
                {
                    model.service_comments_for_consultant_t = row["service_comments_for_consultant_t"].ToString();
                }
                if (row["specified_notes"] != null)
                {
                    model.specified_notes = row["specified_notes"].ToString();
                }
                if (row["number_of_hospitals"] != null && row["number_of_hospitals"].ToString() != "")
                {
                    model.number_of_hospitals = int.Parse(row["number_of_hospitals"].ToString());
                }
                if (row["location_guid"] != null)
                {
                    model.location_guid = row["location_guid"].ToString();
                }
                if (row["location_name"] != null)
                {
                    model.location_name = row["location_name"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM consult_application ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteQuery(strSql.ToString());
        }


        /// <summary>
        /// Add data into table consult_application_consultant
        /// </summary>
        /// <param name="list"></param>
        public void Add_application_consultant(List<Consult_Application_ConsultantMdl> list)
        {
            foreach (Consult_Application_ConsultantMdl model in list)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into consult_application_consultant(");
                strSql.Append("guid,consult_application_guid,location_guid,location_name,hospital_guid,hospital_name,doctor_guid,doctor_name,conclusion,conclusion_t,concluded_dt)");
                strSql.Append(" values (");
                strSql.Append("@guid,@consult_application_guid,@location_guid,@location_name,@hospital_guid,@hospital_name,@doctor_guid,@doctor_name,@conclusion,@conclusion_t,@concluded_dt)");
                SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@consult_application_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64),
					new SqlParameter("@hospital_guid", SqlDbType.VarChar,36),
					new SqlParameter("@hospital_name", SqlDbType.NVarChar,256),
					new SqlParameter("@doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@doctor_name", SqlDbType.NVarChar,256),
					new SqlParameter("@conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime)};
                parameters[0].Value = Guid.NewGuid().ToString();
                parameters[1].Value = model.consult_application_guid;
                parameters[2].Value = model.location_guid;
                parameters[3].Value = model.location_name;
                parameters[4].Value = model.hospital_guid;
                parameters[5].Value = model.hospital_name;
                parameters[6].Value = model.doctor_guid;
                parameters[7].Value = model.doctor_name;
                parameters[8].Value = model.conclusion;
                parameters[9].Value = model.conclusion_t;
                parameters[10].Value = model.concluded_dt;

                int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            }
        }


        /// <summary>
        /// Update data into table consult_application_consultant
        /// </summary>
        /// <param name="list"></param>
        public void Update_application_consultant(List<Consult_Application_ConsultantMdl> list)
        {
            // First, Delete
            string strSQL = "delete consult_application_consultant where consult_application_guid='" + list[0].consult_application_guid + "'";
            int rows = SqlHelper.ExecuteNonQuery(strSQL);

            // Then, Add
            Add_application_consultant(list);
        }

    }
}
