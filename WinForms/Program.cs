using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using Microsoft.Practices.Unity;
namespace WinForms
{

    internal static class Program
    {
        public static UnityContainer Container { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Dependency injection container
            Container = new UnityContainer();
            // WinForms cofiguration
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Additional configurator
            // NLog
            var nlogConfig = new NLog.Config.LoggingConfiguration();
            nlogConfig.AddRule(LogLevel.Trace, LogLevel.Fatal,
                new NLog.Targets.FileTarget("fileTarget")
                {
                    FileName = "log.txt"
                });
            
            NLog.LogManager.Configuration = nlogConfig;
            Logger logger = NLog.LogManager.GetCurrentClassLogger();
            // Register logger;
            Container.RegisterInstance(logger);  
            // Random - one for project
            Container.RegisterInstance(new Random());
            // Run app
            Application.Run(//new Forms.Portal(logger)
                            Container.Resolve<Forms.Portal>()
                            );
        }
    }
}
