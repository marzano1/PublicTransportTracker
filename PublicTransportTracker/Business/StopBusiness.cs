using PublicTransportTracker.Entities;
using PublicTransportTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class StopBusiness
    {
        public static void InsertStopList(List<Stop> stopList)
        {
            StopDA.InsertStopList(stopList);
        }
    }
}