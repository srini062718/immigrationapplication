using System;
using System.Collections.Generic;
using System.Linq;
using ImmigrationApplication.Model;
using System.Linq.Expressions;
using ImmigrationApplication.DataAccess.Interfaces;
using System.Data.Entity;

namespace ImmigrationApplication.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity  : class
    {
        protected readonly immigrationEntities Context;

        public GenericRepository(immigrationEntities context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            // Here we are working with a repository pattern and immigration entities instance. So we don't have DbSets 
            // such as person and parents, and we need to use the generic Set() method to access them.

            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(object id)
        {
           var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

    }
}
