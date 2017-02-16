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
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().GetAll();
            var enumerable = previousapplication as PreviousApplication[] ?? previousapplication.ToArray();
            var previouslist = enumerable.Where(x => x.PersonID == id).ToList();
            if (previouslist.Count == 0)
            {
                return RedirectToAction("Create", "PreviousApplication", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID==id));
        }

        // get by id
        public ActionResult Details(int id)
        {
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().Get(id);
            return View(previousapplication);
        }

        // add a new 
        [HttpGet]
        public ActionResult Create(int personId)
        {
            PreviousApplication previousapplication;
            if (personId > 0)
            {
                previousapplication = new PreviousApplication
                {
                    PersonID = personId
                };
            }
            else
            {
                previousapplication = new PreviousApplication
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };
            }
           
            return View(previousapplication);
        }

        [HttpPost]
        public ActionResult Create(PreviousApplication previousapplication)
        {
            if (!ModelState.IsValid) return View();
            _uow.RepositoryFor<PreviousApplication>().Add(previousapplication);
            _uow.Complete();
            return RedirectToAction("Index", "PreviousApplication", new { personid = previousapplication.PersonID });
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
            if (!ModelState.IsValid) return View();
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