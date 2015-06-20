﻿using System;
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
            string strSQL = "SELECT app.*, p.name, p.gender, '' as gendertext, p.birthday, 3 AS HospitalCount FROM [mhCloudEMR].[dbo].[consult_application]  app LEFT JOIN [mhCloudEMR].[dbo].[emr_patient] p ON P.patient_guid = app.patient_guid WHERE 1=1 ";
            if (!string.IsNullOrEmpty(strFilterStatus))
            {
                strSQL += " AND app.status=" + strFilterStatus;
            }
            strSQL += "ORDER BY app.created_dt DESC";
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
