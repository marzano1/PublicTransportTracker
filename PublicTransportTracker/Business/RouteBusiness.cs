using PublicTransportTracker.Entities;
using PublicTransportTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class RouteBusiness
    {

        public static void InsertRouteList(List<Route> routeList)
        {
            RouteDA.InsertRouteList(routeList);
        }
    }
}