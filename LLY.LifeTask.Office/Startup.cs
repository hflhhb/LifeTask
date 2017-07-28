using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LLY.LifeTask.Service;
using LLY.LifeTask.EntityFramework.Repositories;
using LLY.LifeTask.EntityFramework;
using LLY.LifeTask.Model.EntityFramework;
using LLY.LifeTask.Dapper;
using LLY.LifeTask.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace LLY.LifeTask.Office
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var lifeConnectionString = Configuration.GetConnectionString("Life");
            //SqlServer DbConnectString
            services.AddDbContext<LifeDbContext>(optBuilder => {
                //optBuilder.UseSqlServer(lifeConnectionString);
                optBuilder.UseSqlServer(lifeConnectionString, 
                    o =>o.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null));
                optBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));

            });
            //services.AddSingleton(o => new DapperDataProvider(new DapperOptions(lifeConnectionString)));
            services.AddDapper(o => o.UseSqlServer(services, lifeConnectionString));
            // Add application services.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add framework services.
            services.AddMvc();
            //DI
            services.AddScoped<IDataContextFactory<LifeDbContext>, GenericDataContextFactory<LifeDbContext>>();
            services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();
            services.AddScoped<ISaleOrderProvider, SaleOrderProvider>();
            services.AddScoped<ISaleOrderEfService, SaleOrderServiceForEF>();
            services.AddScoped<ISaleOrderDapperService, SaleOrderServiceForDapper>();
            services.AddScoped<ISaleOrderService, SaleOrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
