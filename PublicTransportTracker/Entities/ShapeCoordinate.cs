using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Entities
{
    public class ShapeCoordinate
    {
        public string shapeID { get; set; }
        public int pointSeq { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}