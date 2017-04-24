using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Apolo.Web.ViewModels;
using System.Web.Security;
using Apolo.Core.Business;
using Apolo.Core.Business.Common;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Util;

namespace Apolo.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        SecurityService securityService = new SecurityService();

        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            OperationResult operationResult = securityService.GetUser(viewModel.Username);
            if(operationResult.RequestedObject != null)
            {
                User user = operationResult.RequestedObject as User;
                if(SecurityUtil.GenerateSaltedHash(viewModel.Password, user.Salt.ToString()) == user.Password)
                {
                    Session[Constants.SESSION_USER] = user;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.Username, true, 6000);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    if (!string.IsNullOrEmpty(returnUrl))
                        return RedirectToLocal(returnUrl);
                    else
                    {
                        switch(user.Role)
                        {
                            case Constants.Roles.ADMINISTRATOR: return RedirectToAction("Index", "Home", new { area = Constants.Areas.ADMINISTRATOR });
                            case Constants.Roles.THERAPIST: return RedirectToAction("Patients", "Home", new { area = Constants.Areas.THERAPIST });
                            case Constants.Roles.PATIENT: return RedirectToAction("Index", "Home", new { area = Constants.Areas.PATIENT });
                        }
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Contraseña incorrecta";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Usuario no encontrado";
            }

            return View(viewModel);
        }
        
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}