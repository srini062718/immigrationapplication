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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date of Visa Expiration")]
        public DateTime VisaExpiryDate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date of Last US Entry")]
        // ReSharper disable once InconsistentNaming
        public DateTime LastUSEntryDate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",  ApplyFormatInEditMode = false)]
        [Display(Name ="Date of Passport Issue")]
        public DateTime DateIssued;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date of Passport Expiration")]
        public DateTime DateExpired;

        [Display(Name = "Spouse Name")]
        [Required]
        public string SpouseName;

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
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

    public class AspNetUsers
    {
        [Required(ErrorMessage ="The Email field is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email;
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
        public int Zipcode;

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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string StartDate;

        [Required]
        [Display(Name = "Date Ended")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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
        public string Gender;

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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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

    public class FormerSpouseMetaData
    {
        [Display(Name = "Last Name")]
        [Required]
        public string LastName;

        [Display(Name = "First Name")]
        [Required]
        public string FirstName;

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth;

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName;

        [Required]
        [Display(Name = "Date of Marriage")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofMarriage;

        [Display(Name ="City of Marriage")]
        public string CityofMarriage;

        [Display(Name ="Country of Marriage")]
        public string CountryofMarriage;
        
    }

    public class LastArrivalDetailsMetaData
    {
        [Required]
        public string City;

        [Required]
        public string State;

        [Required]
        [Display(Name ="Date of Arrival")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateofArrival;

        [Required]
        [Display(Name ="Name of the Airlines")]
        public string NameofFlight;

        [Required]
        [Display(Name ="Flight Number")]
        public string FlightNumber;

        [Required]
        [Display(Name ="Applied for Green Card")]
        public string AppliedPermanentResident;

        [Required]
        [Display(Name ="Is Visa Rejected?")]
        public string RefusedVisa;


        
        // ReSharper disable once InconsistentNaming
        [Required]
        [Display(Name ="Place of Visa Issued Consulate")]
        public string USConsulate;
    }

    public class OtherDetails
    {
        [Required]
        [Display(Name ="About Firm")]
        public string AboutFirm;

        [Required]
        [Display(Name ="Driving License Number")]
        public string LicenseNumber;

        [Required]
        [Display(Name ="Lanuages Known")]
        public string LanguagesSpoken;

        [Required]
        [Display(Name ="Any Conviction ?")]
        public string Conviction;

        [Required]
        [Display(Name ="Other Details Information")]
        public string OtherInformation;
    }

    public class PreviousApplicationMetaData
    {
        [Required]
        [Display(Name ="Application Type")]
        public string ApplicationType;

        [Required]
        [Display(Name ="Date Applied")]
        public DateTime DateApplied;

        [Required]
        [Display(Name ="Is Application Approved ?")]
        public string StatusGranted;

        [Required]
        [Display(Name ="Please Indicate the Reason If Denied")]
        public string IndicateIfDenied;

        [Required]
        [Display(Name ="Cap Gap Period If Any ?")]
        public string CapGap;
    }

    // ReSharper disable once InconsistentNaming
    public class USRelativeMetaData
    {
        [Required]
        [Display(Name ="Relative Name")]
        public string Name;

        [Required]
        [Display(Name = "Relative Name")]
        public string Relationship;

        // ReSharper disable once InconsistentNaming
        [Required]
        [Display(Name = "Visa Type of Relative")]
        public string USVisaType;

        [Required]
        [Display(Name = "Age")]
        public int Age;

        [Required]
        [Display(Name = "Martial Status")]
        public string MaritialStatus;

        [Required]
        [Display(Name = "Address")]
        public string Address;
    }
}
