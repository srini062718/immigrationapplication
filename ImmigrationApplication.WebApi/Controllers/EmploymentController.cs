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

        public EmploymentController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all Employment details
        public ActionResult Index(int personid)
        {
            var employ = _uow.RepositoryFor<Employment>().GetAll();
            var enumerable = employ as Employment[] ?? employ.ToArray();
            var employlist = enumerable.Where(x => x.PersonID == personid).ToList();
            if (employlist.Count == 0)
            {
                return RedirectToAction("Create", "Employment", new { personid });
            }
            return View(enumerable.Where(x=>x.PersonID==personid));
        }


        // Get details of one particular Employment
        public ActionResult Details(int id)
        {
            var employ = _uow.RepositoryFor<Employment>().Get(id);
            return View(employ);
        }

        [HttpGet]
        public ActionResult Create()
        {

            Employment employ = new Employment
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(employ);
        }

        [HttpPost]
        public ActionResult Create(Employment employment)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<Employment>();
            ed.Add(employment);
            _uow.Complete();
            TempData.Add("id", employment.PersonID.ToString());
            return RedirectToAction("Create", "FormerSpouse");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employment employ = _uow.RepositoryFor<Employment>().Get(id);
            return View(employ);
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

