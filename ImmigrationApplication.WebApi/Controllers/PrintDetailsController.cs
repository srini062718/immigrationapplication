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
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Person where PersonID = @personid", con);
                cmd.Parameters.AddWithValue("@personid", personid);
                con.Open();
                SqlDataReader rdr =  cmd.ExecuteReader();
                rdr.Read();
                con.Close();
            }
            var viewmodel = new PrintApplicantDetails
            {

            };
           
            return View();
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