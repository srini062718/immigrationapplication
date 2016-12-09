using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.DataAccess.Interfaces;
using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess.Repositories;

namespace ImmigrationApplication.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private  immigrationEntities _context = null;

        public UnitOfWork()
        {
            _context = new immigrationEntities();

            personRepository = new PersonRepository(_context);
           
        }

        // Add all the repository handles here
      IPersonRepository personRepository = null;



        // Initialize all the repository properties here

        public IPersonRepository PersonRepository
        {

            get
            {
                if(personRepository== null)
                {
                    personRepository = new PersonRepository(_context);
                }
                return personRepository;
            }
                }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
