using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Models.WebApi
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}