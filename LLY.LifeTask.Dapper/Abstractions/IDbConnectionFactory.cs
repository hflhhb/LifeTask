using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        IDbConnection Create();
    }
}
