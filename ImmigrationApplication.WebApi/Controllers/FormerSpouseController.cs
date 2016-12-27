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
    public class FormerSpouseController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public FormerSpouseController()
        {
            _uow = new UnitOfWork();
        }

        public FormerSpouseController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all FormerSpouse details
        public ActionResult Index()
        {
            IEnumerable<FormerSpouse> formerspouse = _uow.RepositoryFor<FormerSpouse>().GetAll();
            return View(formerspouse);
        }


        // Get details of one particular FormerSpouse
        public ActionResult Details(int id)
        {
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            return View(formerspouse);
        }

        [HttpGet]
        public ActionResult Create()
        {

            var formerspouse = new FormerSpouse
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(formerspouse);
        }

        [HttpPost]
        public ActionResult Create(FormerSpouse formerSpouse)
        {
            var ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Add(formerSpouse);
            _uow.Complete();
            TempData.Add("id", formerSpouse.PersonID.ToString());
            return RedirectToAction("Create", "Children");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            return View(formerspouse);
        }

        [HttpPost]
        public ActionResult Edit(FormerSpouse formerspouse)
        {
            GenericRepository<FormerSpouse> ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Update(formerspouse);
            _uow.Complete();
            return RedirectToAction("Details", "FormerSpouse", new { id = formerspouse.FormerSpouseID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            return View(formerspouse);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            _uow.RepositoryFor<FormerSpouse>().Delete(formerspouse.FormerSpouseID);
            _uow.Complete();
            return RedirectToAction("Index", "FormerSpouse");
        }
    }
}


