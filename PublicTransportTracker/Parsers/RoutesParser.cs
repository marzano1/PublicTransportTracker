using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{
    //route_id       city_id        route_short_name    route_long_name     route_type
    public class RoutesParser
    {
        private static List<int> indexes = new List<int>();

        public static List<Route> getRouteList(int cityID, HttpPostedFileBase file)
        {
            StreamReader stream = new StreamReader(file.InputStream);
            getIndexes(stream.ReadLine());

            List<Route> routeList = new List<Route>();
            string line = stream.ReadLine();
            while (line != null)
            {
                List<string> values = BaseParser.getValuesByLine(line, indexes);
                Route route = new Route();
                route.cityID = cityID;
                route.routeID = values[0];
                route.routeShortName = values[1];
                route.routeLongName = values[2];
                route.routeType = Convert.ToInt32(values[3]);                
                routeList.Add(route);
                line = stream.ReadLine();
            }
                return routeList;
        }




        #region Helper Methods

        private static void getIndexes(string header)
        {
            indexes.Add(BaseParser.getFieldIndexByName(header, "route_id"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "route_short_name"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "route_long_name"));
            indexes.Add(BaseParser.getFieldIndexByName(header, "route_type"));

        }
    
        #endregion
    }

}