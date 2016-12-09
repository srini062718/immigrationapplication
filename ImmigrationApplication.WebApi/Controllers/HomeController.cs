using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;
using System.Web.UI.WebControls;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        private UnitOfWork _uow = null;

        public Person con { get; private set; }

        public HomeController()
        {
            _uow = new UnitOfWork();
        }

        public HomeController(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult GetPersonName(int id)
        {
            try
            {
                con = _uow.PersonRepository.GetById(id);
            }
            catch (Exception e)
            {
                // TO Do Exception handling
            }
            return View(con);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
          con=  _uow.PersonRepository.GetById(id);
            return View(con);
        }

        [HttpPost]
        public ActionResult Edit(Person P)
        {
            //  con =  _uow.PersonRepository.GetById(P.PersonID);

            //   con.Nationality = P.Nationality;
            //  _uow.Complete();
            _uow.PersonRepository.Update(P);
            _uow.Complete();
            con = _uow.PersonRepository.GetById(P.PersonID);
            return RedirectToAction("GetPersonName","Home", new { id = P.PersonID });
        }
    }
}
