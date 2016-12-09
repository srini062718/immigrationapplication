using ImmigrationApplication.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.DataAccess.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        //   private readonly immigrationEntities _entities = null;
       //   _entities = entities;

        public PersonRepository(immigrationEntities _entities) 
            : base(_entities)
        {
           
        }

      
        public virtual Person GetById(int id)
        {
            try
            {
                return entities.People.SingleOrDefault(x => x.PersonID == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        public void Update(Person P)
        {
            try
            {
                entities.Entry(P).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public immigrationEntities entities
        {
            get
            {
                return Context as immigrationEntities;
            }
        }
    }
}
