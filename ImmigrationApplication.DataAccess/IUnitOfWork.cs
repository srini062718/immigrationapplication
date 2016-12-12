using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmigrationApplication.DataAccess.Interfaces;

namespace ImmigrationApplication.DataAccess
{
    public interface IUnitOfWork 
    {

        int Complete();
    }
}
