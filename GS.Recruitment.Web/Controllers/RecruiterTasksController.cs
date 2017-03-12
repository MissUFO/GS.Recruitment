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
        private UserBusinessService UsersSrvc = new UserBusinessService();
        private AssignmentBusinessService AssignmentsSrvc = new AssignmentBusinessService();

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
        [HttpPost]
        public ActionResult Delete(List<Guid> IsSelected)
        {
            try
            {
                foreach (var id in IsSelected)
                    TasksSrvc.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            return RedirectToAction("Index");

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
            if (id.HasValue)
                model = TasksSrvc.Get(id.Value);

            InitCurrentUser(model);

            InitViewBags(model);

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Task model)
        {
            bool result = false;
            try
            {
                result = TasksSrvc.AddEdit(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
            {
                InitViewBags(model);
                return View(model);
            }
        }


        private void InitCurrentUser(Task model)
        {
            if (model.UserFromId == Guid.Empty)
            {
                var principal = this.User as UserCustomPrincipal;
                if (principal != null)
                {
                    model.UserFromId = principal.UserId;
                    model.UserFromLogin = principal.Login;
                    model.CreatedBy = principal.UserId;
                    model.CreatedOn = DateTime.Now;
                }
            }
        }

        private void InitViewBags(Task model)
        {
            ViewBag.Users = UsersSelectListItems(model.UserToId);
            ViewBag.Assignments = AssignmentsSrvc.ListTask(model.Id);
        }

        private List<SelectListItem> UsersSelectListItems(Guid? selectedUserId)
        {
            var recruiters = UsersSrvc.ListRecruiters();

            return recruiters.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.UserId.ToString(), Selected=(selectedUserId.HasValue && itm.UserId== selectedUserId.Value) }).ToList();
        }


    }
}