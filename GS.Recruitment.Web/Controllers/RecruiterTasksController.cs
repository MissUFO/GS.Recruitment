using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class RecruiterTasksController : Controller
    {
        private TaskBusinessService TasksSrvc = new TaskBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            List<Task> model = new List<Task>();

            var principal = this.User as UserCustomPrincipal;
            if (principal != null)
            {
                model = TasksSrvc.ListUserTo(principal.UserId);
            }

            return View(model);
        }

        [AuthorizedUser]
        public ActionResult View(Guid id)
        {
            Task model = TasksSrvc.Get(id);

            return View(model);
        }

        [AuthorizedUser]
        public ActionResult AddEdit(Guid? id)
        {
            Task model = new Task();
            if(id.HasValue)
                model = TasksSrvc.Get(id.Value);

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Task task)
        {
            bool result = false;
            try
            {
                result = TasksSrvc.AddEdit(task);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(task);
        }

    }
}