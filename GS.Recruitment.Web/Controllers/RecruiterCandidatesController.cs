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
        private ContactBusinessService contactSrvc = new ContactBusinessService();
        private DictionaryBusinessService dictionarySrvc = new DictionaryBusinessService();

        public static List<DictionaryItem> citiesItems{get;set;}
        public static List<DictionaryItem> countriesItems { get; set; }
        public static List<DictionaryItem> jobTitlesItems { get; set; }
        public static List<DictionaryItem> inductriesItems { get; set; }
        public static List<DictionaryItem> companiesItems { get; set; }
        public static List<DictionaryItem> skillsItems { get; set; }

        [AuthorizedUser]
        public ActionResult Index()
        {
            List<Contact> model = contactSrvc.ListCandidates();

            return View(model);
        }

        [AuthorizedUser]
        [HttpGet]
        public ActionResult AddEdit(Guid? id)
        {
            var model = new Contact();
            if (id.HasValue)
                model = contactSrvc.Get(id.Value);
            
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

                result = contactSrvc.AddEdit(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            if (result)
                return RedirectToAction("Index");
            else
                return View(model);
        }

        [HttpPost]
        public JsonResult CitiesSearch(string term)
        {
            if(citiesItems == null || citiesItems.Count == 0)
                citiesItems = dictionarySrvc.List(Dictionaries.Cities.ToString());

            var result = (from r in citiesItems
                          where r.Name.ToLower().Contains(term.ToLower())
                          select new
                          {
                              text = r.Name
                          }
                         ).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CountriesSearch(string term)
        {
            if (countriesItems == null || countriesItems.Count == 0)
                countriesItems = dictionarySrvc.List(Dictionaries.Countries.ToString());

            var result = (from r in countriesItems
                          where r.Name.ToLower().Contains(term.ToLower())
                          select new
                          {
                              text = r.Name
                          }
                         ).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult JobTitlesSearch(string term)
        {
            if (jobTitlesItems == null || jobTitlesItems.Count == 0)
                jobTitlesItems = dictionarySrvc.List(Dictionaries.JobTitles.ToString());

            var result = (from r in jobTitlesItems
                          where r.Name.ToLower().Contains(term.ToLower())
                          select new
                          {
                              text = r.Name
                          }
                         ).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IndustriesSearch(string term)
        {
            if (inductriesItems == null || inductriesItems.Count == 0)
                inductriesItems = dictionarySrvc.List(Dictionaries.Industries.ToString());

            var result = (from r in inductriesItems
                          where r.Name.ToLower().Contains(term.ToLower())
                          select new
                          {
                              text = r.Name
                          }
                         ).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SkillsSearch(string term)
        {
            if (skillsItems == null || skillsItems.Count == 0)
                skillsItems = dictionarySrvc.List(Dictionaries.Skills.ToString());

            var result = (from r in skillsItems
                          where r.Name.ToLower().Contains(term.ToLower())
                          select new
                          {
                              text = r.Name
                          }
                         ).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}