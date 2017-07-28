using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public interface IDataProvider: IDisposable
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        IDbConnection Connection { get; }
        /// <summary>
        /// 创建一个新的连接，需要调用端管理生存周期
        /// </summary>
        /// <returns></returns>
        IDbConnection Create();
    }
}
