using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using System.Web.Http;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.WebAPI.Controllers
{
    public class PersonController : Controller
    {
        private UnitOfWork uow = null; 

        public PersonController()
        {
            uow = new UnitOfWork();
        }

        public PersonController(UnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ContentResult GetPersonName(int id)
        {
            ContentResult result = new ContentResult();
            try
            {
                result.Content = uow.PersonRepository.GetById(id).FirstName.ToString();
            }
            catch (Exception e)
            {
                // TO Do Exception handling
            }
            return result;
        }

        public EmptyResult AddPerson()
        {
            try
            {
                uow.PersonRepository.Add(new Person() { PersonID = 2, FamilyName = "Test", FirstName = "Jim", Gender = "M" });
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                // TO Do Exception handling
            }
            return new EmptyResult();
        }

        public EmptyResult DeletePerson()
        {
            try
            {
                uow.PersonRepository.Delete(new Person() { PersonID = 2, FamilyName = "Test", FirstName = "JimUpd", Gender = "M" });
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                // TO Do Exception handling
            }

            return new EmptyResult();
        }

        public EmptyResult UpdatePerson()
        {
            try
            {
                uow.PersonRepository.Update(new Person() { PersonID = 2, FamilyName = "Test", FirstName = "JimUpd", Gender = "M" });
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                // TO Do Exception handling
            }
            return new EmptyResult();
        }
    }
}
