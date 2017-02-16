using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class RecruiterAssignmentsController : Controller
    {
        private AssignmentBusinessService AssignmentSrvc = new AssignmentBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            List<Assignment> model = new List<Assignment>();

            var principal = this.User as UserCustomPrincipal;
            if (principal != null)
            {
                model = AssignmentSrvc.ListUserTo(principal.UserId);
            }

            return View(model);
        }

        [AuthorizedUser]
        public ActionResult View(Guid id)
        {
            Assignment model = AssignmentSrvc.Get(id);

            return View(model);
        }

        [AuthorizedUser]
        public ActionResult AddEdit(Guid? id)
        {
            Assignment model = new Assignment();
            if (id.HasValue)
                model = AssignmentSrvc.Get(id.Value);

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Assignment assignment)
        {
            bool result = false;
            try
            {
                result = AssignmentSrvc.AddEdit(assignment);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(assignment);
        }

    }
}