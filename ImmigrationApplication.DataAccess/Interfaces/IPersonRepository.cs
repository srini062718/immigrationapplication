using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.DataAccess
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        Person GetById(int id);
    }
}
