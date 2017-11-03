using PublicTransportTracker.DataAccess;
using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Business
{
    public class TripBusiness
    {
        public static void InsertTripList(List<Trip> tripList)
        {
            TripDA.InsertTripList(tripList);
        }
    }
}