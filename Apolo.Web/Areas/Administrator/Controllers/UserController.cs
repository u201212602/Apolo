using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apolo.Web.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        SecurityService securityService = new SecurityService();

        // GET: Administrator/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            OperationResult result = securityService.GetAllUsers();

            ViewBag.Users = result.RequestedObject;

            return View();
        }

        [HttpPost]
        public ActionResult Save(FormCollection collection, User user, HttpPostedFileBase image)
        {
            if(image != null)
            {
                MemoryStream target = new MemoryStream();
                image.InputStream.CopyTo(target);
                user.Avatar = target.ToArray();
            }

            if(collection["Birthdayx"] != null)
            {
                user.Birthday = DateTime.ParseExact(collection["Birthdayx"] as string, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            bool isNew = user.ID == 0;
            OperationResult operationResult = securityService.SaveUser(user);

            switch(operationResult.WasSuccessful)
            {
                case true:
                    user = operationResult.RequestedObject as User;
                    if(isNew)
                    {
                        TempData["SuccessMessage"] = "Se creó exitosamente el usuario. El ID generado es " + user.ID + ".";
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Se editó exitosamente el usuario.";
                    }
                    break;
                case false:
                    if(isNew)
                    {
                        TempData["ErrorMessage"] = "Ocurrió un problema al intentar crear el usuario. Contacte a soporte.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Ocurrió un problema al intentar editar el usuario. Contacte a soporte.";
                    }
                    break;
            }

            return RedirectToAction("List");
        }

        public ActionResult Block(int userId)
        {
            OperationResult operationResult = securityService.ChangeUserBlockStatus(userId, true);

            switch (operationResult.WasSuccessful)
            {
                case true:
                    var user = operationResult.RequestedObject as User;
                    TempData["SuccessMessage"] = "Se bloqueó exitosamente el usuario con ID " + user.ID + ".";
                    break;
                case false:
                    TempData["ErrorMessage"] = "Ocurrió un problema al intentar bloquear el usuario. Contacte a soporte.";
                    break;
            }

            return RedirectToAction("List");
        }

        public ActionResult Unblock(int userId)
        {
            OperationResult operationResult = securityService.ChangeUserBlockStatus(userId, false);

            switch (operationResult.WasSuccessful)
            {
                case true:
                    var user = operationResult.RequestedObject as User;
                    TempData["SuccessMessage"] = "Se desbloqueó exitosamente el usuario con ID " + user.ID + ".";
                    break;
                case false:
                    TempData["ErrorMessage"] = "Ocurrió un problema al intentar desbloquear el usuario. Contacte a soporte.";
                    break;
            }

            return RedirectToAction("List");
        }
    }
}