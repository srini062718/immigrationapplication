using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private ImmiEntities dbContext = null;
        public UnitOfWork()
        {
            dbContext = new ImmiEntities();
        }

        // Add all the repository handles here
        IPersonRepository personRepository = null;

        // Add all the repository getters here
        public IPersonRepository PersonRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new PersonRepository(dbContext);
                }
                return personRepository;
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
