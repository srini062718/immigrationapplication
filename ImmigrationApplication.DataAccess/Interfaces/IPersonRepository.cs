using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.DataAccess.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(int id);
    }
}
