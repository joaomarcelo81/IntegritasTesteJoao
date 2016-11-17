using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegritasTeste.Domain.Entities;
using IntegritasTeste.Domain.Interface.Aplications;
using Ninject;

namespace IntegritasTeste.Domain.Common
{
    public static partial class Extensions 
    {

        public static DateTime CurrentDate(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }

        private static IKernel _diContainer;
        private static ILoggerApplication _loggerApp;

        public static void Init(IKernel dIcontainer)
        {
            _diContainer = dIcontainer;
            _loggerApp = _diContainer.Get<ILoggerApplication>();
        }
        public static void Log(this Exception ex)
        {
            _loggerApp.Add(new Logger()
            {
                DateTime = DateTime.Now,
                Message = ex.Message,
                Name = "Exception",
                Description = ex.StackTrace
            });

        }
        public static void Log(this Exception ex, string message)
        {
            _loggerApp.Add(new Logger()
            {
                DateTime = DateTime.Now,
                Message = message,
                Name = "Exception",
                Description = ex.StackTrace
            });
            _loggerApp.Save();

        }
        public static void Log(this Exception ex, string message, string stacktrace)
        {
            _loggerApp.Add(new Logger()
            {
                DateTime = DateTime.Now,
                Message = message,
                Name = "Exception",
                Description = stacktrace
            });
            _loggerApp.Save();
        }


        public static void Log(this Exception ex, string message, string stacktrace, string name)
        {
            _loggerApp.Add(new Logger()
            {
                DateTime = DateTime.Now,
                Message = message,
                Name = name,
                Description = stacktrace
            });
            _loggerApp.Save();
        }
    }
}
