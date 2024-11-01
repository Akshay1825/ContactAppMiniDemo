using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Model
{
    internal class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();

        public Contact(int contactId, string firstName, string lastName)
        {
            ContactID = contactId;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }
    }
}
