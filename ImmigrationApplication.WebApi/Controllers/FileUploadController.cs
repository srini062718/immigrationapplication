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
        public ActionResult Index(int personid)
        {
            var path1 = Path.Combine(Server.MapPath("~/Uploads"));
            var path2 = path1 + "/" + personid;
            if (!Directory.Exists(path2))
            {
                return RedirectToAction("Upload", "FileUpload",new {personId = personid});

            }
            ViewBag.fir = Directory.GetFiles(path1 + "/" + personid);
            return View(ViewBag.fir);
        }

        [HttpPost]
        public ActionResult Upload(int personId)
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
            var path1 = Path.Combine(Server.MapPath("~/Uploads"));
            if (!Directory.Exists(path1 + "/" + personId))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path1 + "/" + personId);
                file.SaveAs(dir.FullName + "/" + filename);
            }
            else
            {
                var path = path1 + "/" + personId + "/" + filename;
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public FileResult Download(int personid, string name)
        {
           return  new FilePathResult((Server.MapPath("~/uploads")) + "/" + personid + "/" + name,System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}