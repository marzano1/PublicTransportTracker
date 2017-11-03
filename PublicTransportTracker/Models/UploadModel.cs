using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Models
{
    public class UploadModel
    {
        public string countryName { get; set; }

        public string cityName { get; set; }

        public HttpPostedFileBase agencyFile { get; set; }

        public HttpPostedFileBase calendarFile { get; set; }

        public HttpPostedFileBase routesFile { get; set; }

        public HttpPostedFileBase shapesFile { get; set; }

        public HttpPostedFileBase tripsFile { get; set; }

        public HttpPostedFileBase stopsFile { get; set; }

        public HttpPostedFileBase stopTimesFile { get; set; }
    }
}