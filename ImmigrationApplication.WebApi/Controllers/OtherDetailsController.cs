﻿using System;
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

        private readonly UnitOfWork _uow;

        public OtherDetailsController()
        {
            _uow = new UnitOfWork();
        }

        // GET: OtherDetails
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var details =  _uow.RepositoryFor<OtherDetail>().GetAll();
            var enumerable = details as OtherDetail[] ?? details.ToArray();
            var otherdetaillist = enumerable.Where(x => x.PersonID == id).ToList();
            if (otherdetaillist.Count == 0)
            {
                return RedirectToAction("Create", "OtherDetails", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID==id));
        }


        // get: single person detail

        public ActionResult Details(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            var detail =  _uow.RepositoryFor<OtherDetail>().Get(personid);
            return View(detail);
        }

        //  add a new detail
        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            OtherDetail od;
            if (personid > 0)
            {
                od = new OtherDetail
                {
                    PersonID = personid
                };
            }
            else
            {
             od = new OtherDetail
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
            
            return View(od);
        }

        [HttpPost]
        public ActionResult Create(OtherDetail detail)
        {
            if (!ModelState.IsValid) return View();
            var od = _uow.RepositoryFor<OtherDetail>();
            od.Add(detail);
            _uow.Complete();
            return RedirectToAction("Index", "OtherDetails", new { personid = detail.PersonID });
        }


        // edit a detail
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            var detail = _uow.RepositoryFor<OtherDetail>().Get(personid);
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
            return RedirectToAction("Index", "OtherDetails" , new {personid = detail.PersonID});
        }
    }
}