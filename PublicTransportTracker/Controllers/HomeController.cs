using PublicTransportTracker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // CountryDA.GetCountryByName("Brasil");
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}