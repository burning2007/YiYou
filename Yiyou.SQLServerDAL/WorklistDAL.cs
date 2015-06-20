using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Yiyou.SQLServerDAL
{
    public class WorklistDAL
    {
        public static DataSet GetWorklist(string strFilterStatus)
        {
            string strSQL = "select * FROM [mhCloudEMR].[dbo].[consult_application] where 1=1 ";
            if (!string.IsNullOrEmpty(strFilterStatus))
            {
                strSQL += " and status=" + strFilterStatus;
            }
            strSQL += "order by created_dt desc";
            return SqlHelper.ExecuteQuery(strSQL);
        }

        public static string GetApplicationCount(string strFilterStatus)
        {
            string strSQL = "select count(*) FROM [mhCloudEMR].[dbo].[consult_application] where 1=1 ";
            if (!string.IsNullOrEmpty(strFilterStatus))
            {
                strSQL += " and status=" + strFilterStatus;
            }
            DataSet ds = SqlHelper.ExecuteQuery(strSQL);
            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
