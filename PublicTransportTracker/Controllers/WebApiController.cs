using PublicTransportTracker.Models.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PublicTransportTracker.Controllers
{
    public class WebApiController : Controller
    {
        private static readonly IList<CommentsModel> _comments;

        static WebApiController()
        {
            _comments = new List<CommentsModel>
            {
                new CommentsModel
                {
                    Id = 1,
                    Author = "Daniel Los Negro",
                    Text = "Hello ReactJS.NET World!"
                },
                new CommentsModel
                {
                    Id = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new CommentsModel
                {
                    Id = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}