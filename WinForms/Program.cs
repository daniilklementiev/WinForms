using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WinForms
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
                            
            // Run app
            Application.Run(new Forms.Portal(logger));
        }
    }
}
