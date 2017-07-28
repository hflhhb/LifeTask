using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LLY.LifeTask.Dapper
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperForSqlServer(this IServiceCollection services, string connectionString)
        {
            var options = new DapperOptions();
            options.UseSqlServer(services, connectionString);
            AddCoreServices(services, options);
            return services;
        }

        public static IServiceCollection AddDapper(this IServiceCollection services, Action<DapperOptions> optionsAction)
        {
            var options = new DapperOptions();
            optionsAction?.Invoke(options);
            AddCoreServices(services, options);
            return services;
        }

        private static void AddCoreServices(IServiceCollection services, DapperOptions options)
        {
            //services.AddSingleton<IDbConnectionFactory>(sp => new SqlConnectionFactory(options));
            services.AddScoped<IDataProvider, DefaultDataProvider>();
        }
    }
}