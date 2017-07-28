using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace LLY.LifeTask.Dapper
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        //"data source='.';initial catalog=LifeNext;persist security info=True;user id=sa;password=SQL2014P@ssword;Connect Timeout=30;";
        private string _connstr;
        public SqlServerConnectionFactory(DapperOptions options)
        {
            _connstr = options.ConnectString;
        }
        public IDbConnection Create()
        {
            return new SqlConnection(_connstr);
        }
    }
}
