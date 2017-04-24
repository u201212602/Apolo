using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Controllers
{
    public class UtilController : Controller
    {
        SecurityService securityService = new SecurityService();
        // GET: Util
        public ActionResult UserAvatar(string username)
        {
            OperationResult operationResult = securityService.GetUser(username);
            User user = operationResult.RequestedObject as User;
            return File(user.Avatar, "image/png");
        }
    }
}