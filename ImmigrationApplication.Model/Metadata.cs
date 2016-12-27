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

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth;

        [Display(Name ="Middle Name")]
        public string MiddleName;

        [Display(Name ="Marital Status")]
        [Required]
        public string MartialStatus;

        [Display(Name = "Visa Type")]
        [Required]
        // ReSharper disable once InconsistentNaming
        public string USVisaType;

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Visa Issue")]
        public DateTime VisaIssueDate;

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Visa Expiration")]
        public DateTime VisaExpiryDate;

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Last US Entry")]
        // ReSharper disable once InconsistentNaming
        public DateTime LastUSEntryDate;

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "I-94 Expiration Date")]
        public DateTime I94ExpiryDate;

        [Display(Name = "Alias Any(Names)")]
        [Required]
        public string AliasAny;

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

        [DataType(DataType.Date)]
        [Required]
        [Display(Name ="Date of Passport Issue")]
        public DateTime DateIssued;

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Passport Expiration")]
        public DateTime DateExpired;

        [Display(Name = "Spouse Name")]
        [Required]
        public string SpouseName;

        [DataType(DataType.Date)]
        [Required]
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
