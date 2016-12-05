using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.DataAccess
{
    public class PersonRepository: GenericRepository<Person>, IPersonRepository
    {
        private ImmiEntities entities = null;

        public PersonRepository(ImmiEntities _entities):base(_entities)
        {
            entities = _entities;
        }

        public PersonRepository()
        {
        }

        public virtual Person GetById(int id)
        {
            try
            {
                return entities.People.Where(x => x.PersonID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
