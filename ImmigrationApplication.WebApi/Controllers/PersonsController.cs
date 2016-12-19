using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.WebApi.Controllers
{
    [RoutePrefix("api/person")]
    public class PersonsController : ApiController
    {
        private immigrationEntities _context;

        [HttpGet]
        [Route("details")]
        public HttpResponseMessage PersonswdController()
        {
            _context = new immigrationEntities();
            _context.Configuration.ProxyCreationEnabled = false;
            List<Person> persons = _context.People.ToList();
            
            return Request.CreateResponse(HttpStatusCode.OK, persons);
        }


    }
}
