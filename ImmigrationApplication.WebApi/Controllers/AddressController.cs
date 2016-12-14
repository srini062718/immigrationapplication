using ImmigrationApplication.DataAccess;
using ImmigrationApplication.DataAccess.Repositories;
using ImmigrationApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class AddressController : Controller

    {

        private UnitOfWork _uow = null;

        public Person con { get; private set; }

        public AddressController()
        {
            _uow = new UnitOfWork();
        }

        public AddressController(UnitOfWork uow)
        {
            this._uow = uow;
        }


        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Address a = new Address();
            a.PersonID = Convert.ToInt32( TempData["id"]);
            return View(a);
        }

        [HttpPost]
        public ActionResult Add(Address address)
        {
          //  address.PersonID = Convert.ToInt32(TempData["id"]);
            GenericRepository<Address> g = _uow.RepositoryFor<Address>();
            g.Add(address);
            _uow.Complete();
            return RedirectToAction("Details", "Person", new {id = address.PersonID});
        }

        
    }
}