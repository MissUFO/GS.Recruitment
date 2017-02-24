using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GS.Recruitment.Web
{
    public class AuthorizedUserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            
            UserCustomPrincipal principal = new UserCustomPrincipal(System.Threading.Thread.CurrentPrincipal.Identity);
            if (principal == null || principal.UserId == Guid.Empty)
            {
                FormsAuthentication.SignOut();

                filterContext.Result = new RedirectResult("~/account/login");
                return;
            }

            //var user = HttpContext.Current.User as UserCustomPrincipal;
            //if (user != null)
            //{
                string pagePath = HttpContext.Current.Request.Path.ToLower();

                if (pagePath.Contains("/home") || pagePath.Contains("/account"))
                    return;

                if (principal.IsInRole(RoleType.Administrator))
                {
                    if (false == pagePath.Contains("/admin"))
                    {
                        //not authorised to view the page
                        filterContext.Result = new RedirectResult("~/");
                        return;
                    }
                }
                if (principal.IsInRole(RoleType.Recruiter))
                {
                    if (false == pagePath.Contains("/recruiter"))
                    {
                        //not authorised to view the page
                        filterContext.Result = new RedirectResult("~/");
                        return;
                    }
                }
            //}
        }
    }
}