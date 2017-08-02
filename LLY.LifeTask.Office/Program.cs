using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LLY.LifeTask.Office
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var urls = new List<string>();
            if (args.Length <= 0)
            {
                urls.Add("http://*:5000");
            }
            else
            {
                urls.AddRange(args);
            }
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseUrls(urls.ToArray())
                .Build();

            host.Run();
        }
    }
}
