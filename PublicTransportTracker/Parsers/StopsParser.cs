using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{

    //stop_id   stop_name   stop_lat    stop_lon    
    public class StopsParser
    {
        
        private static List<int> indexes = new List<int>();

        public static List<Stop> getStopList(int cityID, HttpPostedFileBase file)
        {
            StreamReader stream = new StreamReader(file.InputStream);
            getIndexes(stream.ReadLine());

            List<Stop> stopList = new List<Stop>();
            string line = stream.ReadLine();
            while (line != null)
            {
                List<string> values = BaseParser.getValuesByLine(line, indexes);
                Stop stop = new Stop();
                stop.cityID = cityID;
                stop.stopID = values[0];
                stop.stopName = values[1];
                stop.stopLat = values[2];
                stop.stopLon = values[3];
                stopList.Add(stop);
                line = stream.ReadLine();
            }
            return stopList;
        }


        #region Helper Methods

        private static void getIndexes(string header)
        {
            indexes.Add(BaseParser.getFieldIndexByName(header, "stop_id"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "stop_name"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "stop_lat"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "stop_lon"));

        }

        #endregion
    }
}