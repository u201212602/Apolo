using Apolo.Core.Model;
using Apolo.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist.Controllers
{
    [ApoloAuthorize(Roles = Constants.Roles.THERAPIST)]
    public class HomeController : Controller
    {
        // GET: Therapist/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Patients()
        {
            return View();
        }
    }
}