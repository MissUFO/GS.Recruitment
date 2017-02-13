using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private UserBusinessService UserSrvc = new UserBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
           
            return View();
        }
    }
}