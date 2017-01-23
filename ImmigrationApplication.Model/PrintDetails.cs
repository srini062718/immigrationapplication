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
        public List<Education> Education { get; set; }
        public List<Employment> Employment { get; set; }
        public List<Child> Child { get; set; }
        public List<FormerSpouse> FormerSpouse { get; set; }
        public List<Parent> Parent { get; set; }
        public List<PreviousApplication> PreviousApplication { get; set; }
        public List<OtherDetail> OtherDetail { get; set; }
        // ReSharper disable once InconsistentNaming
        public List<USRelative> USRelative { get; set; }
        public List<LastArrivalDetail> LastArrivalDetail { get; set; }
    }
}
