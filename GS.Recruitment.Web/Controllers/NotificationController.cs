using GS.Recruitment.BusinessObjects.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class NotificationController : Controller
    {
        // GET: User assignments
        [ChildActionOnly]
        public PartialViewResult UserAssignments()
        {
            var model = new List<Notification>();

            return PartialView(model);
        }

        // GET: User Tasks
        [ChildActionOnly]
        public PartialViewResult UserTasks()
        {
            var model = new List<Notification>();

            return PartialView(model);
        }
    }
}