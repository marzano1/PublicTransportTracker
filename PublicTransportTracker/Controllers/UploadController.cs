using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PublicTransportTracker.Models;
using PublicTransportTracker.Business;

namespace PublicTransportTracker.Controllers
{

    public class UploadController : Controller
    {

        [HttpPost]
        public ActionResult Upload(UploadModel model)
        {
            if (model.countryName == null) return UploadError("Country field is empty!");
            else if (model.cityName == null) return UploadError("City field is empty!");
            //CheckUploadedFiles(model);

            int error = UploadBusiness.PersistTransportData(model);

            if(error == 0)
            {
                return View("~/Views/Home/Upload.cshtml");
            }
            else
            {
                return UploadError("Something gone wrong!");
            }
            
            
        }

        private ActionResult UploadError(string error)
        {
            ViewBag.error = error;
            return View("~/Views/Home/Upload.cshtml");
        }

        private void CheckUploadedFiles(UploadModel model)
        {
            if (model.agencyFile == null) UploadError("Agency file is missing!");
            if (model.calendarFile == null) UploadError("Calendar file is missing!");
            if (model.routesFile == null) UploadError("Routes file is missing!");
            if (model.tripsFile == null) UploadError("Trips file is missing!");
            if (model.shapesFile == null) UploadError("Shapes file is missing!");
            if (model.stopsFile == null) UploadError("Stops file is missing!");
            if (model.stopTimesFile == null) UploadError("Stop Times file is missing!");
        }


    }
}



