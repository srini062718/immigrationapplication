using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ImmigrationApplication.Model
{
    [DataContract]
   public  class  PersonMetadata
    { 

        [Display(Name ="Last Name")]
        [Required]
        public string LastName;

        [Display(Name ="First Name")]
        [Required]
        public string FirstName;

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth;

        [Display(Name ="Middle Name")]
        [Required]
        public string MiddleName;

        [Display(Name ="Marital Status")]
        [Required]
        public string MartialStatus;

        [Required]
        public string Nationality;

        [Display(Name = "Visa Type")]
        [Required]
        // ReSharper disable once InconsistentNaming
        public string USVisaType;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required]
        [Display(Name = "Date of Visa Issue")]
        public DateTime VisaIssueDate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Visa Expiration")]
        public DateTime VisaExpiryDate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Last US Entry")]
        // ReSharper disable once InconsistentNaming
        public DateTime LastUSEntryDate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "I-94 Expiration Date")]
        public DateTime I94ExpiryDate;

        [Display(Name = "Alias Any(Names)")]
        [Required]
        public string AliasAny;

        [Required]
        [Display(Name ="Alien Registration Number")]
        public string Anumber;

        [Display(Name = "Social Security Number")]
        [Required]
        // ReSharper disable once InconsistentNaming
        public int SSN;

        [Display(Name = "Passport Number")]
        [Required]
        public string PassportNumber;

        [Display(Name = "Passport Issued Country")]
        [Required]
        public string CountryIssued;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date of Passport Issue")]
        public DateTime DateIssued;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Passport Expiration")]
        public DateTime DateExpired;

        [Display(Name = "Spouse Name")]
        [Required]
        public string SpouseName;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Marriage")]
        public DateTime DateofMarriage;

        [Display(Name = "City of Birth")]
        [Required]
        public string BirthCity;

        [Display(Name = "City of Marriage")]
        [Required]
        public string CityofMarriage;

        [Display(Name = "Country of Marriage")]
        [Required]
        public string CountryofMarriage;

    }

    public class AddressMetadata
    {
        [Required]
        [Display(Name ="Address 1")]
        public string Address1;

        [Required]
        [Display(Name = "Address 2")]
        public string Address2;

        [Required]
        [Display(Name = "City")]
        public string City;

        [Required]
        [Display(Name = "State")]
        public string State;

        [Required]
        [Display(Name = "Country")]
        public string Country;

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode;


    }

    public class EmploymentMetaData
    {
        [Required]
        [Display(Name ="Employer Name")]
        public string EmployerName;

        [Required]
        [Display(Name ="Client Name")]
        public string Client;

        [Required]
        [Display(Name ="Address 1")]
        public string Address1;

        [Required]
        [Display(Name = "Address 2")]
        public string Address2;

        [Required]
        [Display(Name = "City")]
        public string City;

        [Required]
        [Display(Name = "State")]
        public string State;

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode;

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle;

        [Required]
        [Display(Name = "Salary")]
        public string Salary;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Employment Start Date")]
        public string DateStarted;

        [Required]
        [Display(Name = "Employment End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateLeft;

        [Required]
        [Display(Name = "Technologies Used")]
        public string JobDescription;
    }

    public class EducationMetaData
    {
        [Required]
        [Display(Name ="School Name")]
        public string Name;

        [Required]
        [Display(Name = "Address 1")]
        public string Address1;

        [Required]
        [Display(Name = "Address 2")]
        public string Address2;

        [Required]
        [Display(Name = "City")]
        public string City;

        [Required]
        [Display(Name = "State")]
        public string State;

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode;

        [Required]
        [Display(Name ="Field of Study")]
        public string FieldofStudy;

        [Required]
        [Display(Name ="Date Started")]
        public string StartDate;

        [Required]
        [Display(Name = "Date Ended")]
        public string EndDate;

        [Required]
        [Display(Name ="Degree Type")]
        public string Degree;
    }

    public class ChildrenMetaData
    {
        [Required]
        [Display(Name = "First Name ")]
        public string FirstName;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName;

        [Display(Name = "Middle Name")]
        public string MiddleName;

        [Required]
        [Display(Name = "Gender")]
        public string Sex;

        [Required]
        [Display(Name = "Birth Place")]
        public string BirthPlace;

        [Required]
        [Display(Name = "Birth Country")]
        public string BirthCountry;

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth;

        [Required]
        [Display(Name = "Martial Status")]
        public string MaritalStatus;

        [Required]
        [Display(Name = "Address 1")]
        public string Address1;

        [Required]
        [Display(Name = "Address 2")]
        public string Address2;

        [Required]
        [Display(Name = "City")]
        public string City;

        [Required]
        [Display(Name = "State")]
        public string State;

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode;

        [Required]
        [Display(Name ="Phone Number")]
        public string PhoneNumber;
    }

    public class ParentMetaData
    {
        [Required]
        [Display(Name = "First Name ")]
        public string FirstName;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName;

        [Display(Name = "Middle Name")]
        public string MiddleName;

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth;

        [Display(Name = "City of Birth")]
        [Required]
        public string CityofBirth;

        [Display(Name = "City of Birth")]
        [Required]
        public string CityofResidence;

        [Display(Name = "Relation Ship with the Applicant")]
        [Required]
        public string Relationship;
    }

}
