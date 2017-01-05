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
        public string SSN;

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
        public string Address1;
    }
}
