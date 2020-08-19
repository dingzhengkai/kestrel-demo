
using System.IO;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog;

namespace kestreldemo
{
    public class Program
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();
        static Program()
        {
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(@"Nlog.config");
        }
        public static void Main(string[] args)
        {
            LOGGER.Debug("Begin");
            CreateWebHostBuilder(args).Build().Run();
            LOGGER.Debug("End");
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(@"hosting.json", false)
                .Build();
            var host = WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseConfiguration(config)
            .UseStartup<Startup>();
            return host;
        }
    }
}
