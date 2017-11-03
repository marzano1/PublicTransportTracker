using PublicTransportTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class UtilBusiness
    {
        public static void DeleteAllData()
        {
            BaseDB.deleteAllData();
        }

        public static string ConvertToTimestamp(DateTime value)
        {
            StringBuilder date = new StringBuilder();
            date.Append(String.Format("{0}-{1}-{2}", value.Year, value.Month, value.Day));
            return date.ToString();
        }

        public static string ConvertToTime(DateTime value)
        {
            string date = value.ToString("HH:mm:ss");
            //date.Append(String.Format("{0}:{1}:{2}", value.TimeOfDay.Hours, value.TimeOfDay.Minutes, value.TimeOfDay.Seconds));
            return date.ToString();
        }

    }
}