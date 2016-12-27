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
    public class LastArrivalDetailController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public LastArrivalDetailController()
        {
            _uow = new UnitOfWork();
        }

        public LastArrivalDetailController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all LastArrivalDetail details
        public ActionResult Index()
        {
            IEnumerable<LastArrivalDetail> lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().GetAll();
            return View(lastarrivaldetail);
        }

        // Get details of one particular LastArrivalDetail
        public ActionResult Details(int id)
        {
            LastArrivalDetail lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpGet]
        public ActionResult Create()
        {

            LastArrivalDetail lastarrivaldetail = new LastArrivalDetail
            {
                PersonID = Convert.ToInt32(TempData["id"])
            };
            return View(lastarrivaldetail);
        }

        [HttpPost]
        public ActionResult Create(LastArrivalDetail lastArrivalDetail)
        {
            GenericRepository<LastArrivalDetail> ed = _uow.RepositoryFor<LastArrivalDetail>();
            ed.Add(lastArrivalDetail);
            _uow.Complete();
            return RedirectToAction("Add", "LastArrivalDetail");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LastArrivalDetail lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpPost]
        public ActionResult Edit(LastArrivalDetail lastarrivaldetail)
        {
            GenericRepository<LastArrivalDetail> ed = _uow.RepositoryFor<LastArrivalDetail>();
            ed.Update(lastarrivaldetail);
            _uow.Complete();
            return RedirectToAction("Details", "LastArrivalDetail", new { id = lastarrivaldetail.LastArrivalDetailsID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LastArrivalDetail lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            LastArrivalDetail lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            _uow.RepositoryFor<LastArrivalDetail>().Delete(lastarrivaldetail.LastArrivalDetailsID);
            _uow.Complete();
            return RedirectToAction("Index", "LastArrivalDetail");
        }
    }
}


