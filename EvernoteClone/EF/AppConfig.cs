using EvernoteClone.ViewModel;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvernoteClone.EF
{
    public static class AppConfig
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AppConfig));
        public static IConfiguration Configuration { get; }

        static AppConfig()
        {
            try
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(AppContext.BaseDirectory, "EF"))
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            }
            catch(Exception ex)
            {
                //Console.WriteLine($"AppConfig init failed: {ex}");
                log.Error(ex);              
            }
        }

        public static string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }


    }
}
