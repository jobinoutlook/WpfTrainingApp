using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfCoreApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class AppConfig
    {
        public static IConfiguration Configuration { get; }

        static AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) //This extension method is in Microsoft.Extensions.Configuration.FileExtensions
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // This extension method is in Microsoft.Extensions.Configuration.Json
                .Build();
        }
    }



}
