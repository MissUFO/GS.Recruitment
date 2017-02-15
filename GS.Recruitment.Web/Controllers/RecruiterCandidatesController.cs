using GS.Recruitment.BusinessObjects.Implementation;
using GS.Recruitment.BusinessServices.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Recruitment.Web.Controllers
{
    public class RecruiterCandidatesController : Controller
    {
        private ContactBusinessService ContactSrvc = new ContactBusinessService();

        [AuthorizedUser]
        public ActionResult Index()
        {
            List<Contact> model = ContactSrvc.ListCandidates();

            return View(model);
        }

        [AuthorizedUser]
        [HttpGet]
        public ActionResult AddEdit(Guid? id)
        {
            var contact = new Contact();
            if (id.HasValue)
                contact = ContactSrvc.Get(id.Value);

            return View(contact);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Contact contact, string Roles)
        {
            bool result = false;
            try
            {
                result = ContactSrvc.AddEdit(contact);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(contact);
        }

    }
}