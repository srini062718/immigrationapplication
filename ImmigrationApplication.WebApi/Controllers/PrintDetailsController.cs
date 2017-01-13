using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Rotativa;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.WebApi.ViewModels;
using Rotativa.Options;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class PrintDetailsController : Controller
    {
        public string FileName;
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
            var addresslist = a.Where(x => x.PersonID == personid).ToList();
            var address = addresslist;

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

        public ActionResult ExportPdf(int id)
        {

            return new ActionAsPdf("Details", new {personid = id})
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = { Left = 1, Right = 1 },
                FileName = Server.MapPath("ListDetails.pdf")
            };
        }
    }
}