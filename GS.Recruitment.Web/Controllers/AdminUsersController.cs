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
        [HttpGet]
        public ActionResult AddEdit(Guid? id)
        {
            var user = new User();
            if (id.HasValue)
                user = UserSrvc.Get(id.Value);

            ViewBag.RoleTypes = RoleTypesSelectListItems();

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

        private List<SelectListItem> RoleTypesSelectListItems()
        {
            return Enum.GetNames(typeof(RoleType)).Select(c => new SelectListItem() { Text = c, Value = c }).ToList();
        }

    }
}