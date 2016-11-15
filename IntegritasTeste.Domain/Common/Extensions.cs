using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegritasTeste.Domain.Common
{
    public static partial class Extensions 
    {

        public static DateTime CurrentDate(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }

        public static void Log(this Exception ex)
        {
            //CallLogger app
            
        }






    }
}
