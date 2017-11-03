using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class Route
    {
        public string routeID { get; set; }
        public int cityID { get; set; }
        public string routeShortName { get; set; } 
        public string routeLongName { get; set; }
        public int routeType { get; set; }
    }
}