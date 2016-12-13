//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImmigrationApplication.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        public int ChildrenID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public string BirthPlace { get; set; }
        public string BirthCountry { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public int PersonID { get; set; }
    
        public virtual Person Person { get; set; }
    }
}