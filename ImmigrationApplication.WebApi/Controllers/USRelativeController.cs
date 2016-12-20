using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class UsRelativeController : Controller
    {
        private readonly UnitOfWork _uow = null;

        public UsRelativeController()
        {
            _uow = new UnitOfWork();
        }
        // GET: Parent
        public ActionResult Index()
        {
            var usrelative = _uow.RepositoryFor<USRelative>().GetAll();
            return View(usrelative);
        }

        // get by id
        public ActionResult Details(int id)
        {
            var usrelative = _uow.RepositoryFor<USRelative>().Get(id);
            return View(usrelative);
        }

        // add a new 
        [HttpGet]
        public ActionResult Add()
        {
            USRelative usrelative = new USRelative
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(usrelative);
        }

        [HttpPost]
        public ActionResult Add(USRelative usrelative)
        {

            _uow.RepositoryFor<USRelative>().Add(usrelative);
            _uow.Complete();
            return RedirectToAction("Index", "USRelative");
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var usrelative = _uow.RepositoryFor<USRelative>().Get(id);
            return View(usrelative);
        }

        [HttpPost]
        public ActionResult Edit(USRelative usrelative)
        {
            _uow.RepositoryFor<USRelative>().Update(usrelative);
            _uow.Complete();
            return RedirectToAction("Details", "USRelative", new { id = usrelative.USRelativeID});
        }


        // delete a detail
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var usrelative = _uow.RepositoryFor<USRelative>().Get(id);
            return View(usrelative);
        }

        [HttpPost]
        public ActionResult Delete(USRelative usrelative)
        {
            _uow.RepositoryFor<USRelative>().Delete(usrelative.USRelativeID);
            _uow.Complete();
            return RedirectToAction("Index", "USRelative");
        }
    }
}