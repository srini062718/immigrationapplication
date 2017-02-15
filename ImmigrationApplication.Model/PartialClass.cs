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

    [MetadataType(typeof(EducationMetaData))]
    public partial class Education
    {

    }

    [MetadataType(typeof(ParentMetaData))]
    public partial class Parent
    {

    }

    [MetadataType(typeof(ChildrenMetaData))]
    public partial class Child
    {

    }

    [MetadataType(typeof(PreviousApplicationMetaData))]
    public partial class PreviousApplication
    {

    }

    [MetadataType(typeof(FormerSpouseMetaData))]
    public partial class FormerSpouse
    {

    }

    [MetadataType(typeof(LastArrivalDetailsMetaData))]
    public partial class LastArrivalDetail
    {

    }

    [MetadataType(typeof(USRelativeMetaData))]
    // ReSharper disable once InconsistentNaming
    public partial class USRelative
    {

    }
    [MetadataType(typeof(OtherDetails))]
    public partial class OtherDetail
    {
        
    }

    [MetadataType(typeof(AspNetUsers))]
    public partial class ApNetUser
    {
        
    }
}
