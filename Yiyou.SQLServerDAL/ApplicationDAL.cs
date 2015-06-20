using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yiyou.Model;

namespace Yiyou.SQLServerDAL
{
    public class ApplicationDAL
    {
        public static DataSet GetLoctionList()
        {
            string strSQL = @"SELECT [guid]
                                  ,[name]
                                  ,[description]
                                  ,[type]
                                  ,[avatar]
                              FROM [mhCloudEMR].[dbo].[v_dic_location]";
            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static DataSet GetHospitalList(string location_guid)
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

        public static DataSet GetDoctorList(string hospital_guid, string location_guid)
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
            if (!string.IsNullOrEmpty(location_guid))
            {
                strSQL += "and location_guid='" + location_guid + "'";
            }
            if (!string.IsNullOrEmpty(hospital_guid))
            {
                strSQL += "and hospital_guid='" + hospital_guid + "'";
            }
            return SqlHelper.ExecuteQuery(strSQL);
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
        public bool Add(ApplicationMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into consult_application(");
            strSql.Append("guid,user_guid,user_name,status,project_guid,project_name,location_guid,location_name,hospital_guid,hospital_name,doctor_guid,doctor_name,purpose,purpose_t,local_hospital,local_hospital_t,conclusion,conclusion_t,conclusion_doctor_guid,conclusion_doctor_name,created_dt,submitted_dt,approved_dt,delivered_dt,concluded_dt,rejected_dt,completed_dt,approver_guid,approver_name,deliver_guid,deliver_name,contract_content,amount_payable,amount_receivable,paid_dt)");
            strSql.Append(" values (");
            strSql.Append("@guid,@user_guid,@user_name,@status,@project_guid,@project_name,@location_guid,@location_name,@hospital_guid,@hospital_name,@doctor_guid,@doctor_name,@purpose,@purpose_t,@local_hospital,@local_hospital_t,@conclusion,@conclusion_t,@conclusion_doctor_guid,@conclusion_doctor_name,@created_dt,@submitted_dt,@approved_dt,@delivered_dt,@concluded_dt,@rejected_dt,@completed_dt,@approver_guid,@approver_name,@deliver_guid,@deliver_name,@contract_content,@amount_payable,@amount_receivable,@paid_dt)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64),
					new SqlParameter("@hospital_guid", SqlDbType.VarChar,36),
					new SqlParameter("@hospital_name", SqlDbType.NVarChar,64),
					new SqlParameter("@doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@conclusion_doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@delivered_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@deliver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@deliver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.status;
            parameters[4].Value = model.project_guid;
            parameters[5].Value = model.project_name;
            parameters[6].Value = model.location_guid;
            parameters[7].Value = model.location_name;
            parameters[8].Value = model.hospital_guid;
            parameters[9].Value = model.hospital_name;
            parameters[10].Value = model.doctor_guid;
            parameters[11].Value = model.doctor_name;
            parameters[12].Value = model.purpose;
            parameters[13].Value = model.purpose_t;
            parameters[14].Value = model.local_hospital;
            parameters[15].Value = model.local_hospital_t;
            parameters[16].Value = model.conclusion;
            parameters[17].Value = model.conclusion_t;
            parameters[18].Value = model.conclusion_doctor_guid;
            parameters[19].Value = model.conclusion_doctor_name;
            parameters[20].Value = model.created_dt;
            parameters[21].Value = model.submitted_dt;
            parameters[22].Value = model.approved_dt;
            parameters[23].Value = model.delivered_dt;
            parameters[24].Value = model.concluded_dt;
            parameters[25].Value = model.rejected_dt;
            parameters[26].Value = model.completed_dt;
            parameters[27].Value = model.approver_guid;
            parameters[28].Value = model.approver_name;
            parameters[29].Value = model.deliver_guid;
            parameters[30].Value = model.deliver_name;
            parameters[31].Value = model.contract_content;
            parameters[32].Value = model.amount_payable;
            parameters[33].Value = model.amount_receivable;
            parameters[34].Value = model.paid_dt;

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
        public bool Update(ApplicationMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update consult_application set ");
            strSql.Append("user_guid=@user_guid,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("status=@status,");
            strSql.Append("project_guid=@project_guid,");
            strSql.Append("project_name=@project_name,");
            strSql.Append("location_guid=@location_guid,");
            strSql.Append("location_name=@location_name,");
            strSql.Append("hospital_guid=@hospital_guid,");
            strSql.Append("hospital_name=@hospital_name,");
            strSql.Append("doctor_guid=@doctor_guid,");
            strSql.Append("doctor_name=@doctor_name,");
            strSql.Append("purpose=@purpose,");
            strSql.Append("purpose_t=@purpose_t,");
            strSql.Append("local_hospital=@local_hospital,");
            strSql.Append("local_hospital_t=@local_hospital_t,");
            strSql.Append("conclusion=@conclusion,");
            strSql.Append("conclusion_t=@conclusion_t,");
            strSql.Append("conclusion_doctor_guid=@conclusion_doctor_guid,");
            strSql.Append("conclusion_doctor_name=@conclusion_doctor_name,");
            strSql.Append("created_dt=@created_dt,");
            strSql.Append("submitted_dt=@submitted_dt,");
            strSql.Append("approved_dt=@approved_dt,");
            strSql.Append("delivered_dt=@delivered_dt,");
            strSql.Append("concluded_dt=@concluded_dt,");
            strSql.Append("rejected_dt=@rejected_dt,");
            strSql.Append("completed_dt=@completed_dt,");
            strSql.Append("approver_guid=@approver_guid,");
            strSql.Append("approver_name=@approver_name,");
            strSql.Append("deliver_guid=@deliver_guid,");
            strSql.Append("deliver_name=@deliver_name,");
            strSql.Append("contract_content=@contract_content,");
            strSql.Append("amount_payable=@amount_payable,");
            strSql.Append("amount_receivable=@amount_receivable,");
            strSql.Append("paid_dt=@paid_dt");
            strSql.Append(" where guid=@guid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64),
					new SqlParameter("@hospital_guid", SqlDbType.VarChar,36),
					new SqlParameter("@hospital_name", SqlDbType.NVarChar,64),
					new SqlParameter("@doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@conclusion_doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@delivered_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@deliver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@deliver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.status;
            parameters[4].Value = model.project_guid;
            parameters[5].Value = model.project_name;
            parameters[6].Value = model.location_guid;
            parameters[7].Value = model.location_name;
            parameters[8].Value = model.hospital_guid;
            parameters[9].Value = model.hospital_name;
            parameters[10].Value = model.doctor_guid;
            parameters[11].Value = model.doctor_name;
            parameters[12].Value = model.purpose;
            parameters[13].Value = model.purpose_t;
            parameters[14].Value = model.local_hospital;
            parameters[15].Value = model.local_hospital_t;
            parameters[16].Value = model.conclusion;
            parameters[17].Value = model.conclusion_t;
            parameters[18].Value = model.conclusion_doctor_guid;
            parameters[19].Value = model.conclusion_doctor_name;
            parameters[20].Value = model.created_dt;
            parameters[21].Value = model.submitted_dt;
            parameters[22].Value = model.approved_dt;
            parameters[23].Value = model.delivered_dt;
            parameters[24].Value = model.concluded_dt;
            parameters[25].Value = model.rejected_dt;
            parameters[26].Value = model.completed_dt;
            parameters[27].Value = model.approver_guid;
            parameters[28].Value = model.approver_name;
            parameters[29].Value = model.deliver_guid;
            parameters[30].Value = model.deliver_name;
            parameters[31].Value = model.contract_content;
            parameters[32].Value = model.amount_payable;
            parameters[33].Value = model.amount_receivable;
            parameters[34].Value = model.paid_dt;

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
        public bool Delete(string guid, string user_guid, string user_name, int status, string project_guid, string project_name, string location_guid, string location_name, string hospital_guid, string hospital_name, string doctor_guid, string doctor_name, string purpose, string purpose_t, string local_hospital, string local_hospital_t, string conclusion, string conclusion_t, string conclusion_doctor_guid, string conclusion_doctor_name, DateTime created_dt, DateTime submitted_dt, DateTime approved_dt, DateTime delivered_dt, DateTime concluded_dt, DateTime rejected_dt, DateTime completed_dt, string approver_guid, string approver_name, string deliver_guid, string deliver_name, string contract_content, decimal amount_payable, decimal amount_receivable, DateTime paid_dt)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from consult_application ");
            strSql.Append(" where guid=@guid and user_guid=@user_guid and user_name=@user_name and status=@status and project_guid=@project_guid and project_name=@project_name and location_guid=@location_guid and location_name=@location_name and hospital_guid=@hospital_guid and hospital_name=@hospital_name and doctor_guid=@doctor_guid and doctor_name=@doctor_name and purpose=@purpose and purpose_t=@purpose_t and local_hospital=@local_hospital and local_hospital_t=@local_hospital_t and conclusion=@conclusion and conclusion_t=@conclusion_t and conclusion_doctor_guid=@conclusion_doctor_guid and conclusion_doctor_name=@conclusion_doctor_name and created_dt=@created_dt and submitted_dt=@submitted_dt and approved_dt=@approved_dt and delivered_dt=@delivered_dt and concluded_dt=@concluded_dt and rejected_dt=@rejected_dt and completed_dt=@completed_dt and approver_guid=@approver_guid and approver_name=@approver_name and deliver_guid=@deliver_guid and deliver_name=@deliver_name and contract_content=@contract_content and amount_payable=@amount_payable and amount_receivable=@amount_receivable and paid_dt=@paid_dt ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64),
					new SqlParameter("@hospital_guid", SqlDbType.VarChar,36),
					new SqlParameter("@hospital_name", SqlDbType.NVarChar,64),
					new SqlParameter("@doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@conclusion_doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@delivered_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@deliver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@deliver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime)			};
            parameters[0].Value = guid;
            parameters[1].Value = user_guid;
            parameters[2].Value = user_name;
            parameters[3].Value = status;
            parameters[4].Value = project_guid;
            parameters[5].Value = project_name;
            parameters[6].Value = location_guid;
            parameters[7].Value = location_name;
            parameters[8].Value = hospital_guid;
            parameters[9].Value = hospital_name;
            parameters[10].Value = doctor_guid;
            parameters[11].Value = doctor_name;
            parameters[12].Value = purpose;
            parameters[13].Value = purpose_t;
            parameters[14].Value = local_hospital;
            parameters[15].Value = local_hospital_t;
            parameters[16].Value = conclusion;
            parameters[17].Value = conclusion_t;
            parameters[18].Value = conclusion_doctor_guid;
            parameters[19].Value = conclusion_doctor_name;
            parameters[20].Value = created_dt;
            parameters[21].Value = submitted_dt;
            parameters[22].Value = approved_dt;
            parameters[23].Value = delivered_dt;
            parameters[24].Value = concluded_dt;
            parameters[25].Value = rejected_dt;
            parameters[26].Value = completed_dt;
            parameters[27].Value = approver_guid;
            parameters[28].Value = approver_name;
            parameters[29].Value = deliver_guid;
            parameters[30].Value = deliver_name;
            parameters[31].Value = contract_content;
            parameters[32].Value = amount_payable;
            parameters[33].Value = amount_receivable;
            parameters[34].Value = paid_dt;

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
        public ApplicationMdl GetModel(string guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from consult_application ");
            strSql.Append(" where guid=@guid");
            SqlParameter[] parameters = { new SqlParameter("@guid", SqlDbType.VarChar, 36) };
            parameters[0].Value = guid;

            ApplicationMdl model = new ApplicationMdl();
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

        public bool IsExist(string guid)
        {
            ApplicationMdl mdl = GetModel(guid);
            return (mdl == null);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ApplicationMdl GetModel(string guid, string user_guid, string user_name, int status, string project_guid, string project_name, string location_guid, string location_name, string hospital_guid, string hospital_name, string doctor_guid, string doctor_name, string purpose, string purpose_t, string local_hospital, string local_hospital_t, string conclusion, string conclusion_t, string conclusion_doctor_guid, string conclusion_doctor_name, DateTime created_dt, DateTime submitted_dt, DateTime approved_dt, DateTime delivered_dt, DateTime concluded_dt, DateTime rejected_dt, DateTime completed_dt, string approver_guid, string approver_name, string deliver_guid, string deliver_name, string contract_content, decimal amount_payable, decimal amount_receivable, DateTime paid_dt)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,user_guid,user_name,status,project_guid,project_name,location_guid,location_name,hospital_guid,hospital_name,doctor_guid,doctor_name,purpose,purpose_t,local_hospital,local_hospital_t,conclusion,conclusion_t,conclusion_doctor_guid,conclusion_doctor_name,created_dt,submitted_dt,approved_dt,delivered_dt,concluded_dt,rejected_dt,completed_dt,approver_guid,approver_name,deliver_guid,deliver_name,contract_content,amount_payable,amount_receivable,paid_dt from consult_application ");
            strSql.Append(" where guid=@guid and user_guid=@user_guid and user_name=@user_name and status=@status and project_guid=@project_guid and project_name=@project_name and location_guid=@location_guid and location_name=@location_name and hospital_guid=@hospital_guid and hospital_name=@hospital_name and doctor_guid=@doctor_guid and doctor_name=@doctor_name and purpose=@purpose and purpose_t=@purpose_t and local_hospital=@local_hospital and local_hospital_t=@local_hospital_t and conclusion=@conclusion and conclusion_t=@conclusion_t and conclusion_doctor_guid=@conclusion_doctor_guid and conclusion_doctor_name=@conclusion_doctor_name and created_dt=@created_dt and submitted_dt=@submitted_dt and approved_dt=@approved_dt and delivered_dt=@delivered_dt and concluded_dt=@concluded_dt and rejected_dt=@rejected_dt and completed_dt=@completed_dt and approver_guid=@approver_guid and approver_name=@approver_name and deliver_guid=@deliver_guid and deliver_name=@deliver_name and contract_content=@contract_content and amount_payable=@amount_payable and amount_receivable=@amount_receivable and paid_dt=@paid_dt ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_name", SqlDbType.NVarChar,64),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@project_guid", SqlDbType.VarChar,36),
					new SqlParameter("@project_name", SqlDbType.NVarChar,64),
					new SqlParameter("@location_guid", SqlDbType.VarChar,36),
					new SqlParameter("@location_name", SqlDbType.NVarChar,64),
					new SqlParameter("@hospital_guid", SqlDbType.VarChar,36),
					new SqlParameter("@hospital_name", SqlDbType.NVarChar,64),
					new SqlParameter("@doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@purpose_t", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@local_hospital_t", SqlDbType.NVarChar,256),
					new SqlParameter("@conclusion", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@conclusion_doctor_guid", SqlDbType.VarChar,36),
					new SqlParameter("@conclusion_doctor_name", SqlDbType.NVarChar,64),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@submitted_dt", SqlDbType.DateTime),
					new SqlParameter("@approved_dt", SqlDbType.DateTime),
					new SqlParameter("@delivered_dt", SqlDbType.DateTime),
					new SqlParameter("@concluded_dt", SqlDbType.DateTime),
					new SqlParameter("@rejected_dt", SqlDbType.DateTime),
					new SqlParameter("@completed_dt", SqlDbType.DateTime),
					new SqlParameter("@approver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@approver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@deliver_guid", SqlDbType.VarChar,36),
					new SqlParameter("@deliver_name", SqlDbType.NVarChar,64),
					new SqlParameter("@contract_content", SqlDbType.NVarChar,-1),
					new SqlParameter("@amount_payable", SqlDbType.Float,8),
					new SqlParameter("@amount_receivable", SqlDbType.Float,8),
					new SqlParameter("@paid_dt", SqlDbType.DateTime)			};
            parameters[0].Value = guid;
            parameters[1].Value = user_guid;
            parameters[2].Value = user_name;
            parameters[3].Value = status;
            parameters[4].Value = project_guid;
            parameters[5].Value = project_name;
            parameters[6].Value = location_guid;
            parameters[7].Value = location_name;
            parameters[8].Value = hospital_guid;
            parameters[9].Value = hospital_name;
            parameters[10].Value = doctor_guid;
            parameters[11].Value = doctor_name;
            parameters[12].Value = purpose;
            parameters[13].Value = purpose_t;
            parameters[14].Value = local_hospital;
            parameters[15].Value = local_hospital_t;
            parameters[16].Value = conclusion;
            parameters[17].Value = conclusion_t;
            parameters[18].Value = conclusion_doctor_guid;
            parameters[19].Value = conclusion_doctor_name;
            parameters[20].Value = created_dt;
            parameters[21].Value = submitted_dt;
            parameters[22].Value = approved_dt;
            parameters[23].Value = delivered_dt;
            parameters[24].Value = concluded_dt;
            parameters[25].Value = rejected_dt;
            parameters[26].Value = completed_dt;
            parameters[27].Value = approver_guid;
            parameters[28].Value = approver_name;
            parameters[29].Value = deliver_guid;
            parameters[30].Value = deliver_name;
            parameters[31].Value = contract_content;
            parameters[32].Value = amount_payable;
            parameters[33].Value = amount_receivable;
            parameters[34].Value = paid_dt;

            ApplicationMdl model = new ApplicationMdl();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ApplicationMdl DataRowToModel(DataRow row)
        {
            ApplicationMdl model = new ApplicationMdl();
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
                //if (row["project_guid"] != null)
                //{
                //    model.project_guid = row["project_guid"].ToString();
                //}
                //if (row["project_name"] != null)
                //{
                //    model.project_name = row["project_name"].ToString();
                //}
                if (row["location_guid"] != null)
                {
                    model.location_guid = row["location_guid"].ToString();
                }
                if (row["location_name"] != null)
                {
                    model.location_name = row["location_name"].ToString();
                }
                //if (row["hospital_guid"] != null)
                //{
                //    model.hospital_guid = row["hospital_guid"].ToString();
                //}
                //if (row["hospital_name"] != null)
                //{
                //    model.hospital_name = row["hospital_name"].ToString();
                //}
                //if (row["doctor_guid"] != null)
                //{
                //    model.doctor_guid = row["doctor_guid"].ToString();
                //}
                //if (row["doctor_name"] != null)
                //{
                //    model.doctor_name = row["doctor_name"].ToString();
                //}
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
                //if (row["conclusion"] != null)
                //{
                //    model.conclusion = row["conclusion"].ToString();
                //}
                //if (row["conclusion_t"] != null)
                //{
                //    model.conclusion_t = row["conclusion_t"].ToString();
                //}
                //if (row["conclusion_doctor_guid"] != null)
                //{
                //    model.conclusion_doctor_guid = row["conclusion_doctor_guid"].ToString();
                //}
                //if (row["conclusion_doctor_name"] != null)
                //{
                //    model.conclusion_doctor_name = row["conclusion_doctor_name"].ToString();
                //}
                if (row["created_dt"] != null && row["created_dt"].ToString() != "")
                {
                    model.created_dt = DateTime.Parse(row["created_dt"].ToString());
                }
                if (row["submitted_dt"] != null && row["submitted_dt"].ToString() != "")
                {
                    model.submitted_dt = DateTime.Parse(row["submitted_dt"].ToString());
                }
                if (row["approved_dt"] != null && row["approved_dt"].ToString() != "")
                {
                    model.approved_dt = DateTime.Parse(row["approved_dt"].ToString());
                }
                //if (row["delivered_dt"] != null && row["delivered_dt"].ToString() != "")
                //{
                //    model.delivered_dt = DateTime.Parse(row["delivered_dt"].ToString());
                //}
                //if (row["concluded_dt"] != null && row["concluded_dt"].ToString() != "")
                //{
                //    model.concluded_dt = DateTime.Parse(row["concluded_dt"].ToString());
                //}
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
                //if (row["deliver_guid"] != null)
                //{
                //    model.deliver_guid = row["deliver_guid"].ToString();
                //}
                //if (row["deliver_name"] != null)
                //{
                //    model.deliver_name = row["deliver_name"].ToString();
                //}
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select guid,user_guid,user_name,status,project_guid,project_name,location_guid,location_name,hospital_guid,hospital_name,doctor_guid,doctor_name,purpose,purpose_t,local_hospital,local_hospital_t,conclusion,conclusion_t,conclusion_doctor_guid,conclusion_doctor_name,created_dt,submitted_dt,approved_dt,delivered_dt,concluded_dt,rejected_dt,completed_dt,approver_guid,approver_name,deliver_guid,deliver_name,contract_content,amount_payable,amount_receivable,paid_dt ");
            strSql.Append(" FROM consult_application ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteQuery(strSql.ToString());
        }




    }
}
