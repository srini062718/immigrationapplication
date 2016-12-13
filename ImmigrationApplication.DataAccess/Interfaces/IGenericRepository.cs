using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationApplication.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        // void Remove(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
    }
}
