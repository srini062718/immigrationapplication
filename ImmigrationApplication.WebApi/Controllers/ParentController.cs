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
            return View(enumerable.Where(x=>x.PersonID==id));
        }

        // get by id
        public ActionResult Details(int id)
        {
            var parent = _uow.RepositoryFor<Parent>().Get(id);
            return View(parent);
        }

       // add a new 
        [HttpGet]
        public ActionResult Create(int personId)
        {
            Parent parent;
            if (personId > 0)
            {
                parent = new Parent
                {
                    PersonID = personId
                };
            }
            else
            {
                parent = new Parent
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };
            }
       
            return View(parent);
        }

        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            if (!ModelState.IsValid) return View();
            _uow.RepositoryFor<Parent>().Add(parent);
            _uow.Complete();
            TempData.Add("id", parent.PersonID.ToString());
            return RedirectToAction("Index", "Parent", new { personid = parent.PersonID });
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