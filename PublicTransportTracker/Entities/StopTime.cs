using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class StopTime
    {
        public string tripID { get; set; }
        public string stopID { get; set; }
        public DateTime arrivalTime { get; set; }       
        public DateTime departureTime { get; set; }
    }
}