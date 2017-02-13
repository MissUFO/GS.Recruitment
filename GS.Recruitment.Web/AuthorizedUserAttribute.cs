using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web
{
    public class AuthorizedUserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/account/login");
                return;
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/account/login");
                return;
            }

            UserCustomPrincipal principal = new UserCustomPrincipal(System.Threading.Thread.CurrentPrincipal.Identity);
            if (principal == null || principal.UserId == Guid.Empty)
            {
                filterContext.Result = new RedirectResult("~/account/login");
                return;
            }

            var user = HttpContext.Current.User as UserCustomPrincipal;
            if (user != null)
            {
                if (user.IsInRole(RoleType.Administrator) == false)
                {
                    if (false==HttpContext.Current.Request.Path.ToLower().Contains("/admin"))
                    {
                        filterContext.Result = new RedirectResult("~/");
                        return;
                    }
                }
            }
        }
    }
}