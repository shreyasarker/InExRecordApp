using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InExRecordApp
{
    public static class Helper
    {
        public static List<KeyValuePair<string, string>> GetMonths()
        {
            var months = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("January", "January"),
                new KeyValuePair<string, string>("February", "February"),
                new KeyValuePair<string, string>("March", "March"),
                new KeyValuePair<string, string>("April", "April"),
                new KeyValuePair<string, string>("May", "May"),
                new KeyValuePair<string, string>("June", "June"),
                new KeyValuePair<string, string>("July", "July"),
                new KeyValuePair<string, string>("August", "August"),
                new KeyValuePair<string, string>("September", "September"),
                new KeyValuePair<string, string>("October", "October"),
                new KeyValuePair<string, string>("November", "November"),
                new KeyValuePair<string, string>("December", "December"),
            };

            return months;
        }
    }
}
