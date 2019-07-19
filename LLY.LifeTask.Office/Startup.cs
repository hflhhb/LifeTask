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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

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
            var logger = loggerFactory.CreateLogger<Startup>();
            
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

            app.Use(async (context, next) =>{

                //await Task.Delay(0);

                logger.LogInformation("");
                var s = context.Request.Cookies["sessionId"];

                Extensions.AddUserCookies(context, "SDKSessionId", "xxafeinjqwetrqwe", "SDKSession" );
                context.Response.Cookies.Append("sessionSDK", "ssss");
                await next.Invoke();
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class Extensions
    {
        public static void AddUserCookies(HttpContext httpContext, string key, string value, string cookiename)
        {
            //原始代码
            //var cookie = httpContext.Request.Cookies[cookiename];
            //if (cookie != null)
            //    httpContext.Request.Cookies.Remove(cookiename);
            //cookie = new HttpCookie(cookiename) {Expires = DateTime.Now.AddHours(4), [key] = value};
            //httpContext.Response.AppendCookie(cookie);

            if (httpContext.Request.Cookies.ContainsKey(cookiename))
            {
                httpContext.Response.Cookies.Delete(cookiename);
            }
            httpContext.Response.Headers.AppendRawValueCookie(cookiename, new Dictionary<string, string>{{key, value}}.ToLegacyCookieString(), new CookieOptions
            {
                Expires = DateTime.Now.AddHours(4)
            });
        }


        public static void AppendRawValueCookie(this IHeaderDictionary headers, string key, string value, CookieOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            SetCookieHeaderValue cookieHeaderValue = new SetCookieHeaderValue(Uri.EscapeDataString(key), value)
            {
                Domain =  options.Domain,
                Path =  options.Path,
                Expires = options.Expires
            };
            int num1 = options.Secure ? 1 : 0;
            cookieHeaderValue.Secure = num1 != 0;
            int sameSite = (int)options.SameSite;
            cookieHeaderValue.SameSite = (Microsoft.Net.Http.Headers.SameSiteMode)sameSite;
            int num2 = options.HttpOnly ? 1 : 0;
            cookieHeaderValue.HttpOnly = num2 != 0;
            headers["Set-Cookie"] = StringValues.Concat(headers["Set-Cookie"], (StringValues)cookieHeaderValue.ToString());
        }

        public static IDictionary<string, string> FromLegacyCookieString(this string legacyCookie)
        {
            return legacyCookie.Split('&').Select(s => s.Split('=')).ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }

        public static string ToLegacyCookieString(this IDictionary<string, string> dict)
        {
            return string.Join("&", dict.Select(kvp => string.Join("=", kvp.Key, kvp.Value)));
        }
    }
}
