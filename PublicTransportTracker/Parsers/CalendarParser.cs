using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{


    //service_id        weekDays(bitmask, transformar dias da semana)       start_date      end_date
    public class CalendarParser
    {


        private static List<int> indexes = new List<int>();


        public static List<Calendar> getCalendarList(int cityID, HttpPostedFileBase file)
        {
            StreamReader stream = new StreamReader(file.InputStream);
            getIndexes(stream.ReadLine());

            List<Calendar> calendarList = new List<Calendar>();
            string line = stream.ReadLine();
            while (line != null)
            {
                List<string> values = BaseParser.getValuesByLine(line, indexes);
                Calendar calendar = new Calendar();
                calendar.cityID = cityID;
                calendar.serviceID = values[0];
                calendar.weekDays = getWeekDays(values);            
                calendar.startDate = BaseParser.parseDate(values[8]);
                calendar.endDate = BaseParser.parseDate(values[9]);
                calendarList.Add(calendar);
                line = stream.ReadLine();
            }



            return calendarList;
        }




        #region Helper Methods

        private static void getIndexes(string header)
        {
            indexes.Add(BaseParser.getFieldIndexByName(header, "service_id"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "monday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "tuesday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "wednesday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "thursday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "friday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "saturday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "sunday"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "start_date"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "end_date"));

        }

        private static string getWeekDays(List<string> values)
        {
            string days = "";
            days += values[1];
            days += values[2];
            days += values[3];
            days += values[4];
            days += values[5];
            days += values[6];
            days += values[7];
            return days;
        }
        #endregion
    }
}