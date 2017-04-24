using Apolo.Core.Model;
using Apolo.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Administrator.Controllers
{
    [ApoloAuthorize(Roles = Constants.Roles.ADMINISTRATOR)]
    public class HomeController : Controller
    {
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}