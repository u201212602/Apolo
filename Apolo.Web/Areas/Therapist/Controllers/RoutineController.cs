using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Model.Treatment;
using Apolo.Web.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist.Controllers
{
    [ApoloAuthorize(Roles = Constants.Roles.THERAPIST)]
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
            ViewBag.RoutineBlueprints = routineService.GetAllRoutineBlueprints().RequestedObject;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var operationRequest = new OperationRequest
            {
                Parameters = new Dictionary<string, object>
                {
                    { Constants.Operation.PATIENT_ID,  Int32.Parse(collection["patientID"]) },
                    { Constants.Operation.THERAPIST_ID,  Int32.Parse(collection["therapistID"]) },
                    { Constants.Operation.GOAL,  collection["goal"] },
                    { Constants.Operation.DETAILS,  collection["details"] },
                    { Constants.Operation.START_DATE,  DateTime.ParseExact(collection["startDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                    { Constants.Operation.BLUEPRINT_ID,  Int32.Parse(collection["routineBlueprintID"]) }
                }
            };

            var operationResult = routineService.MakeRoutineFromBlueprint(operationRequest);

            if(operationResult.WasSuccessful)
            {
                TempData["SuccessMessage"] = "Se registró la rutina exitosamente. Rutina con ID: " + ((Routine)operationResult.RequestedObject).ID;
            }
            else
            {
                TempData["ErrorMessage"] = "Ocurrió un error al intentar crear la rutina.";
            }

            return RedirectToAction("List");
        }
    }
}