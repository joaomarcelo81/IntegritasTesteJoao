using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegritasTeste.Domain.Common
{
    public static class Tracker
    {
        public static void Debug(string msg){}
        public static void Info(string msg) { }
        public static void Log(string msg) { }
        public static void Error(string msg) { }
    }
}
