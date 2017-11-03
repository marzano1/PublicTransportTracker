using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{
    public class BaseParser
    {
        public static int getFieldIndexByName(string header, string fieldName)
        {
            int i = 0;
            string[] fieldList = header.Split(',');
            foreach (string field in fieldList)
            {
                if (field == fieldName) return i;
                i++;
            }
            return -1;
        }

        public static string getFieldValueByIndex(int index, string line)
        {
            string[] fieldValues = line.Split(',');
            return fieldValues[index];
        }

        public static List<string> getValuesByLine(string line, List<int> indexes)
        {
            List<string> values = new List<string>();
            string[] fieldValues = line.Split(',');
            foreach(int i in indexes)
            {
                values.Add(fieldValues[i]);
            }
            return values;
        }

        public static DateTime parseDate(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd",CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        public static DateTime parseTime(string date)
        {
            //Debug.WriteLine(date);
            return DateTime.ParseExact(date, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

    }
}