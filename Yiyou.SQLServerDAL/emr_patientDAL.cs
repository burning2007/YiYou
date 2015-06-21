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
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMR_PatientMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EMR_PatientMdl(");
            strSql.Append("patient_guid,user_guid,name,gender,birthday,diagnosis,diagnosis_t,created_dt,modified_dt)");
            strSql.Append(" values (");
            strSql.Append("@patient_guid,@user_guid,@name,@gender,@birthday,@diagnosis,@diagnosis_t,@created_dt,@modified_dt)");
            SqlParameter[] parameters = {
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@diagnosis_t", SqlDbType.NVarChar,256),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@modified_dt", SqlDbType.DateTime)};
            parameters[0].Value = model.patient_guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.name;
            parameters[3].Value = model.gender;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.diagnosis;
            parameters[6].Value = model.diagnosis_t;
            parameters[7].Value = model.created_dt;
            parameters[8].Value = model.modified_dt;

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
        public bool Update(EMR_PatientMdl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EMR_PatientMdl set ");
            strSql.Append("patient_guid=@patient_guid,");
            strSql.Append("user_guid=@user_guid,");
            strSql.Append("name=@name,");
            strSql.Append("gender=@gender,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("diagnosis=@diagnosis,");
            strSql.Append("diagnosis_t=@diagnosis_t,");
            strSql.Append("created_dt=@created_dt,");
            strSql.Append("modified_dt=@modified_dt");
            strSql.Append(" where patient_guid=@patient_guid and user_guid=@user_guid and name=@name and gender=@gender and birthday=@birthday and diagnosis=@diagnosis and diagnosis_t=@diagnosis_t and created_dt=@created_dt and modified_dt=@modified_dt ");
            SqlParameter[] parameters = {
					new SqlParameter("@patient_guid", SqlDbType.VarChar,36),
					new SqlParameter("@user_guid", SqlDbType.VarChar,36),
					new SqlParameter("@name", SqlDbType.NVarChar,64),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@diagnosis_t", SqlDbType.NVarChar,256),
					new SqlParameter("@created_dt", SqlDbType.DateTime),
					new SqlParameter("@modified_dt", SqlDbType.DateTime)};
            parameters[0].Value = model.patient_guid;
            parameters[1].Value = model.user_guid;
            parameters[2].Value = model.name;
            parameters[3].Value = model.gender;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.diagnosis;
            parameters[6].Value = model.diagnosis_t;
            parameters[7].Value = model.created_dt;
            parameters[8].Value = model.modified_dt;

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

   
        #endregion  BasicMethod
    }
}
