using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{

    //trip_id      stop_id      arrival_time        departure_time
    public class StopTimesParser
    {

        private static List<int> indexes = new List<int>();

        public static List<StopTime> getStopTimesList(HttpPostedFileBase file)
        {
            List<StopTime> stopTimesList = new List<StopTime>();
            StreamReader stream = new StreamReader(file.InputStream);
            getIndexes(stream.ReadLine());

            string line = stream.ReadLine();
            while (line != null)
            {
                List<string> values = BaseParser.getValuesByLine(line, indexes);
                StopTime stopTime = new StopTime();
                stopTime.tripID = values[0]; 
                stopTime.stopID = values[1]; 
                stopTime.arrivalTime = BaseParser.parseTime(values[2]);
                stopTime.departureTime = BaseParser.parseTime(values[3]);               

                stopTimesList.Add(stopTime);
                line = stream.ReadLine();
            }
            return stopTimesList;
        }


        #region Helper Methods

        private static void getIndexes(string header)
        {
            indexes.Add(BaseParser.getFieldIndexByName(header, "stop_id"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "trip_id"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "arrival_time"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "departure_time"));

        }

        #endregion
    }
}