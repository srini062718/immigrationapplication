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
    
    public partial class USRelative
    {
        public int USRelativeID { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string USVisaType { get; set; }
        public int Age { get; set; }
        public string MaritialStatus { get; set; }
        public string Address { get; set; }
        public int PersonID { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
