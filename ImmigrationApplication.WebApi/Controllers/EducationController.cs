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
    public class EducationController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public EducationController()
        {
            _uow = new UnitOfWork();
        }

        // GET: list of all Education details
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var education = _uow.RepositoryFor<Education>().GetAll();
            var enumerable = education as Education[] ?? education.ToArray();
            var educationlist = enumerable.Where(x => x.PersonID == id).ToList();
            if (educationlist.Count == 0)
            {
                return RedirectToAction("Create", "Education", new {personId = personid});
            }
            return View(enumerable.Where(x => x.PersonID == id));
        }


        // Get details of one particular education
        public ActionResult Details(string id)
        {
            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
            int personid = encdyc.DecryptToBase64(id);
            var education = _uow.RepositoryFor<Education>().Get(personid);
            return View(education);
        }

        [HttpGet]
        public ActionResult Create(string personId)
        {

            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
            int personid =   encdyc.DecryptToBase64(personId);
            
            if (personid > 0)
            {
                var education = new Education
                {
                    PersonID = personid
                };
                return View(education);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<Education>();
            ed.Add(education);
            _uow.Complete();
            return RedirectToAction("Index", "Education",new {personid = education.PersonID});
        }

        [HttpGet]
        public ActionResult Edit(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var education =  _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=>x.PersonID== id));


        }

        [HttpPost]
        public ActionResult Edit(Education education)
        {
         var ed = _uow.RepositoryFor<Education>();
            ed.Update(education);
            _uow.Complete();
            return RedirectToAction("Details", "Education", new {id = education.EducationID});
        }

        [HttpGet]
        public ActionResult Delete(int personid)
        {
           var education = _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            var education = _uow.RepositoryFor<Education>().Get(id);
            _uow.RepositoryFor<Education>().Delete(education.EducationID);
            _uow.Complete();
            return RedirectToAction("Index", "Education", new {personid = education.PersonID});
        }
    }
}