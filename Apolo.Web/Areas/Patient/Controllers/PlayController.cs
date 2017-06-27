using Apolo.Core.Business;
using Apolo.Core.Model;
using Apolo.Core.Model.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Patient.Controllers
{
    public class PlayController : Controller
    {
        RoutineService routineService = new RoutineService();

        // GET: Patient/Play
        public ActionResult Index(int workUnitId)
        {
            var workUnit = routineService.GetWorkUnitById(workUnitId).RequestedObject as WorkUnit;
            ViewBag.WorkUnit = workUnit;
            switch (workUnit.Game)
            {
                case Constants.Games.INVADERS: return View("Invaders");
                case Constants.Games.PONG: return View("Pong");
                case Constants.Games.TETRIS: return View("Tetris");
                case Constants.Games.JUMPER: return View("Jumper");
            }
            return View();
        }

        public ActionResult CompleteWorkUnit(int workUnitId, int? finalScore, WorkUnitCompletion workUnitCompletion)
        {
            routineService.CompleteWorkUnitById(workUnitId, finalScore ?? 0, workUnitCompletion);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}