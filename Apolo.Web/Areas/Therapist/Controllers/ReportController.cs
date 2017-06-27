using Apolo.Core.Business;
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
    public class ReportController : Controller
    {
        RoutineService routineService = new RoutineService();

        // GET: Therapist/Report
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult WorkDay(int workDayId)
        {
            var workDay = routineService.GetWorkDayById(workDayId).RequestedObject;
            ViewBag.WorkDay = workDay;

            return PartialView();
        }

        public PartialViewResult WorkWeek(int workWeekId)
        {
            var workWeek = routineService.GetWorkWeekById(workWeekId).RequestedObject;
            ViewBag.WorkWeek = workWeek;

            return PartialView();
        }

        public PartialViewResult Routine(int routineId)
        {
            var routine = routineService.GetRoutineById(routineId).RequestedObject;
            ViewBag.Routine = routine;

            return PartialView();
        }
    }
}