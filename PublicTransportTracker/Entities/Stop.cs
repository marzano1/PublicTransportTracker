using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class Stop
    {
        public string stopID { get; set; }
        public int cityID { get; set; }
        public string stopName { get; set; }
        public string stopLat { get; set; }
        public string stopLon { get; set; }
    }
}