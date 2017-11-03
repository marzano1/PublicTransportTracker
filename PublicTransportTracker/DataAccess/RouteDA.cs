using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.DataAccess
{
    public class RouteDA
    {
        public static void InsertRouteList(List<Route> routeList)
        {
            List<List<object>> values = new List<List<object>>();
            foreach (Route r in routeList)
            {
                List<object> objList = new List<object>();
                objList.Add(r.routeID);
                objList.Add(r.cityID);
                objList.Add(r.routeShortName);
                objList.Add(r.routeLongName);
                objList.Add(r.routeType);
                values.Add(objList);
            }
            BaseDB.executeInsert("route", values);

        }
    }
}