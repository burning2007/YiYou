using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Yiyou.SQLServerDAL
{
    [Serializable]
    public class SqlWrapper
    {
        private string _strSql;
        private SqlParameter[] _para;

        public SqlWrapper() { }
        public SqlWrapper(string strSql, SqlParameter[] paras)
        {
            this._strSql = strSql;
            this._para = paras;
        }
        public string SqlString
        {
            get { return _strSql; }
            set { _strSql = value; }
        }

        public SqlParameter[] Parameter
        {
            get { return _para; }
            set { _para = value; }
        }
    }
}
