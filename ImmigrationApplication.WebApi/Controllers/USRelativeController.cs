using System;
using System.Linq;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class UsRelativeController : Controller
    {
        private readonly UnitOfWork _uow = null;

        public UsRelativeController()
        {
            _uow = new UnitOfWork();
        }
        // GET: Parent
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var usrelative = _uow.RepositoryFor<USRelative>().GetAll();
            var enumerable = usrelative as USRelative[] ?? usrelative.ToArray();
            var relativeslist = enumerable.Where(x => x.PersonID == id).ToList();
            if (relativeslist.Count == 0)
            {
                return RedirectToAction("Create", "USRelative", new { personId = personid });
            }
            return View(enumerable.Where(x=>x.PersonID == id));
        }

        // get by id
        public ActionResult Details(string usrelativeid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var relativeid = encryptdecrypt.DecryptToBase64(usrelativeid);
            var usrelative = _uow.RepositoryFor<USRelative>().GetAll();
            return View(usrelative.SingleOrDefault(x => x.USRelativeID == relativeid));
        }

        // add a new 
        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            USRelative usrelative;
            if (personid > 0)
            {
                usrelative = new USRelative
                {
                    PersonID = personid
                };
            }
            else
            {
                usrelative = new USRelative
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
           
            return View(usrelative);
        }

        [HttpPost]
        public ActionResult Create(USRelative usrelative)
        {
            if (!ModelState.IsValid) return View(usrelative);
            _uow.RepositoryFor<USRelative>().Add(usrelative);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(usrelative.PersonID);
            return RedirectToAction("Index", "UsRelative" , new {personid = pid});
        }

        // edit a detail
        [HttpGet]
        public ActionResult Edit(string usrelativeid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var relativeid = encryptdecrypt.DecryptToBase64(usrelativeid);
            var usrelative = _uow.RepositoryFor<USRelative>().GetAll();
            return View(usrelative.SingleOrDefault(x => x.USRelativeID == relativeid));
        }

        [HttpPost]
        public ActionResult Edit(USRelative usrelative)
        {
            if (!ModelState.IsValid) return View(usrelative);
            _uow.RepositoryFor<USRelative>().Update(usrelative);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(usrelative.PersonID);
            return RedirectToAction("Index", "UsRelative", new { personid = pid });
        }


        // delete a detail
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var usrelative = _uow.RepositoryFor<USRelative>().Get(id);
            return View(usrelative);
        }

        [HttpPost]
        public ActionResult Delete(USRelative usrelative)
        {
            _uow.RepositoryFor<USRelative>().Delete(usrelative.USRelativeID);
            _uow.Complete();
            return RedirectToAction("Index", "USRelative");
        }
    }
}