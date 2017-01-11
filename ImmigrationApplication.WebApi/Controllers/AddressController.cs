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
        public ActionResult Index(int personid)
        {
           var address=  _uow.RepositoryFor<Address>().GetAll();
            var enumerable = address as Address[] ?? address.ToArray();
            var addresslist = enumerable.Where(x => x.PersonID == personid).ToList();
            if (addresslist.Count != 0) return View(enumerable.Where(x => x.PersonID == personid));
            Console.WriteLine("You didn't provide the address details, Please provide it now.");
            return RedirectToAction("Create", "Address", new {personid});
        }

        // Get single address 
        public ActionResult Details(int personid)
        {

            var a = _uow.RepositoryFor<Address>().GetAll();
            return View(a.FirstOrDefault(x => x.PersonID == personid));
        }


        [HttpGet]
        public ActionResult Create(int personid)
        {
            Address a;
            if (personid > 0)
            {
                a = new Address
                {
                    PersonID = personid
                };
            }
            else
            {
                a = new Address
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };

            }
            return View(a);
        }

        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (!ModelState.IsValid) return View();
            var g = _uow.RepositoryFor<Address>();
            g.Add(address);
            _uow.Complete();
            TempData.Add("id", address.PersonID.ToString());
            return RedirectToAction("Create", "Education");
        }


        // address/edit/id
        [HttpGet]
        public ActionResult Edit(int personid)
        {

            var a = _uow.RepositoryFor<Address>().GetAll();

            return View(a.FirstOrDefault(x => x.PersonID == personid));
        //    Address a = _uow.RepositoryFor<Address>().Get(id);
        //    return View(a);

        }

        [HttpPost]
        public ActionResult Edit(Address a)
        {
           var  address = _uow.RepositoryFor<Address>();
            address.Update(a);
            _uow.Complete();
            return RedirectToAction("Details", "Address", new {personid = a.PersonID});
        }

      //  Address/delete/id
        [HttpGet]
        public ActionResult Delete(int personid)
        {
           var a = _uow.RepositoryFor<Address>().GetAll();
            return View(a.SingleOrDefault(x=>x.PersonID==personid));
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