using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PublicTransportTracker.DataAccess
{
    public class TripDA
    {

        private static string GetLineString(List<ShapeCoordinate> coordinates)
        {
            StringBuilder lineString = new StringBuilder();
            lineString.Append(String.Format("ST_GeomFromText('LINESTRING("));
            foreach (ShapeCoordinate c in coordinates)
            {
                lineString.Append(String.Format("{0} {1},", c.latitude, c.longitude));
            }
            lineString.Remove(lineString.Length - 1, 1);
            lineString.Append(String.Format(")', 4326)"));
            return lineString.ToString();
        }

        public static void InsertTripList(List<Trip> tripList)
        {
            List<List<object>> values = new List<List<object>>();
            foreach (Trip t in tripList)
            {
                List<object> objList = new List<object>();
                objList.Add(t.tripID);
                objList.Add(t.routeID);
                objList.Add(t.serviceID);
                objList.Add(GetLineString(t.coordinates));
                if (!String.IsNullOrEmpty(t.tripHeadSign)) objList.Add(t.tripHeadSign);
                else objList.Add("");
                objList.Add(t.directionID);
                values.Add(objList);
            }
            BaseDB.executeInsert("trip", values);
        }
    }
}
