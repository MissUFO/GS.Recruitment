using System.Web;
using System.Web.Mvc;
using GS.Recruitment.Web.Models;
using GS.Recruitment.BusinessServices.Implementation;
using System.Web.Security;
using System;
using System.Linq;
using Newtonsoft.Json;
using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;

namespace GS.Recruitment.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        private UserBusinessService UserSrvc = new UserBusinessService();

        //
        // GET: /Account/index
        [AllowAnonymous]
        public ActionResult Index()
        {   
            return Login(string.Empty);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        { 
            ViewBag.ReturnUrl = returnUrl;

            if (Request.IsAuthenticated)
            {
                var principal = this.User as UserCustomPrincipal;
                if (principal != null)
                {
                    if (principal.IsInRole(RoleType.Administrator))
                        return RedirectToAction("Index", "AdminDashboard");
                    else
                        return RedirectToAction("Index", "RecruiterDashboard");
                }
            }

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = UserSrvc.Login(model.Email, model.Password);

                if (user != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddDays(30), false, JsonConvert.SerializeObject(user), FormsAuthentication.FormsCookiePath);
                    FormsAuthentication.SetAuthCookie(user.Name, false);

                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    authCookie.Value = FormsAuthentication.Encrypt(ticket); ;
                    Request.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, authCookie.Value));

                    if(user.Roles.Count(itm => itm.RoleType == RoleType.Administrator) > 0)
                        return RedirectToAction("Index", "AdminDashboard");
                    else
                        return RedirectToAction("Index", "RecruiterDashboard");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        //
        // Get: /Account/LogOff
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            // Delete the user details from cache.
            Session.Abandon();

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Edit
        [AuthorizedUser]
        public ActionResult Edit()
        {
            var model = new User();
            var principal = this.User as UserCustomPrincipal;
            if (principal != null)
            {
                model = UserSrvc.Get(principal.UserId);
            }

            return View(model);
        }
    }
}