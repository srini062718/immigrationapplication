using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImmigrationApplication.Model;

namespace ImmigrationApplication.WebApi.ViewModels
{
    public class PrintApplicantDetails
    {
        public Person Person { get; set; }
        public Address Address { get; set; }
        public Education Education { get; set; }
        public Employment Employment { get; set; }
        public Child Child { get; set; }
        public FormerSpouse Formerspouse { get; set; }
        public Parent Parent { get; set; }
        public PreviousApplication Previousapplication { get; set; }
        public OtherDetail Otherdetail { get; set; }
        public USRelative Usrelative { get; set; }
        public LastArrivalDetail LastArrivalDetail { get; set; }
    }
}