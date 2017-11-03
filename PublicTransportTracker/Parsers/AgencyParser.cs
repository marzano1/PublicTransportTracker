using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PublicTransportTracker.Parsers
{
    public class AgencyParser
    {
        private static int timeZoneIndex = 0;

        public static string getTimeZone(HttpPostedFileBase file)
        {
            StreamReader stream = new StreamReader(file.InputStream);
            getIndexes(stream.ReadLine());
            string timeZone = "";
            string line = stream.ReadLine();
            while (line != null)
            {
                timeZone = BaseParser.getFieldValueByIndex(timeZoneIndex, line);
                line = stream.ReadLine();
            }            
            return timeZone;

        }



        #region Helper Methods

        private static void getIndexes(string header)
        {
            timeZoneIndex = BaseParser.getFieldIndexByName(header, "agency_timezone");
        }




        #endregion

    }
}