using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Rotativa;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.WebApi.ViewModels;
using Rotativa.Options;
using System.Data.Entity;
using System.Data.SqlClient;

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
            var pr = new PrintRepository();
          var p =  pr.GetPersonDetailsById(personid);
            return View(p);
        }

        public ActionResult ExportPdf(int id)
        {

            return new ActionAsPdf("Details", new {personid = id})
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                FileName = Server.MapPath("ListDetails.pdf")
            };
        }
    }
}