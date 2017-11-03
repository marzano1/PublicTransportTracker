using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class Trip
    {
        public string tripID { get; set; }
        public string routeID { get; set; }
        public string serviceID { get; set; }
        public string tripHeadSign { get; set; }
        public int directionID { get; set; }
        public List<ShapeCoordinate> coordinates { get; set; }
    }
}