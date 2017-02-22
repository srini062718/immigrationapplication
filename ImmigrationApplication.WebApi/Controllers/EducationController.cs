using System;
using System.Linq;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class EducationController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public EducationController()
        {
            _uow = new UnitOfWork();
        }

        // GET: list of all Education details
        public ActionResult Index(string personid)

        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var id = encryptdecrypt.DecryptToBase64(personid);
            var education = _uow.RepositoryFor<Education>().GetAll();
            var enumerable = education as Education[] ?? education.ToArray();
            var educationlist = enumerable.Where(x => x.PersonID == id).ToList();
            if (educationlist.Count == 0)
            {
                return RedirectToAction("Create", "Education", new {personId = personid});
            }
            return View(enumerable.Where(x => x.PersonID == id));
        }


        // Get details of one particular education
        public ActionResult Details(string educationid)
        {
            var encdyc = new EncryptAndDecrypt();
            var educatid = encdyc.DecryptToBase64(educationid);
            var education = _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=> x.EducationID == educatid));
        }

        [HttpGet]
        public ActionResult Create(string personId)
        {
            var encdyc = new EncryptAndDecrypt();
            var personid =   encdyc.DecryptToBase64(personId);
            Education e;
            if (personid > 0)
            {
               e = new Education
                {
                    PersonID = personid
                };
            }
            else
            {
                e = new Education
                {
                    PersonID = Convert.ToInt32(TempData["personid"])
                };

            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (!ModelState.IsValid) return View(education);
            var ed = _uow.RepositoryFor<Education>();
            ed.Add(education);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var pid = encdyc.EncryptToBase64(education.PersonID);
            return RedirectToAction("Index", "Education",new {personid = pid });
        }

        [HttpGet]
        public ActionResult Edit(string educationid)
        {
            var encryptdecrypt = new EncryptAndDecrypt();
            var eduid = encryptdecrypt.DecryptToBase64(educationid);
            var education =  _uow.RepositoryFor<Education>().GetAll();
            return View(education.FirstOrDefault(x=>x.EducationID == eduid));


        }

        [HttpPost]
        public ActionResult Edit(Education education)
        {
            if (!ModelState.IsValid) return View(education);
            var ed = _uow.RepositoryFor<Education>();
            ed.Update(education);
            _uow.Complete();
            var encdyc = new EncryptAndDecrypt();
            var personId = encdyc.EncryptToBase64(education.PersonID);
            return RedirectToAction("Index", "Education", new {personid = personId});
        }

        [HttpGet]
        public ActionResult Delete(int personid)
        {
           var education = _uow.RepositoryFor<Education>().GetAll();
            return View(education.SingleOrDefault(x=>x.PersonID==personid));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            var education = _uow.RepositoryFor<Education>().Get(id);
            _uow.RepositoryFor<Education>().Delete(education.EducationID);
            _uow.Complete();
            return RedirectToAction("Index", "Education", new {personid = education.PersonID});
        }
    }
}