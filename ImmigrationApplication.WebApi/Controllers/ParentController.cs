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
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var parents =  _uow.RepositoryFor<Parent>().GetAll();
            var enumerable = parents as Parent[] ?? parents.ToArray();
            var parentlist = enumerable.Where(x => x.PersonID == id).ToList();
            if (parentlist.Count == 0)
            {
                return RedirectToAction("Create", "Parent", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID == id));
        }

        // get by id
        public ActionResult Details(string parentid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var pareid = encryptdecrypt.DecryptToBase64(parentid);
            var parent = _uow.RepositoryFor<Parent>().GetAll();
            return View(parent.SingleOrDefault(x => x.ParentID == pareid));
        }

       // add a new 
        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            Parent parent;
            if (personid > 0)
            {
                parent = new Parent
                {
                    PersonID = personid
                };
            }
            else
            {
                parent = new Parent
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
       
            return View(parent);
        }

        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            if (!ModelState.IsValid) return View(parent);
            _uow.RepositoryFor<Parent>().Add(parent);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(parent.PersonID);
            return RedirectToAction("Index", "Parent", new { personid = pid });
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(string parentid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var pareid = encryptdecrypt.DecryptToBase64(parentid);
            var parent = _uow.RepositoryFor<Parent>().GetAll();
            return View(parent.SingleOrDefault(x => x.ParentID == pareid));
        }

        [HttpPost]
        public ActionResult Edit(Parent parent)
        {
            if (!ModelState.IsValid) return View(parent);
            _uow.RepositoryFor<Parent>().Update(parent);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(parent.PersonID);
            return RedirectToAction("Index", "Parent", new { personid = pid });
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