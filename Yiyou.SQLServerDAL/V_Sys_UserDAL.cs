using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yiyou.Model;

namespace Yiyou.SQLServerDAL
{
    public class V_Sys_UserDAL
    {
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static V_Sys_UserMdl GetModel(string guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,login_name,name,password,role,email,avatar from v_sys_user ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.VarChar,42)
            };
            parameters[0].Value = guid;

            V_Sys_UserMdl model = new V_Sys_UserMdl();
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
        public static V_Sys_UserMdl DataRowToModel(DataRow row)
        {
            V_Sys_UserMdl model = new V_Sys_UserMdl();
            if (row != null)
            {
                if (row["guid"] != null)
                {
                    model.guid = row["guid"].ToString();
                }
                if (row["login_name"] != null)
                {
                    model.login_name = row["login_name"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["role"] != null && row["role"].ToString() != "")
                {
                    model.role = int.Parse(row["role"].ToString());
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["avatar"] != null && row["avatar"].ToString() != "")
                {
                    model.avatar = (byte[])row["avatar"];
                }
            }
            return model;
        }
    }
}
