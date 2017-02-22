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
        public ActionResult Details(string employmentid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var employid = encryptdecrypt.DecryptToBase64(employmentid);
            var employ = _uow.RepositoryFor<Employment>().GetAll();
            return View(employ.SingleOrDefault(x => x.EmploymentID == employid));
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
                    PersonID = Convert.ToInt32(TempData["pid"])
                };

            }
            return View(employ);
        }

        [HttpPost]
        public ActionResult Create(Employment employment)
        {
            if (!ModelState.IsValid) return View(employment);
            var ed = _uow.RepositoryFor<Employment>();
            ed.Add(employment);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(employment.PersonID);
            return RedirectToAction("Index", "Employment", new {personid = pid});
        }

        [HttpGet]
        public ActionResult Edit(string employmentid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var employid = encryptdecrypt.DecryptToBase64(employmentid);
            var employ = _uow.RepositoryFor<Employment>().GetAll();
            return View(employ.SingleOrDefault(x=>x.EmploymentID == employid));
        }

        [HttpPost]
        public ActionResult Edit(Employment employ)
        {
            if (!ModelState.IsValid) return View(employ);
            var ed = _uow.RepositoryFor<Employment>();
            ed.Update(employ);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var personId = encdyc.EncryptToBase64(employ.PersonID);
            return RedirectToAction("Index", "Employment", new { personid = personId });
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

