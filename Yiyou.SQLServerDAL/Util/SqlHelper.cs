using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Yiyou.Log;
using System.Transactions;

namespace Yiyou.SQLServerDAL
{
    public abstract class SqlHelper
    {
        public static string ConnectionStringSettings = "";        

        #region ========================== Query ==========================

        // Basic Method Here
        public static DataSet ExecuteAdapter(string queryString, string tableName)
        {
            DataSet dataset = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, conn);
                    adapter.Fill(dataset, tableName);
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                throw;
            }

            return dataset;
        }

        public static DataSet ExecuteQuery(string queryString, SqlParameter[] ParaList)
        {
            DataSet dataset = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                {
                    SqlDataAdapter dadp = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    if (ParaList != null)
                    {
                        foreach (SqlParameter para in ParaList)
                        {
                            para.Value = para.Value == null ? DBNull.Value : para.Value;
                            cmd.Parameters.Add(para);
                        }
                    }
                    dadp.SelectCommand = cmd;
                    dadp.Fill(dataset);
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
               throw;
            }

            return dataset;
        }

        public static DataSet ExecuteQuery(string queryString, SqlParameter[] ParaList, CommandType commandType)
        {
            DataSet dataset = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                {
                    SqlDataAdapter dadp = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.CommandType = commandType;
                    if (ParaList != null)
                    {
                        foreach (SqlParameter para in ParaList)
                        {
                            para.Value = para.Value == null ? DBNull.Value : para.Value;
                            cmd.Parameters.Add(para);
                        }
                    }
                    dadp.SelectCommand = cmd;
                    dadp.Fill(dataset);
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                throw;
            }

            return dataset;
        }



        // Extend Method
        public static DataSet ExecuteQuery(SqlWrapper sql)
        {
            return ExecuteQuery(sql.SqlString, sql.Parameter);
        }
        public static DataSet ExecuteQuery(string queryString)
        {
            return SqlHelper.ExecuteQuery(queryString, null);
        }
        /// <summary>
        /// Get multiple data table
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static DataSet ExecuteMultiQuery(string queryString1, string queryString2)
        {
            DataSet dataset = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString1, conn);
                    adapter.Fill(dataset, "table1");

                    adapter = new SqlDataAdapter(queryString2, conn);
                    adapter.Fill(dataset, "table2");
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                throw;
            }

            return dataset;
        }
        public static string ExecuteSingleValueQuery(string queryString)
        {
            DataSet ds = SqlHelper.ExecuteQuery(queryString, null);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            return "";
        }

        #endregion


        #region ========================== Execute ==========================

        // Basic Method Here
        public static int ExecuteNonQuery(string strSql, SqlParameter[] ParaList, CommandType commandType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSql;
                    cmd.CommandType = commandType;
                    cmd.Connection = conn;
                    conn.Open();
                    if (ParaList != null)
                    {
                        foreach (SqlParameter para in ParaList)
                        {
                            para.Value = para.Value == null ? DBNull.Value : para.Value;
                            cmd.Parameters.Add(para);
                        }
                    }
                    int iret = cmd.ExecuteNonQuery();
                    conn.Close();
                    return iret;
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                throw;
            }
        }

        // Extend Method
        public static int ExecuteNonQuery(string strSql)
        {
            return ExecuteNonQuery(strSql, null, CommandType.Text);
        }
        public static int ExecuteNonQuery(string strSql, SqlParameter[] ParaList)
        {
            return ExecuteNonQuery(strSql, ParaList, CommandType.Text);
        }



        // Basic Method Here
        public static int ExecuteNonQuery(List<SqlWrapper> lstSql)
        {
            try
            {
                int iret = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionStringSettings))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        conn.Open();
                        foreach (SqlWrapper sql in lstSql)
                        {
                            try
                            {
                                cmd.CommandText = sql.SqlString;
                                cmd.Parameters.Clear();
                                if (sql.Parameter != null)
                                {
                                    foreach (SqlParameter para in sql.Parameter)
                                    {
                                        para.Value = para.Value == null ? DBNull.Value : para.Value;
                                        cmd.Parameters.Add(para);
                                    }
                                }
                                iret += cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Log4NetLogger.GetLogger().Error(ex.Message);
                                throw;
                            }
                        }
                        conn.Close();
                    }
                    scope.Complete();
                    return iret;
                }
            }
            catch
            {
                throw;
            }
        }

        // Extend Method
        public static int ExecuteNonQuery(List<string> lstSql)
        {
            List<SqlWrapper> lstSqlWrapper = new List<SqlWrapper>();
            foreach (string strSql in lstSql)
            {
                lstSqlWrapper.Add(new SqlWrapper(strSql, null));
            }
            return ExecuteNonQuery(lstSqlWrapper);
        }
        public static int ExecuteNonQuery(SqlWrapper sqlWrapper)
        {
            List<SqlWrapper> lstSql = new List<SqlWrapper>();
            lstSql.Add(sqlWrapper);
            return ExecuteNonQuery(lstSql);
        }

        #endregion

        public static DataSet ExecuteSQLServerAdoQuery(string queryString, SqlParameter[] ParaList, string connectionString)
        {
            DataSet dataset = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    using (SqlDataAdapter dadp = new SqlDataAdapter(cmd))
                    {
                        if (ParaList != null)
                        {
                            foreach (SqlParameter para in ParaList)
                            {
                                para.Value = para.Value == null ? DBNull.Value : para.Value;
                                cmd.Parameters.Add(para);
                            }
                        }
                        conn.Open();
                        // dadp.SelectCommand = cmd;
                        dadp.Fill(dataset);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4NetLogger.GetLogger().Error(ex.Message);
                throw;
            }
            return dataset;
        }

    }
}
