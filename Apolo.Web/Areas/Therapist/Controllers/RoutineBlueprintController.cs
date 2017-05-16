using Apolo.Core.Business;
using Apolo.Core.Model;
using System;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist.Controllers
{
    public class RoutineBlueprintController : Controller
    {
        RoutineService routineService = new RoutineService();

        // GET: Therapist/Blueprint
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var routineBlueprints = routineService.GetAllRoutineBlueprints().RequestedObject;
            ViewBag.RoutineBlueprints = routineBlueprints;
            return View();
        }

        public ActionResult SelectRoutineBlueprint(string routineBlueprintId)
        {
            var routineBlueprint = routineService.GetRoutineBlueprintById(Int32.Parse(routineBlueprintId)).RequestedObject;
            Session[Constants.SESSION_ROUTINEBLUEPRINT] = routineBlueprint;
            return RedirectToAction("Edit");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}