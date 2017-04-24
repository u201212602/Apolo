using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Filters
{
    public class ApoloAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAnonAllowed = filterContext.ActionDescriptor.IsDefined(
                    typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                    typeof(AllowAnonymousAttribute), true);

            if (isAnonAllowed)
                return;

            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if(session[Constants.SESSION_USER] == null)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }
            else if(!string.IsNullOrEmpty(Roles))
            {
                User currentUser = session[Constants.SESSION_USER] as User;
                var roleArray = Roles.Split(new char[] { ',' });

                if(!roleArray.Contains(currentUser.Role))
                {
                    filterContext.Controller.TempData["ErrorMessage"] = "Usuario no autorizado";
                    HandleUnauthorizedRequest(filterContext);
                    return;
                }
            }
        }
    }
}