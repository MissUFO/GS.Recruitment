using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private DashboardBusinessService DashboardSrvc = new DashboardBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            var model = DashboardSrvc.Get_Admin((this.User as UserCustomPrincipal).UserId);

            return View(model);
        }
    }
}