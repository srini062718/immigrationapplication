using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.WebApi.Controllers
{
    public class PersonController : Controller
    {
        //  private immigrationEntities context = null;
        private readonly UnitOfWork _uow;

        public PersonController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
          // var person= _uow.Person.GetById(1);
            
        //  _uow.Person.Add(new Person { PersonID = 2, LastName = "Prem", FirstName = "Aluvala", Sex="male", AliasAny ="noalias", Anumber = 345234, BirthDetails="gadwalkanchi"});
           // _uow.Complete();
           // _uow.Dispose();
           return View();
        }

    }
}