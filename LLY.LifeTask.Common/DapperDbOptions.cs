using System;
using System.Collections.Generic;
using System.Text;

namespace LLY.LifeTask.Common
{
    public class DapperDbOptions
    {
        public DapperDbOptions(string connectString)
        {
            ConnectString = connectString;
        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectString { get; set; }
    }
}
