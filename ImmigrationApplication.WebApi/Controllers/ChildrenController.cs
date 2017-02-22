﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.DataAccess.Repositories;
using ImmigrationApplication.Model;
using System.Linq;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class ChildrenController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public ChildrenController()
        {
            _uow = new UnitOfWork();
        }

        // GET: list of all Children details
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personId = encryptdecrypt.DecryptToBase64(personid);
            var children = _uow.RepositoryFor<Child>().GetAll();
            var enumerable = children as Child[] ?? children.ToArray();
            var childlist = enumerable.Where(x=>x.PersonID == personId).ToList();
            if (childlist.Count == 0)
            {
                return RedirectToAction("Create", "Children", new {personid = personId});
            }
            return View(enumerable.Where(x=>x.PersonID == personId));
        }

        // Get details of one particular Children
        public ActionResult Details(string childrenid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var childid = encryptdecrypt.DecryptToBase64(childrenid);
            var child = _uow.RepositoryFor<Child>().GetAll();
            return View(child.SingleOrDefault(x=>x.ChildrenID == childid));
        }

        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            Child c;
            if (personid > 0)
            {
                c = new Child
                {
                    PersonID = personid
                };

            }
            else
            {
                 c = new Child
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
           
            return View(c);
        }

        [HttpPost]
        public ActionResult Create(Child children)
        {
            if (!ModelState.IsValid) return View(children);
            var ed = _uow.RepositoryFor<Child>();
            ed.Add(children);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var personId = encdyc.EncryptToBase64(children.PersonID);
            return RedirectToAction("Index", "Children", new {personid = personId});
        }

        [HttpGet]
        public ActionResult Edit(string childrenid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var childid = encryptdecrypt.DecryptToBase64(childrenid);
            var child = _uow.RepositoryFor<Child>().GetAll();
            return View(child.SingleOrDefault(x=>x.ChildrenID == childid));
        }

        [HttpPost]
        public ActionResult Edit(Child child)
        {
             if (!ModelState.IsValid) return View(child);
             var ed = _uow.RepositoryFor<Child>();
             ed.Update(child);
            _uow.Complete();
             var encdyc = new EncryptAndDecrypt();
             var personId = encdyc.EncryptToBase64(child.PersonID);
             return RedirectToAction("Index", "Children", new { personid = personId });
        }

        [HttpGet]
        public ActionResult Delete(int personid)
        {
            var child = _uow.RepositoryFor<Child>().GetAll();
            return View(child.FirstOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            Child child = _uow.RepositoryFor<Child>().Get(id);
            _uow.RepositoryFor<Child>().Delete(child.ChildrenID);
            _uow.Complete();
            return RedirectToAction("Index", "Children");
        }
    }
}


