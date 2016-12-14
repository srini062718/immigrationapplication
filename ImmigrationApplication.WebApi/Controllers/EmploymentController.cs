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
    public class EmploymentController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public EmploymentController()
        {
            _uow = new UnitOfWork();
        }

        public EmploymentController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all Employment details
        public ActionResult Index()
        {
            IEnumerable<Employment> employ = _uow.RepositoryFor<Employment>().GetAll();
            return View(employ);
        }


        // Get details of one particular Employment
        public ActionResult Details(int id)
        {
            Employment employ = _uow.RepositoryFor<Employment>().Get(id);
            return View(employ);
        }

        [HttpGet]
        public ActionResult Add()
        {

            Employment employ = new Employment
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(employ);
        }

        [HttpPost]
        public ActionResult Add(Employment employment)
        {
            GenericRepository<Employment> ed = _uow.RepositoryFor<Employment>();
            ed.Add(employment);
            _uow.Complete();
            return RedirectToAction("Add", "Employment");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employment employ = _uow.RepositoryFor<Employment>().Get(id);
            return View(employ);
        }

        [HttpPost]
        public ActionResult Edit(Employment employ)
        {
            GenericRepository<Employment> ed = _uow.RepositoryFor<Employment>();
            ed.Update(employ);
            _uow.Complete();
            return RedirectToAction("Details", "Employment", new { id = employ.EmploymentID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employment employ = _uow.RepositoryFor<Employment>().Get(id);
            return View(employ);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            Employment employ = _uow.RepositoryFor<Employment>().Get(id);
            _uow.RepositoryFor<Employment>().Delete(employ.EmploymentID);
            _uow.Complete();
            return RedirectToAction("Index", "Employment");
        }
    }
}

