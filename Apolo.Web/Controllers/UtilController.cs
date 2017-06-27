using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model;
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
            OperationResult operationResult = securityService.GetUserByUsername(username);
            User user = operationResult.RequestedObject as User;
            if(user.Avatar != null && user.Avatar.Length > 0)
            {
                return File(user.Avatar, "image/png");
            }
            else
            {
                return File("~/Assets/img/default-user.png", "image/png");
            }
        }

        public ActionResult GameAvatar(string gameName, string small)
        {
            string folder = "~/Assets/img/";
            string fileName = "defaultGameAvatar.png";
            if(!string.IsNullOrEmpty(small))
            {
                folder += "/small/";
            }
            switch(gameName)
            {
                case Constants.Games.TETRIS: fileName = "tetris.png"; break;
                case Constants.Games.INVADERS: fileName = "invaders.png"; break;
                case Constants.Games.PONG: fileName = "pong.png"; break;
                case Constants.Games.JUMPER: fileName = "jumper.png"; break;
            }
            return File(folder + fileName, "image/png");
        }
    }
}