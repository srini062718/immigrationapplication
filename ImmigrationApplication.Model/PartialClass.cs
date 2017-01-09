using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationApplication.Model
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {

    }

    [MetadataType(typeof(AddressMetadata))]
    public partial class Address
    {

    }

    [MetadataType(typeof(EmploymentMetaData))]
    public partial class Employment
    {
        
    }
}
