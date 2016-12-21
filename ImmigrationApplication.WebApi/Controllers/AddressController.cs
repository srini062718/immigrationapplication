using ImmigrationApplication.DataAccess;
using ImmigrationApplication.DataAccess.Repositories;
using ImmigrationApplication.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class AddressController : Controller

    {
        private readonly UnitOfWork _uow = null;

        public AddressController()
        {
            _uow = new UnitOfWork();
        }

        public AddressController(UnitOfWork uow)
        {
            this._uow = uow;
        }


        // GET: Addresses list of all address
        public ActionResult Index()
        {
           IEnumerable<Address> address=  _uow.RepositoryFor<Address>().GetAll();
            return View(address);
        }

        // Get single address 
        public ActionResult Details(int personid)
        {

            IEnumerable<Address> a = _uow.RepositoryFor<Address>().GetAll();
           Address ax=  a.ToList().Find(x => x.PersonID == personid);
            return View(a.Where(x=>x.PersonID == personid).FirstOrDefault());
        }

        [HttpGet]
        public ActionResult Add()
        {
            Address a = new Address {PersonID = Convert.ToInt32(TempData["id"])};
            return View(a);
        }

        [HttpPost]
        public ActionResult Add(Address address)
        {
          //  address.PersonID = Convert.ToInt32(TempData["id"]);
            GenericRepository<Address> g = _uow.RepositoryFor<Address>();
            g.Add(address);
            _uow.Complete();
            return RedirectToAction("Add", "Education");
        }


        // address/edit/id
        [HttpGet]
        public ActionResult Edit(int personid)
        {

            IEnumerable<Address> a = _uow.RepositoryFor<Address>().GetAll();

            return View(a.Where(x => x.PersonID == personid).FirstOrDefault());
        //    Address a = _uow.RepositoryFor<Address>().Get(id);
        //    return View(a);

        }

        [HttpPost]
        public ActionResult Edit(Address a)
        {
           GenericRepository<Address>  address = _uow.RepositoryFor<Address>();
            address.Update(a);
            _uow.Complete();
            return RedirectToAction("Details", "Address", new {id = a.PersonID});
        }

      //  Address/delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
           Address a = _uow.RepositoryFor<Address>().Get(id);
            return View(a);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
         Address a =   _uow.RepositoryFor<Address>().Get(id);
            _uow.RepositoryFor<Address>().Delete(a.AddressID);
            _uow.Complete();
            return RedirectToAction("Index", "Address");
        }
    }
}