using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LLY.LifeTask.Dapper
{
    public static class DataProviderExtensions
    {
        /// <summary>
        /// 使用新的数据库连接，执行相关数据库操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbFactory"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static async Task<T> UsingAsync<T>(this IDataProvider dbFactory, Func<IDbConnection, Task<T>> func)
        {
            using (var db = dbFactory.Create())
            {
                return await func?.Invoke(db);
            }
        }

        /// <summary>
        /// 使用新的数据库连接，执行相关数据库操作
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Task UsingAsync(this IDataProvider dbFactory, Func<IDbConnection, Task> func)
        {
            using (var db = dbFactory.Create())
            {
                return func?.Invoke(db);
            }
        }

        /// <summary>
        /// 使用新的数据库连接，执行相关数据库操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbFactory"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Using<T>(this IDataProvider dbFactory, Func<IDbConnection, T> func)
        {
            using (var db = dbFactory.Create())
            {
                return func.Invoke(db);
            }
        }

        /// <summary>
        /// 使用新的数据库连接，执行相关数据库操作
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <param name="dbAction"></param>
        public static void Using(this IDataProvider dbFactory, Action<IDbConnection> dbAction)
        {
            using (var db = dbFactory.Create())
            {
                dbAction.Invoke(db);
            }
        }
    }
}
