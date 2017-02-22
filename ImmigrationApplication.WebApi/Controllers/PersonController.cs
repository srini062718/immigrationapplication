using System.Linq;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;
using Microsoft.AspNet.Identity;

namespace ImmigrationApplication.WebApi.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly UnitOfWork _uow = null;

        public Person Person { get; private set; }

        public PersonController()
        {
            _uow = new UnitOfWork();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "List of Customers";
            var p = _uow.RepositoryFor<Person>();
            var per =   p.GetAll();
            if (User.IsInRole("Admin") != true )
                {
                per = per.Where(x => x.CreatedByName == User.Identity.GetUserName());
                }
            if(!per.Any())
                {
                    return RedirectToAction("Create","Person");
                }
                return View(per);
        }

        public ActionResult Details(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var p = _uow.RepositoryFor<Person>();
            Person = p.Get(personid);
            return Person == null ? View() : View(Person);
        }

        [HttpGet]
        public ActionResult Edit(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var p = _uow.RepositoryFor<Person>();
            Person = p.Get(personid);
            return View(Person);
        }

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            var person = _uow.RepositoryFor<Person>();
            person.Update(p);
            _uow.Complete();
            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
            string personid =  encdyc.EncryptToBase64(p.PersonID);
            return RedirectToAction("Details", "Person", new { personId = personid });
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            if (!ModelState.IsValid) return View();
            p.CreatedByName = User.Identity.Name;
            var person = _uow.RepositoryFor<Person>();
            person.Add(p);
            _uow.Complete();
            EncryptAndDecrypt encdyc = new EncryptAndDecrypt();
            string pid = encdyc.EncryptToBase64(p.PersonID);
            return RedirectToAction("Details", "Person", new { personId = pid });
        }

        [HttpGet]
        public ActionResult Delete(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            var person = _uow.RepositoryFor<Person>().Get(personid);
            return View(person);
        }

        [Authorize]
        [HttpPost,ActionName("Delete")]
        public ActionResult Deleteconfirmed(int personId)
        {
            var person =  _uow.RepositoryFor<Person>().Get(personId);
            _uow.RepositoryFor<Person>().Delete(person.PersonID);
            _uow.Complete();
            return RedirectToAction("Index", "Person" , new { personId });
        }
    }
}
