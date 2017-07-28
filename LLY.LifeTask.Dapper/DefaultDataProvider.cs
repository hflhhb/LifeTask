using LLY.LifeTask.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LLY.LifeTask.Dapper
{
    public class DefaultDataProvider : IDataProvider, IDisposable
    {
        private IDbConnectionFactory _connectionFactory;
        private IDbConnection _connection;
        private object _conLocker = new object();
        public DefaultDataProvider(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// 数据库连接，调用方直接使用，不需要管理生存期间
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if(_connection == null)
                {
                    lock (_conLocker)
                    {
                        //if (_connection != null)
                        //{
                        //    if (_connection.State == ConnectionState.Closed)
                        //    {
                        //        _connection.Open();
                        //    }
                        //    return _connection;
                        //}
                        if(_connection == null)
                        {
                            _connection = _connectionFactory.Create();
                        }
                    }
                }

                return _connection;


            }
        }

        /// <summary>
        /// 创建新的数据库连接， 需要调用方管理连接的释放
        /// </summary>
        /// <returns></returns>
        public IDbConnection Create()
        {
            return _connectionFactory.Create();
        }
/*
        public Task<T> UsingAsync<T>(Func<IDbConnection, Task<T>> func)
        {
            using(var db = _connectionFactory.Create())
            {
                return func?.Invoke(db);
            }
        }
        public Task UsingAsync(Func<IDbConnection, Task> func)
        {
            using (var db = _connectionFactory.Create())
            {
                return func?.Invoke(db);
            }
        }
        public T Using<T>(Func<IDbConnection, T> func)
        {
            using (var db = _connectionFactory.Create())
            {
                return func.Invoke(db);
            }
        }
        public void Using(Action<IDbConnection> dbAction)
        {
            using (var db = _connectionFactory.Create())
            {
                dbAction.Invoke(db);
            }
        }
*/
        public void Dispose()
        { 
            if(_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
