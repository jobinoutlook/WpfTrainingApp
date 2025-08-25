using log4net;
using System.Configuration;
using System.Data;
using System.Windows;

namespace EvernoteClone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            log.Info("Application started.");
        }

    }

}
