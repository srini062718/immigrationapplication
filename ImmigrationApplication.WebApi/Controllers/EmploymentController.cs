﻿using System;
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
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var employ = _uow.RepositoryFor<Employment>().GetAll();
            var enumerable = employ as Employment[] ?? employ.ToArray();
            var employlist = enumerable.Where(x => x.PersonID == id).ToList();
            if (employlist.Count == 0)
            {
                return RedirectToAction("Create", "Employment", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID==id));
        }



        // Get details of one particular Employment
        public ActionResult Details(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            var employ = _uow.RepositoryFor<Employment>().Get(personid);
            return View(employ);
        }

        [HttpGet]
        public ActionResult Create(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var pid = encryptdecrypt.DecryptToBase64(personid);
            Employment employ;
            if (pid > 0)
            {
              employ = new Employment
                {
                    PersonID = pid
              };
            }
            else
            {
                employ = new Employment
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };

            }
            return View(employ);
        }

        [HttpPost]
        public ActionResult Create(Employment employment)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<Employment>();
            ed.Add(employment);
            _uow.Complete();
            return RedirectToAction("Index", "Employment", new {personid = employment.PersonID});
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            var employ = _uow.RepositoryFor<Employment>().GetAll();
            return View(employ.SingleOrDefault(x=>x.PersonID==personid));
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

