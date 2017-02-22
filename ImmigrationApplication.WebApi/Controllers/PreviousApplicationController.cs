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
            return View(enumerable.Where(x=>x.PersonID == id));
        }

        // get by id
        public ActionResult Details(string previousappid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var previousid = encryptdecrypt.DecryptToBase64(previousappid);
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().GetAll();
            return View(previousapplication.SingleOrDefault(x => x.PreviousApplicationID == previousid));
        }

        // add a new 
        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            PreviousApplication previousapplication;
            if (personid > 0)
            {
                previousapplication = new PreviousApplication
                {
                    PersonID = personid
                };
            }
            else
            {
                previousapplication = new PreviousApplication
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
           
            return View(previousapplication);
        }

        [HttpPost]
        public ActionResult Create(PreviousApplication previousapplication)
        {
            if (!ModelState.IsValid) return View(previousapplication);
            _uow.RepositoryFor<PreviousApplication>().Add(previousapplication);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(previousapplication.PersonID);
            return RedirectToAction("Index", "PreviousApplication", new { personid = pid });
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(string previousappid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var previousid = encryptdecrypt.DecryptToBase64(previousappid);
            var previousapplication = _uow.RepositoryFor<PreviousApplication>().GetAll();
            return View(previousapplication.SingleOrDefault(x => x.PreviousApplicationID == previousid));
        }

        [HttpPost]
        public ActionResult Edit(PreviousApplication previousapplication)
        {
            if (!ModelState.IsValid) return View(previousapplication);
            _uow.RepositoryFor<PreviousApplication>().Update(previousapplication);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(previousapplication.PersonID);
            return RedirectToAction("Index", "PreviousApplication", new { personid = pid });
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