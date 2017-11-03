using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class City
    {
        public int cityID { get; set; }
        public int countryID { get; set; }
        public string cityName { get; set; }
        public string timezone { get; set; }
    }
}