using Microsoft.AspNet.Identity;
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
            int personid = 1;
            var path1 = Path.Combine(Server.MapPath("~/Uploads"));
            ViewBag.fir = Directory.GetFiles(path1 + "/" + personid);
            return View(ViewBag.fir);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            int personid = 1;
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
            var path1 = Path.Combine(Server.MapPath("~/Uploads"));
            if (!Directory.Exists(path1 + "/" + personid))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path1 + "/" + personid);
                file.SaveAs(dir.FullName + "/" + filename);
            }
            else
            {
                var path = path1 + "/" + personid + "/" + filename;
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Download(string fileName)
        {
            //  int personid = 1;
            //  return new File((Server.MapPath("~/uploads")) + "/" + personid + "/" + fileName);
            return View();
        }
    }
}