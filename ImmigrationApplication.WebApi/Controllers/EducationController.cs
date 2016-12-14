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

        public EducationController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all Education details
        public ActionResult Index()
        {
           IEnumerable<Education> education =  _uow.RepositoryFor<Education>().GetAll();
            return View(education);
        }


        // Get details of one particular education
        public ActionResult Details(int id)
        {
          Education education =   _uow.RepositoryFor<Education>().Get(id);
            return View(education);
        }

        [HttpGet]
        public ActionResult Add()
        {
          
            Education education = new Education
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(education);
        }

        [HttpPost]
        public ActionResult Add(Education education)
        {
          GenericRepository<Education> ed =  _uow.RepositoryFor<Education>();
            ed.Add(education);
            _uow.Complete();
            return RedirectToAction("Add","Education");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
          Education education =  _uow.RepositoryFor<Education>().Get(id);
            return View(education);
        }

        [HttpPost]
        public ActionResult Edit(Education education)
        {
         GenericRepository<Education> ed = _uow.RepositoryFor<Education>();
            ed.Update(education);
            _uow.Complete();
            return RedirectToAction("Details", "Education", new {id = education.EducationID});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           Education education = _uow.RepositoryFor<Education>().Get(id);
            return View(education);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            Education education = _uow.RepositoryFor<Education>().Get(id);
            _uow.RepositoryFor<Education>().Delete(education.EducationID);
            _uow.Complete();
            return RedirectToAction("Index", "Education");
        }
    }
}