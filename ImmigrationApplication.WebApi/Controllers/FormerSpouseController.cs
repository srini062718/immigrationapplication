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
            return View(enumerable.Where(x=>x.PersonID == id));
        }


        // Get details of one particular FormerSpouse
        public ActionResult Details(string formerspouseid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var spouseid = encryptdecrypt.DecryptToBase64(formerspouseid);
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().GetAll();
            return View(formerspouse.SingleOrDefault(x =>x.FormerSpouseID == spouseid));
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
                    PersonID = Convert.ToInt32(TempData["personid"])
                };
            }
            return View(fs);
        }

        [HttpPost]
        public ActionResult Create(FormerSpouse formerSpouse)
        {
            if (!ModelState.IsValid) return View(formerSpouse);
            var ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Add(formerSpouse);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(formerSpouse.PersonID);
            return RedirectToAction("Index", "FormerSpouse", new {personid = pid });
        }

        [HttpGet]
        public ActionResult Edit(string formerspouseid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var spouseid = encryptdecrypt.DecryptToBase64(formerspouseid);
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().GetAll();
            return View(formerspouse.SingleOrDefault(x => x.FormerSpouseID == spouseid));
        }

        [HttpPost]
        public ActionResult Edit(FormerSpouse formerspouse)
        {
            if (!ModelState.IsValid) return View(formerspouse);
            var ed = _uow.RepositoryFor<FormerSpouse>();
            ed.Update(formerspouse);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(formerspouse.PersonID);
            return RedirectToAction("Index", "FormerSpouse", new { personid = pid });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            return View(formerspouse);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            var formerspouse = _uow.RepositoryFor<FormerSpouse>().Get(id);
            _uow.RepositoryFor<FormerSpouse>().Delete(formerspouse.FormerSpouseID);
            _uow.Complete();
            return RedirectToAction("Index", "FormerSpouse");
        }
    }
}


