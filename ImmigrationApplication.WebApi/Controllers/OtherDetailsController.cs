using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class OtherDetailsController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public OtherDetailsController()
        {
            _uow = new UnitOfWork();
        }

        // GET: OtherDetails
        public ActionResult Index()
        {
          var details =  _uow.RepositoryFor<OtherDetail>().GetAll();
            return View(details);
        }


        // get: single person detail

        public ActionResult Details(int id)
        {
           var detail =  _uow.RepositoryFor<OtherDetail>().Get(id);
            return View(detail);
        }

        //  add a new detail
        [HttpGet]
        public ActionResult Add()
        {
            var detail = new OtherDetail
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(detail);
        }

        [HttpPost]
        public ActionResult Add(OtherDetail detail)
        {
           _uow.RepositoryFor<OtherDetail>().Add(detail);
            _uow.Complete();
            return RedirectToAction("Add", "OtherDetails");
        }


        // edit a detail
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var detail = _uow.RepositoryFor<OtherDetail>().Get(id);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(OtherDetail detail)
        {
           _uow.RepositoryFor<OtherDetail>().Update(detail); 
            _uow.Complete();
            return RedirectToAction("Details", "OtherDetails", new { id = detail.PersonID});
        }


        // delete a detail
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var detail = _uow.RepositoryFor<OtherDetail>().Get(id);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Delete(OtherDetail detail)
        {
            _uow.RepositoryFor<OtherDetail>().Delete(detail.OtherDetailsID);
            _uow.Complete();
            return RedirectToAction("Index", "OtherDetails");
        }
    }
}