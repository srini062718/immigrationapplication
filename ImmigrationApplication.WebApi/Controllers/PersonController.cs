using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess.Repositories;

namespace ImmigrationApplication.WebApi.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly UnitOfWork _uow = null;

        public Person Con { get; private set; }

        public PersonController()
        {
            _uow = new UnitOfWork();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "List of Customers";
            GenericRepository<Person> p = _uow.RepositoryFor<Person>();
            IEnumerable<Person> per =   p.GetAll();
            if (User.IsInRole("Admin") != true)
            {
                per = per.Where(x => x.CreatedByName == User.Identity.Name);
            }
            return View(per);
        }

        public ActionResult Details(int id)
        {
            var p = _uow.RepositoryFor<Person>();
            Con = p.Get(id);
            return View(Con);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var p = _uow.RepositoryFor<Person>();
            Con = p.Get(id);
            return View(Con);
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            var person = _uow.RepositoryFor<Person>();
            person.Update(p);
            _uow.Complete();
            Con = person.Get(p.PersonID);
            return RedirectToAction("Details", "Person", new { id = p.PersonID });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Person p)
        {
            p.CreatedByName = User.Identity.Name;
            var person = _uow.RepositoryFor<Person>();
            person.Add(p);
            _uow.Complete();
            TempData.Add("id", p.PersonID.ToString());
            return RedirectToAction("Add", "Address");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var person = _uow.RepositoryFor<Person>().Get(id);
            return View(person);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
          var person =  _uow.RepositoryFor<Person>().Get(id);
            _uow.RepositoryFor<Person>().Delete(person.PersonID);
            _uow.Complete();
            return RedirectToAction("Index", "Person");
        }
    }
}
