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
    
    public partial class OtherDetail
    {
        public int OtherDetailsID { get; set; }
        public string AboutFirm { get; set; }
        public string LicenseNumber { get; set; }
        public string LanguagesSpoken { get; set; }
        public string Conviction { get; set; }
        public string OtherInformation { get; set; }
        public int PersonID { get; set; }
    
        public virtual Person Person { get; set; }
    }
}