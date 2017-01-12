using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.WebApi.ViewModels;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class PrintDetailsController : Controller
    {

        private readonly UnitOfWork _uow = null;

        public PrintDetailsController()
        {
            _uow = new UnitOfWork();
        }
        // GET: PrintDetails
        public ActionResult Details(int personid)
        {
            var  person = _uow.RepositoryFor<Person>().Get(personid);

            var a = _uow.RepositoryFor<Address>().GetAll();
            var address =  a.FirstOrDefault(x => x.PersonID == personid);


            var e = _uow.RepositoryFor<Education>().GetAll();
            var education =  e.FirstOrDefault(x => x.PersonID == personid);
            
            var emp = _uow.RepositoryFor<Employment>().GetAll();
            var employ = emp.FirstOrDefault(x => x.PersonID == personid);

           var od = _uow.RepositoryFor<OtherDetail>().GetAll();
            var otherdetail = od.FirstOrDefault(x => x.PersonID == personid);

            var fs = _uow.RepositoryFor<FormerSpouse>().GetAll();
            var formerspouse = fs.FirstOrDefault(x => x.PersonID == personid);

            var  c = _uow.RepositoryFor<Child>().GetAll();
            var child = c.FirstOrDefault(x => x.PersonID == personid);

            var  par = _uow.RepositoryFor<Parent>().GetAll();
            var parent = par.FirstOrDefault(x => x.PersonID == personid);

            var  rel = _uow.RepositoryFor<USRelative>().GetAll();
            var usrelative = rel.FirstOrDefault(x => x.PersonID == personid);

            var lad  = _uow.RepositoryFor<LastArrivalDetail>().GetAll();
            var lastArrivalDetail = lad.FirstOrDefault(x => x.PersonID == personid);

            var  pa = _uow.RepositoryFor<PreviousApplication>().GetAll();
            var previousApplication = pa.FirstOrDefault(x => x.PersonID == personid);

            var viewmodel = new PrintApplicantDetails
            {
               
                Person = person,
                Address = address,
                Education = education,
                Employment = employ,
                OtherDetail = otherdetail,
                Parent = parent,
                FormerSpouse = formerspouse,
                Child = child,
                USRelative = usrelative,
                LastArrivalDetail = lastArrivalDetail,
                PreviousApplication = previousApplication
            };
            return View(viewmodel);
        }
    }
}