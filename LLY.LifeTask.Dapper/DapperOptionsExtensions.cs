using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public static class DapperOptionsExtensions
    {

        public static DapperOptions UseSqlServer(this DapperOptions options, IServiceCollection services, string connectString)
        {
            options.ConnectString = connectString;
            services.AddSingleton<IDbConnectionFactory>(sp => new SqlServerConnectionFactory(options));
            //
            return options;
        }
    }
}
