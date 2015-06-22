using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yiyou.Model;

namespace Yiyou.SQLServerDAL
{
    public class EMR_PatientMdlDAL
    {
        public static string GetPatientGUID(string name, string user_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select patient_guid from  emr_patient ");
            strSql.Append("where name=@name and user_guid=@user_guid");

            SqlParameter[] parameters = {
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64)};
            parameters[0].Value = user_guid;
            parameters[1].Value = name;

            DataSet ds = SqlHelper.ExecuteQuery(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return string.Empty;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(EMR_PatientMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into emr_patient(");
            strSql.Append("patient_guid,user_guid,name,gender,birthday,diagnosis,diagnosis_t,created_dt,modified_dt)");
            strSql.Append(" values (");
            strSql.Append("@patient_guid,@user_guid,@name,@gender,@birthday,@diagnosis,@diagnosis_t,getdate(),getdate())");
            SqlParameter[] parameters = {
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@diagnosis_t", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.patient_guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.name;
            parameters[3].Value = model.gender;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.diagnosis;
            parameters[6].Value = model.diagnosis_t;

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
        public static bool Update(EMR_PatientMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update emr_patient set ");
            strSql.Append("name=@name,");
            strSql.Append("gender=@gender,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("diagnosis=@diagnosis,");
            strSql.Append("diagnosis_t=@diagnosis_t,");
            strSql.Append("modified_dt=getdate()");
            strSql.Append(" where patient_guid=@patient_guid and user_guid=@user_guid");
            SqlParameter[] parameters = {
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@diagnosis_t", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.patient_guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.name;
            parameters[3].Value = model.gender;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.diagnosis;
            parameters[6].Value = model.diagnosis_t;

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
        public EMR_PatientMdl GetModel(string patient_guid, string user_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 patient_guid,user_guid,name,gender,birthday,diagnosis,diagnosis_t,created_dt,modified_dt from EMR_PatientMdl ");
            strSql.Append(" where patient_guid=@patient_guid and user_guid=@user_guid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36)	};
            parameters[0].Value = patient_guid;
            parameters[1].Value = user_guid;


            EMR_PatientMdl model = new EMR_PatientMdl();
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
        public EMR_PatientMdl DataRowToModel(DataRow row)
        {
            EMR_PatientMdl model = new EMR_PatientMdl();
            if (row != null)
            {
                if (row["patient_guid"] != null)
                {
                    model.patient_guid = row["patient_guid"].ToString();
                }
                if (row["user_guid"] != null)
                {
                    model.user_guid = row["user_guid"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["gender"] != null && row["gender"].ToString() != "")
                {
                    model.gender = int.Parse(row["gender"].ToString());
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(row["birthday"].ToString());
                }
                if (row["diagnosis"] != null)
                {
                    model.diagnosis = row["diagnosis"].ToString();
                }
                if (row["diagnosis_t"] != null)
                {
                    model.diagnosis_t = row["diagnosis_t"].ToString();
                }
                if (row["created_dt"] != null && row["created_dt"].ToString() != "")
                {
                    model.created_dt = DateTime.Parse(row["created_dt"].ToString());
                }
                if (row["modified_dt"] != null && row["modified_dt"].ToString() != "")
                {
                    model.modified_dt = DateTime.Parse(row["modified_dt"].ToString());
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
            strSql.Append("select patient_guid,user_guid,name,gender,birthday,diagnosis,diagnosis_t,created_dt,modified_dt ");
            strSql.Append(" FROM EMR_PatientMdl ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteQuery(strSql.ToString());
        }


        public static DataSet GetEMRDetailList(string userGUID, string patientName)
        {
            string strSQL = @"SELECT [patient_guid]
                              ,[type_guid]
                              ,[type_name]
                              ,[img_count]
                              ,[content]
                              ,[content_t]
                              ,[hospital]
                              ,[hospital_t]
                              ,[created_dt]
                              ,[modified_dt], emr_image.img_content, emr_image.img_type, emr_image.img_url, emr_image.thumbnail
                          FROM [mhCloudEMR].[dbo].[emr_index]
                          left join emr_image on [emr_index].guid=emr_image.emr_guid
                          where patient_guid in (select patient_guid from emr_patient where user_guid=@user_guid and name=@name)
                          order by created_dt desc";

            SqlParameter[] parameters = {
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64)};
            parameters[0].Value = userGUID;
            parameters[1].Value = patientName;

            DataSet ds = SqlHelper.ExecuteQuery(strSQL, parameters);
            return ds;
        }

        public static DataSet GetEMRDetailListByPatientUID(string patient_guid, string type_guid)
        {
            string strSQL = @"SELECT [patient_guid]
                              ,[type_guid]
                              ,[type_name]
                              ,[img_count]
                              ,[content]
                              ,[content_t]
                              ,[hospital]
                              ,[hospital_t]
                              ,[created_dt]
                              ,[modified_dt], emr_image.img_content, emr_image.img_type, emr_image.img_url, emr_image.thumbnail
                          FROM [mhCloudEMR].[dbo].[emr_index]
                          left join emr_image on [emr_index].guid=emr_image.emr_guid
                          where patient_guid ='" + patient_guid + "'";

            if (!string.IsNullOrEmpty(type_guid))
            {
                strSQL = strSQL + " and type_guid='" + type_guid + "'";
            }
            strSQL = strSQL + " order by created_dt desc";

            DataSet ds = SqlHelper.ExecuteQuery(strSQL);
            return ds;
        }

        public static DataSet GetEMRType()
        {
            string strSQL = @"SELECT [guid]
                              ,[name]
                              ,[description]
                          FROM [mhCloudEMR].[dbo].[emr_type]";
            return SqlHelper.ExecuteQuery(strSQL);
        }


        public static bool Add_emr_index(emr_indexMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into emr_index(");
            strSql.Append("guid,patient_guid,type_guid,type_name,img_count,content,content_t,hospital,hospital_t,created_dt,modified_dt)");
            strSql.Append(" values (");
            strSql.Append("@guid,@patient_guid,@type_guid,@type_name,@img_count,@content,@content_t,@hospital,@hospital_t,getdate(),getdate())");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@type_guid", SqlDbType.VarChar,36),
					new SqlParameter("@type_name", SqlDbType.VarChar,64),
					new SqlParameter("@img_count", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.NVarChar,-1),
					new SqlParameter("@content_t", SqlDbType.NVarChar,-1),
					new SqlParameter("@hospital", SqlDbType.NVarChar,256),
					new SqlParameter("@hospital_t", SqlDbType.NVarChar,256)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.patient_guid;
            parameters[2].Value = model.type_guid;
            parameters[3].Value = model.type_name;
            parameters[4].Value = model.img_count;
            parameters[5].Value = model.content;
            parameters[6].Value = model.content_t;
            parameters[7].Value = model.hospital;
            parameters[8].Value = model.hospital_t;

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

        public static bool Add_emr_image(emr_imageMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into emr_image(");
            strSql.Append("guid,emr_guid,img_type,img_content,thumbnail,img_url)");
            strSql.Append(" values (");
            strSql.Append("@guid,@emr_guid,@img_type,@img_content,@thumbnail,@img_url)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,36),
					new SqlParameter("@emr_guid", SqlDbType.VarChar,36),
					new SqlParameter("@img_type", SqlDbType.Int,4),
					new SqlParameter("@img_content", SqlDbType.VarBinary,-1),
					new SqlParameter("@thumbnail", SqlDbType.VarBinary,-1),
					new SqlParameter("@img_url", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.emr_guid;
            parameters[2].Value = model.img_type;
            parameters[3].Value = model.img_content;
            parameters[4].Value = model.thumbnail;
            parameters[5].Value = model.img_url;

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

    }
}
