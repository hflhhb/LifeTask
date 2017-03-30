using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public class DapperDataProvider
    {
        public string _connstr = "data source='.';initial catalog=LifeNext;persist security info=True;user id=sa;password=SQL2014P@ssword;Connect Timeout=30;";
        protected DbConnection GetDbConnection()
        {
            return new SqlConnection(_connstr);
        }

        protected DbConnection GetDbConnection(string connstr)
        {
            return new SqlConnection(connstr);
        }
    }
}
