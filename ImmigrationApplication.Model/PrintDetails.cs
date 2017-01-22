using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmigrationApplication.Model
{
   public class PrintDetails
    {
        public Person Person { get; set; }
        public List<Address> Address { get; set; }
        public Education Education { get; set; }
        public Employment Employment { get; set; }
        public Child Child { get; set; }
        public FormerSpouse FormerSpouse { get; set; }
        public Parent Parent { get; set; }
        public PreviousApplication PreviousApplication { get; set; }
        public OtherDetail OtherDetail { get; set; }
        // ReSharper disable once InconsistentNaming
        public USRelative USRelative { get; set; }
        public LastArrivalDetail LastArrivalDetail { get; set; }
    }
}
