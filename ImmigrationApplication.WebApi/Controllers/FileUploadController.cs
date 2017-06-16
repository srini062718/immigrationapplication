using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index(string personid)
        {
            var encdyc = new EncryptAndDecrypt();
            var personId = encdyc.DecryptToBase64(personid);
            ViewBag.PersonID = personid;
            var path1 = Path.Combine(Server.MapPath("~/Uploads"));
            var path2 = path1 + "/" + personId;
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }


            ViewBag.fir = Directory.GetFiles(path2);
            return View(ViewBag.fir);
        }

        [HttpPost]
        public ActionResult Upload(string personId)
        {
            var encdyc = new EncryptAndDecrypt();
            var personid = encdyc.DecryptToBase64(personId);
            if (Request.Files.Count <= 0) return RedirectToAction("Index", new {personid = personId});
            var file = Request.Files[0];
            if (file == null || file.ContentLength <= 0) return RedirectToAction("Index", new {personid = personId});
            var filename = Path.GetFileName(file.FileName);
            if (filename == null)
            {
                throw new Exception("filename doesnot exist");
            }
            var filextension = Path.GetExtension(file.FileName);
            if (filextension != null && (filextension.ToLower() != ".docx" && filextension.ToLower() != ".pdf" &&
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
                var dir = Directory.CreateDirectory(path1 + "/" + personid);
                file.SaveAs(dir.FullName + "/" + filename);
            }
            else
            {
                var path = path1 + "/" + personid + "/" + filename;
                file.SaveAs(path);
            }
            var pid =   encdyc.EncryptToBase64(personid);
            return RedirectToAction("Index", new {  personid = pid });
        }

        public FileResult Download(string name , string extension)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "filename=" + extension);
            Response.TransmitFile(name);
            Response.End();
           return new FilePathResult(name, System.Net.Mime.MediaTypeNames.Application.Zip);
        }
    }
}