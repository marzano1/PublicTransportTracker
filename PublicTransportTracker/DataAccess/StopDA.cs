using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PublicTransportTracker.DataAccess
{
    public class StopDA
    {

        public static void InsertStopList(List<Stop> stopList)
        {
            List<List<object>> values = new List<List<object>>();
            foreach (Stop s in stopList)
            {
                List<object> objList = new List<object>();
                objList.Add(s.stopID);
                s.stopName = s.stopName.Replace("'", "");
                objList.Add(s.stopName);
                StringBuilder point = new StringBuilder();
                point.Append(String.Format("ST_GeomFromText('POINT({0} {1})', 4326)", s.stopLat, s.stopLon));
                objList.Add(point.ToString());
                values.Add(objList);
            }
            BaseDB.executeInsert("stop", values);
        }
    }
}

//st_GeomFromText('POINT(34.774531000000003 -96.678344899999999)', 312)