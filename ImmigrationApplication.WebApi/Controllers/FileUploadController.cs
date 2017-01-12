using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count <= 0) return RedirectToAction("Index");
            var file = Request.Files[0];
            if (file == null || file.ContentLength <= 0) return RedirectToAction("Index");
            var filename = Path.GetFileName(file.FileName);
            if (filename == null)
            {
                throw new Exception("filename doesnot exist");
            }
            var filextension = Path.GetExtension(file.FileName);
            if (filextension != null && (filextension.ToLower() != ".doc" && filextension.ToLower() != ".pdf" &&
                                         filextension.ToLower() != ".png" && filextension.ToLower() != ".jpeg"))
            {
                Console.WriteLine("The file format can only be .png , .jpeg, .pdf, .doc");
            }

            var fileSize = file.ContentLength;
            if (fileSize > 2097152)
            {
                Console.WriteLine("Maximum File Size is 2MB, Only files of below 2MB are allowed");
            }
            var path = Path.Combine(Server.MapPath("~/Uploads/"), filename);
            file.SaveAs(path);
            return RedirectToAction("Index");
        }
    }
}