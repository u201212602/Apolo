using Apolo.Core.Business;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Model.Treatment;
using Apolo.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Patient.Controllers
{
    [ApoloAuthorize(Roles = Constants.Roles.PATIENT)]
    public class HomeController : Controller
    {
        RoutineService routineService = new RoutineService();

        // GET: Patient/Home
        public ActionResult Index()
        {
            var patient = Session[Constants.SESSION_USER] as User;
            var workDayForToday = routineService.GetWorkDayForToday(patient.Username).RequestedObject;
            ViewBag.WorkDayForToday = workDayForToday;
            return View();
        }

        public ActionResult PlayWorkUnit(int patientId, int workUnitId)
        {
            var workUnit = routineService.GetWorkUnitById(workUnitId).RequestedObject as WorkUnit;
            ViewBag.WorkUnit = workUnit;
            switch(workUnit.Game)
            {
                case Constants.Games.INVADERS: return View("Invaders");
                case Constants.Games.PONG: return View("Pong");
                case Constants.Games.TETRIS: return View("Tetris");
            }
            return View();
        }

        public ActionResult CompleteWorkUnit(int workUnitId)
        {
            routineService.CompleteWorkUnitById(workUnitId);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}