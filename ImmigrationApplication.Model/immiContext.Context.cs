﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class immigrationEntities : DbContext
    {
        public immigrationEntities()
            : base("name=immigrationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<FormerSpouse> FormerSpouses { get; set; }
        public virtual DbSet<LastArrivalDetail> LastArrivalDetails { get; set; }
        public virtual DbSet<OtherDetail> OtherDetails { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PreviousApplication> PreviousApplications { get; set; }
        public virtual DbSet<USRelative> USRelatives { get; set; }
    }
}
