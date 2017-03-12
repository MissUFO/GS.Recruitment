using GS.Recruitment.BusinessObjects.Enum;
using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class AdminUsersController : Controller
    {
        private UserBusinessService UserSrvc = new UserBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            List<User> model = UserSrvc.List();

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult Delete(List<Guid> IsSelected)
        {
            try
            {
                foreach (var id in IsSelected)
                    UserSrvc.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            return RedirectToAction("Index");

        }

        [AuthorizedUser]
        [HttpGet]
        public ActionResult AddEdit(Guid? id)
        {
            var user = new User();
            if (id.HasValue)
                user = UserSrvc.Get(id.Value);

            return View(user);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(User user, string Roles)
        {
            bool result = false;
            try
            {
                user.AddRole(new UserRole() { RoleType = Roles.ToEnum<RoleType>(), UserId = user.Id });
                result = UserSrvc.AddEdit(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(user);
        }

        [HttpPost]
        public ActionResult Delete(List<User> users)
        {
            bool result = false;
            try
            {
               var selectedUsers = users.Where(itm => itm.IsSelected = true);
                foreach(var itm in selectedUsers)
                    result = UserSrvc.Delete(itm.UserId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");
        }

    }
}