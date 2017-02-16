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
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().GetAll();
            var enumerable = lastarrivaldetail as LastArrivalDetail[] ?? lastarrivaldetail.ToArray();
            var arrivallist = enumerable.Where(x => x.PersonID == id).ToList();
            if (arrivallist.Count == 0)
            {
                return RedirectToAction("Create", "LastArrivalDetail", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID==id));
        }

        // Get details of one particular LastArrivalDetail
        public ActionResult Details(int id)
        {
            var lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpGet]
        public ActionResult Create(int personId)
        {
            LastArrivalDetail lad;
            if (personId > 0)
            {
                lad = new LastArrivalDetail
                {
                    PersonID = personId
                };
            }
            else
            {
                lad = new LastArrivalDetail
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };
            }
            return View(lad);
        }

        [HttpPost]
        public ActionResult Create(LastArrivalDetail lastArrivalDetail)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<LastArrivalDetail>();
            ed.Add(lastArrivalDetail);
            _uow.Complete();
            return RedirectToAction("Index", "LastArrivalDetail", new {personid = lastArrivalDetail.PersonID});
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpPost]
        public ActionResult Edit(LastArrivalDetail lastarrivaldetail)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<LastArrivalDetail>();
            ed.Update(lastarrivaldetail);
            _uow.Complete();
            return RedirectToAction("Details", "LastArrivalDetail", new { id = lastarrivaldetail.LastArrivalDetailsID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            return View(lastarrivaldetail);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            var lastarrivaldetail = _uow.RepositoryFor<LastArrivalDetail>().Get(id);
            _uow.RepositoryFor<LastArrivalDetail>().Delete(lastarrivaldetail.LastArrivalDetailsID);
            _uow.Complete();
            return RedirectToAction("Index", "LastArrivalDetail" , new { personid = id });
        }
    }
}


