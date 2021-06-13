using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static bool IsDateBetween(this DateTime date, DateTime start, DateTime end)
        {
            return date >= start && date <= end;
        }
    }
}
