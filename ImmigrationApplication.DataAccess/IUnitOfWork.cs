using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.DataAccess.Interfaces;
using ImmigrationApplication.DataAccess.Repositories;

namespace ImmigrationApplication.DataAccess
{
    public interface IUnitOfWork 
    {
        int Complete();
        GenericRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class;
    }
}
