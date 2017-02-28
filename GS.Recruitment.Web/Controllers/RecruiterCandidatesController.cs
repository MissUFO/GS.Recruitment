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
    public class RecruiterCandidatesController : Controller
    {
        private ContactBusinessService ContactSrvc = new ContactBusinessService();
        private DictionaryBusinessService DictionarySrvc = new DictionaryBusinessService();

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
            var model = new Contact();
            if (id.HasValue)
                model = ContactSrvc.Get(id.Value);

            InitViewBags(model);

            return View(model);
        }

        [AuthorizedUser]
        [HttpPost]
        public ActionResult AddEdit(Contact model, IEnumerable<HttpPostedFileBase> attachments)
        {
            bool result = false;
            try
            {
                foreach (var file in attachments)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        //file.SaveAs(Path.Combine(Server.MapPath("/uploads"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                    }
                }

                result = ContactSrvc.AddEdit(model);
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

        private void InitViewBags(Contact model)
        {
            ViewBag.Cities = CitiesSelectListItems(model.CityId);
            ViewBag.Countries = CountriesSelectListItems(model.CountryId);
            ViewBag.JobTitles = JobTitlesSelectListItems(null);
            ViewBag.Industries = IndustriesSelectListItems(null);
            ViewBag.Skills = SkillsSelectListItems(null);
        }

        private List<SelectListItem> CitiesSelectListItems(Guid? selectedId)
        {
            var list = DictionarySrvc.List(Dictionaries.Cities.ToString());

            return list.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedId.HasValue && itm.Id == selectedId.Value) }).ToList();
        }

        private List<SelectListItem> CountriesSelectListItems(Guid? selectedId)
        {
            var list = DictionarySrvc.List(Dictionaries.Countries.ToString());

            return list.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedId.HasValue && itm.Id == selectedId.Value) }).ToList();
        }

        private List<SelectListItem> JobTitlesSelectListItems(Guid? selectedId)
        {
            var list = DictionarySrvc.List(Dictionaries.JobTitles.ToString());

            return list.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedId.HasValue && itm.Id == selectedId.Value) }).ToList();
        }

        private List<SelectListItem> IndustriesSelectListItems(Guid? selectedId)
        {
            var list = DictionarySrvc.List(Dictionaries.Industries.ToString());

            return list.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedId.HasValue && itm.Id == selectedId.Value) }).ToList();
        }

        private List<SelectListItem> SkillsSelectListItems(Guid? selectedId)
        {
            var list = DictionarySrvc.List(Dictionaries.Skills.ToString());

            return list.Select(itm => new SelectListItem() { Text = itm.Name, Value = itm.Id.ToString(), Selected = (selectedId.HasValue && itm.Id == selectedId.Value) }).ToList();
        }

    }
}