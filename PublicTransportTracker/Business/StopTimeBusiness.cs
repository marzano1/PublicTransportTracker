using PublicTransportTracker.Entities;
using PublicTransportTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class StopTimeBusiness
    {
        public static void InsertStopTimeList(List<StopTime> stopTimeList)
        {
            StopTimeDA.InsertStopTimeList(stopTimeList);
        }
    }
}