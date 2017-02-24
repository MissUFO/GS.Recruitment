using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System.Linq;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class RecruiterDashboardController : Controller
    {
        private DashboardBusinessService DashboardSrvc = new DashboardBusinessService();
        private AssignmentBusinessService AssignmentsSrvc = new AssignmentBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            var userId = (this.User as UserCustomPrincipal).UserId;

            var model = DashboardSrvc.Get_Recruiter(userId);
            ViewBag.MyAssignments = AssignmentsSrvc.ListUserTo(userId).Where(itm => itm.AssignmentStatus == AssignmentStatus.New || itm.AssignmentStatus == AssignmentStatus.InProcess).OrderByDescending(itm => itm.CreatedOn);

            return View(model);
        }

    }
}