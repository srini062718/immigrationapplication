using ImmigrationApplication.Model;
using ImmigrationApplication.DataAccess.Repositories;

namespace ImmigrationApplication.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly immigrationEntities _context = null;

        public UnitOfWork()
        {
            _context = new immigrationEntities();
        
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public GenericRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }
    }
}
