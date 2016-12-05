using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using ImmigrationApplication.Model;
using System.Data.Objects;

namespace ImmigrationApplication.DataAccess
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ImmiEntities context;
        internal ObjectSet<TEntity> dbSet;

        public GenericRepository(ImmiEntities context)
        {
            this.context = context;
            dbSet = context.CreateObjectSet<TEntity>();
        }

        public GenericRepository()
        {
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Add(TEntity entity)
        {
            ObjectStateManager objectStateManager = context.ObjectStateManager;
            dbSet.AddObject(entity);
            objectStateManager.ChangeObjectState(entity, System.Data.EntityState.Added);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            ObjectStateManager objectStateManager = context.ObjectStateManager;
            dbSet.Attach(entityToDelete);            
            dbSet.DeleteObject(entityToDelete);
            objectStateManager.ChangeObjectState(entityToDelete, System.Data.EntityState.Deleted);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            ObjectStateManager objectStateManager = context.ObjectStateManager;

            dbSet.Attach(entityToUpdate);
            objectStateManager.ChangeObjectState(entityToUpdate, System.Data.EntityState.Modified);
        }
    }
}
