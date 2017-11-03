using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class Calendar
    {
        public string serviceID { get; set; }
        public int cityID { get; set; }
        public string weekDays { get; set; } //BitMask
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

}