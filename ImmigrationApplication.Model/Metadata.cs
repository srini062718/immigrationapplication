﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationApplication.Model
{
    [DataContract]
   public  class  PersonMetadata
    {    
        [Display(Name ="Gender")]
        public string Sex;

        [DataType(DataType.Date)]
        public DateTime DateofBirth;
    }

    public class AddressMetadata
    {
        [Required]
        public string Address1;
    }
}