using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist.Controllers
{
    [ApoloAuthorize(Roles = Constants.Roles.THERAPIST)]
    public class PatientController : Controller
    {
        SecurityService securityService = new SecurityService();

        // GET: Therapist/Patient
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult List()
        {
            OperationResult result = securityService.GetAllPatients();

            ViewBag.Patients = result.RequestedObject;

            return View();
        }

        public ActionResult SelectPatient(string patientId)
        {
            OperationResult result = securityService.GetUserByID(Int32.Parse(patientId));
            Session[Constants.SESSION_PATIENT] = result.RequestedObject;
            return RedirectToAction("List", "Routine");
        }

        public ActionResult Summary()
        {
            return View();
        }
    }
}