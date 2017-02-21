using System;
using System.Linq;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class FormerSpouseController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public FormerSpouseController()
        {
            _uow = new UnitOfWork();
        }

        public FormerSpouseController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: list of all FormerSpouse details
        public ActionResult Index(string personid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().GetAll();
            var enumerable = formerspouse as FormerSpouse[] ?? formerspouse.ToArray();
            var spouselist = enumerable.Where(x => x.PersonID == id).ToList();
            if (spouselist.Count == 0)
            {
                return RedirectToAction("Create", "FormerSpouse", new {personId = personid});
            }
            return View(enumerable.Where(x=>x.PersonID==id));
        }


        // Get details of one particular FormerSpouse
        public ActionResult Details(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(personid);
            return View(formerspouse);
        }

        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(personId);
            FormerSpouse fs;
            if (personid > 0)
            {
                fs = new FormerSpouse
                {
                    PersonID = personid
                };
            }
            else
            {
                fs = new FormerSpouse
                {
                    PersonID = Convert.ToInt32(TempData["id"])
                };
            }
            return View(fs);
        }

        [HttpPost]
        public ActionResult Create(FormerSpouse formerSpouse)
        {
            if (!ModelState.IsValid) return View();
            var ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Add(formerSpouse);
            _uow.Complete();
            return RedirectToAction("Index", "FormerSpouse", new {personid = formerSpouse.PersonID});
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var personid = encryptdecrypt.DecryptToBase64(id);
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(personid);
            return View(formerspouse);
        }

        [HttpPost]
        public ActionResult Edit(FormerSpouse formerspouse)
        {
            var ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Update(formerspouse);
            _uow.Complete();
            return RedirectToAction("Details", "FormerSpouse", new { id = formerspouse.FormerSpouseID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            return View(formerspouse);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            FormerSpouse formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            _uow.RepositoryFor<FormerSpouse>().Delete(formerspouse.FormerSpouseID);
            _uow.Complete();
            return RedirectToAction("Index", "FormerSpouse");
        }
    }
}


