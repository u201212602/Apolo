using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist.Controllers
{
    public class RoutineController : Controller
    {
        RoutineService routineService = new RoutineService();

        // GET: Therapist/Routine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        { 
            User sessionPatient = Session[Constants.SESSION_PATIENT] as User;
            OperationResult result = routineService.GetRoutinesForUsername(sessionPatient.Username);
            ViewBag.Routines = result.RequestedObject;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}