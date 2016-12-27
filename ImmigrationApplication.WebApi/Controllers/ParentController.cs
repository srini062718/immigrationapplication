using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class ParentController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public ParentController()
        {
            _uow = new UnitOfWork();
        }
        // GET: Parent
        public ActionResult Index()
        {
           var parents =  _uow.RepositoryFor<Parent>().GetAll();
            return View(parents);
        }

        // get by id
        public ActionResult Details(int id)
        {
            var parent = _uow.RepositoryFor<Parent>().Get(id);
            return View(parent);
        }

       // add a new 
        [HttpGet]
        public ActionResult Create()
        {
            Parent parent = new Parent
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(parent);
        }

        [HttpPost]
        public ActionResult Create(Parent parent)
        {

            _uow.RepositoryFor<Parent>().Add(parent);
            _uow.Complete();
            return RedirectToAction("Index", "Parent");
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var parent = _uow.RepositoryFor<Parent>().Get(id);
            return View(parent);
        }

        [HttpPost]
        public ActionResult Edit(Parent detail)
        {
            _uow.RepositoryFor<Parent>().Update(detail);
            _uow.Complete();
            return RedirectToAction("Details", "Parent", new { id = detail.PersonID });
        }


        // delete a detail
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var parent = _uow.RepositoryFor<OtherDetail>().Get(id);
            return View(parent);
        }

        [HttpPost]
        public ActionResult Delete(Parent parent)
        {
            _uow.RepositoryFor<Parent>().Delete(parent.ParentID);
            _uow.Complete();
            return RedirectToAction("Index", "Parent");
        }
    }
}