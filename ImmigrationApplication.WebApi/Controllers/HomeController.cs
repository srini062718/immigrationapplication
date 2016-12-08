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
    }
}
