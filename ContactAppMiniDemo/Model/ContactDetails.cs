using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Model
{
    internal class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; } 
        public string Value { get; set; } 

        public bool IsActive { get; set; } = true;

        public ContactDetails(int contactDetailsId, string type, string value)
        {
            ContactDetailsID = contactDetailsId;
            Type = type;
            Value = value;
        }
    }
}
