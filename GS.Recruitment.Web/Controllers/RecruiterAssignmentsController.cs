using GS.Recruitment.BusinessObjects.Enum;
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
        private UserBusinessService UsersSrvc = new UserBusinessService();
        private TaskBusinessService TasksSrvc = new TaskBusinessService();
        private ContactBusinessService ContactsSrvc = new ContactBusinessService();

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
        public ActionResult AddEdit(Guid? id, Guid? taskId)
        {
            Assignment model = new Assignment();

            if (taskId.HasValue)
            {
                model.TaskId = taskId.Value;
                model.Task = TasksSrvc.Get(model.TaskId);
            }

            if (id.HasValue && id.Value != Guid.Empty)
                model = AssignmentSrvc.Get(id.Value);

            InitCurrentUser(model);

            InitViewBags(model);

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Assignment model)
        {
            bool result = false;
            try
            {
                result = AssignmentSrvc.AddEdit(model);
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

        [AuthorizedUser]
        public ActionResult AssignContact(Guid? id)
        {
            return RedirectToAction("AddEdit", new { id = id.Value });
        }

        [AuthorizedUser]
        public ActionResult AssignAllContacts(Guid? id)
        {
            var contacts = ContactsSrvc.ListCandidates();

            foreach(var itm in contacts)
                AssignmentSrvc.AssignmentContact_AddEdit(new AssignmentContact()
                {
                    AssignmentId = id.Value,
                    ContactId = itm.Id
                });

            return RedirectToAction("AddEdit", new { id = id.Value });
        }

        private void InitCurrentUser(Assignment model)
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

        private void InitViewBags(Assignment model)
        {
            ViewBag.Users = UsersSelectListItems(model.UserToId);
            ViewBag.Tasks = TasksSelectListItems(model.TaskId);
        }

        private List<SelectListItem> TasksSelectListItems(Guid? selectedTaskId)
        {
            var tasks = TasksSrvc.List().Where(itm=> itm.TaskStatus != TaskStatus.Closed || itm.TaskStatus != TaskStatus.Completed);

            return tasks.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedTaskId.HasValue && itm.Id == selectedTaskId.Value) }).ToList();
        }

        private List<SelectListItem> UsersSelectListItems(Guid? selectedUserId)
        {
            var recruiters = UsersSrvc.ListRecruiters();

            return recruiters.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.UserId.ToString(), Selected = (selectedUserId.HasValue && itm.UserId == selectedUserId.Value) }).ToList();
        }

    }
}