using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class PreviousApplicationController : Controller
    {
        private readonly UnitOfWork _uow = null;

        public PreviousApplicationController()
        {
            _uow = new UnitOfWork();
        }
        // GET: Parent
        public ActionResult Index(int personid)
        {
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().GetAll();
            return View(previousapplication.Where(x=>x.PersonID==personid));
        }

        // get by id
        public ActionResult Details(int id)
        {
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().Get(id);
            return View(previousapplication);
        }

        // add a new 
        [HttpGet]
        public ActionResult Create()
        {
            var previousapplication = new PreviousApplication
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(previousapplication);
        }

        [HttpPost]
        public ActionResult Create(PreviousApplication previousapplication)
        {

            _uow.RepositoryFor<PreviousApplication>().Add(previousapplication);
            _uow.Complete();
            TempData.Add("id", previousapplication.PersonID.ToString());
            return RedirectToAction("Create", "OtherDetails");
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().Get(id);
            return View(previousapplication);
        }

        [HttpPost]
        public ActionResult Edit(PreviousApplication previousapplication)
        {
            _uow.RepositoryFor<PreviousApplication>().Update(previousapplication);
            _uow.Complete();
            return RedirectToAction("Details", "PreviousApplication", new { id = previousapplication.PreviousApplicationID });
        }


        // delete a detail
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().Get(id);
            return View(previousapplication);
        }

        [HttpPost]
        public ActionResult Delete(PreviousApplication previousapplication)
        {
            _uow.RepositoryFor<PreviousApplication>().Delete(previousapplication.PreviousApplicationID);
            _uow.Complete();
            return RedirectToAction("Index", "PreviousApplication");
        }
    }
}