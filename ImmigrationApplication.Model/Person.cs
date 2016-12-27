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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Addresses = new HashSet<Address>();
            this.Children = new HashSet<Child>();
            this.Educations = new HashSet<Education>();
            this.Employments = new HashSet<Employment>();
            this.FormerSpouses = new HashSet<FormerSpouse>();
            this.LastArrivalDetails = new HashSet<LastArrivalDetail>();
            this.OtherDetails = new HashSet<OtherDetail>();
            this.Parents = new HashSet<Parent>();
            this.PreviousApplications = new HashSet<PreviousApplication>();
            this.USRelatives = new HashSet<USRelative>();
        }
    
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public string MartialStatus { get; set; }
        public string Nationality { get; set; }
        public string USVisaType { get; set; }
        public System.DateTime VisaIssueDate { get; set; }
        public System.DateTime VisaExpiryDate { get; set; }
        public System.DateTime LastUSEntryDate { get; set; }
        public System.DateTime I94ExpiryDate { get; set; }
        public string AliasAny { get; set; }
        public int SSN { get; set; }
        public string Anumber { get; set; }
        public string PassportNumber { get; set; }
        public string CountryIssued { get; set; }
        public System.DateTime DateIssued { get; set; }
        public System.DateTime DateExpired { get; set; }
        public string SpouseName { get; set; }
        public Nullable<System.DateTime> DateofMarriage { get; set; }
        public string BirthCity { get; set; }
        public string CityofMarriage { get; set; }
        public string CountryofMarriage { get; set; }
        public string CreatedByName { get; set; }
        public string Gender { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Child> Children { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> Educations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employment> Employments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormerSpouse> FormerSpouses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LastArrivalDetail> LastArrivalDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherDetail> OtherDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreviousApplication> PreviousApplications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USRelative> USRelatives { get; set; }
    }
}
