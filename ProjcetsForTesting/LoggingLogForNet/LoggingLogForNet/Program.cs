using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository;


namespace LoggingLogForNet
{
    class Program
    {
        private static readonly ILog log = 
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());


        static void Main(string[] args)
        {
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Console.WriteLine("Hello world!");

            log.Info("Hello logging world!");
            log.Error("Error!");
            log.Warn("Warn!");

            Console.ReadKey();
        }
    }
}
