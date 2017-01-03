using System;
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

        public ChildrenController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all Children details
        public ActionResult Index(int personid)
        {
            var children = _uow.RepositoryFor<Child>().GetAll();
            var enumerable = children as Child[] ?? children.ToArray();
            var childlist = enumerable.Where(x=>x.PersonID==personid).ToList();
            if (childlist.Count == 0)
            {
                return RedirectToAction("Create", "Children", new {personid});
            }
            return View(enumerable.Where(x=>x.PersonID==personid));
        }


        // Get details of one particular Children
        public ActionResult Details(int id)
        {
            var child = _uow.RepositoryFor<Child>().Get(id);
            return View(child);
        }

        [HttpGet]
        public ActionResult Create()
        {

            var child = new Child
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(child);
        }

        [HttpPost]
        public ActionResult Create(Child children)
        {
            var ed = _uow.RepositoryFor<Child>();
            ed.Add(children);
            _uow.Complete();
            TempData.Add("id", children.PersonID.ToString());
            return RedirectToAction("Create", "Parent");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Child child = _uow.RepositoryFor<Child>().Get(id);
            return View(child);
        }

        [HttpPost]
        public ActionResult Edit(Child child)
        {
            GenericRepository<Child> ed = _uow.RepositoryFor<Child>();
            ed.Update(child);
            _uow.Complete();
            return RedirectToAction("Details", "Children", new { id = child.ChildrenID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Child child = _uow.RepositoryFor<Child>().Get(id);
            return View(child);
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


