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
       

        // GET: Addresses list of all address
        public ActionResult Index(string personid)
        {
           var encryptdecrypt = new EncryptAndDecrypt();
           var id =  encryptdecrypt.DecryptToBase64(personid);
            var address=  _uow.RepositoryFor<Address>().GetAll();
            var enumerable = address as Address[] ?? address.ToArray();
           var addresslist = enumerable.Where(x => x.PersonID == id).ToList();
           if (addresslist.Count != 0) return View(enumerable.Where(x => x.PersonID == id));
            Console.WriteLine("You didn't provide the address details, Please provide it now.");
            return RedirectToAction("Create", "Address", new {personid});
        }
        
        // Get single address 
        public ActionResult Details(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var a = _uow.RepositoryFor<Address>().GetAll();
            return View(a.FirstOrDefault(x => x.PersonID == personid));
        }


        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
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
            if (!ModelState.IsValid) return View(address);
            var g = _uow.RepositoryFor<Address>();
            g.Add(address);
            _uow.Complete();
            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
            string pid = encdyc.EncryptToBase64(address.PersonID);
            return RedirectToAction("Index", "Address", new { personid = pid });
        }


        // address/edit/id
        [HttpGet]
        public ActionResult Edit(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var a = _uow.RepositoryFor<Address>().GetAll();
            return View(a.FirstOrDefault(x => x.PersonID == personid));
        }

        [HttpPost]
        public ActionResult Edit(Address a)
        {
            string pid = Request.QueryString["PersonID"];
            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
           int personid =  encdyc.DecryptToBase64(pid);
            a.PersonID = personid;
           if (!ModelState.IsValid) return View(a);
           var  address = _uow.RepositoryFor<Address>();
            address.Update(a);
            _uow.Complete();
            return RedirectToAction("Index", "Address", new {personid = a.PersonID});
        }

      //  Address/delete/id
        [HttpGet]
        public ActionResult Delete(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var a = _uow.RepositoryFor<Address>().GetAll();
            return View(a.SingleOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
             Address a = _uow.RepositoryFor<Address>().Get(id);
            _uow.RepositoryFor<Address>().Delete(a.AddressID);
            _uow.Complete();
            return RedirectToAction("Index", "Address");
        }
    }
}