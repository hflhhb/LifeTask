using System;
using System.Collections.Generic;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public class DapperOptions
    {
        public DapperOptions()
        {

        }
        public DapperOptions(string connectString)
        {
            ConnectString = connectString;
        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectString { get; set; }
    }
}
