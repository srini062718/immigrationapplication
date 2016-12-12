using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;
using System.Web.UI.WebControls;
using ImmigrationApplication.DataAccess.Repositories;

namespace WebApplication3.Controllers
{
    public class PersonController : Controller
    {

        private UnitOfWork _uow = null;

        public Person con { get; private set; }

        public PersonController()
        {
            _uow = new UnitOfWork();
        }

        public PersonController(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "List of Customers";
            GenericRepository<Person> p = _uow.RepositoryFor<Person>();
            IEnumerable<Person> P =   p.GetAll();
            return View(P);
        }


        public ActionResult Details(int id)
        {
            try
            {
                GenericRepository<Person> p = _uow.RepositoryFor<Person>();
                con = p.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(con);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            GenericRepository<Person> p = _uow.RepositoryFor<Person>();
            con = p.Get(id);
            return View(con);
        }

        [HttpPost]
        public ActionResult Edit(Person P)
        {
            GenericRepository<Person> p = _uow.RepositoryFor<Person>();
            p.Update(P);
            _uow.Complete();
            con = p.Get(P.PersonID);
            return RedirectToAction("Details", "Person", new { id = P.PersonID });
        }

        [HttpPost]
        public ActionResult Add(Person P)
        { 

         GenericRepository<Person> p = _uow.RepositoryFor<Person>();
        p.Add(P);
            _uow.Complete();
            TempData.Add("id", P.PersonID.ToString());
            return RedirectToAction("Add", "Address");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person p = _uow.RepositoryFor<Person>().Get(id);
            _uow.RepositoryFor<Person>().Remove(p);
            _uow.Complete();
            return RedirectToAction("Index", "Person");
        }

        [HttpDelete]
        public ActionResult Delete(Person P)
        {
            Person p = _uow.RepositoryFor<Person>().Get(P.PersonID);
            return View(p);
        }
        
    }
}
