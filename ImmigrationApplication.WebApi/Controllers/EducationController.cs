using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.DataAccess.Repositories;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class EducationController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public EducationController()
        {
            _uow = new UnitOfWork();
        }

        // GET: list of all Education details
        public ActionResult Index(int personid)
        {
            var education = _uow.RepositoryFor<Education>().GetAll();
            var enumerable = education as Education[] ?? education.ToArray();
            var educationlist = enumerable.Where(x => x.PersonID == personid).ToList();
            if (educationlist.Count == 0)
            {
                return RedirectToAction("Create", "Education", new {personId = personid});
            }
            return View(enumerable.Where(x => x.PersonID == personid));
        }


        // Get details of one particular education
        public ActionResult Details(int id)
        {
          var education =   _uow.RepositoryFor<Education>().Get(id);
            return View(education);
        }

        [HttpGet]
        public ActionResult Create(int personId)
        {

            if (personId > 0)
            {
                var education = new Education
                {
                    PersonID = personId
                };
                return View(education);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<Education>();
            ed.Add(education);
            _uow.Complete();
            return RedirectToAction("Index", "Education",new {personid = education.PersonID});
        }

        [HttpGet]
        public ActionResult Edit(int personid)
        {
          var education =  _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost]
        public ActionResult Edit(Education education)
        {
         var ed = _uow.RepositoryFor<Education>();
            ed.Update(education);
            _uow.Complete();
            return RedirectToAction("Details", "Education", new {id = education.EducationID});
        }

        [HttpGet]
        public ActionResult Delete(int personid)
        {
           var education = _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            var education = _uow.RepositoryFor<Education>().Get(id);
            _uow.RepositoryFor<Education>().Delete(education.EducationID);
            _uow.Complete();
            return RedirectToAction("Index", "Education", new {personid = education.PersonID});
        }
    }
}