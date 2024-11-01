using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Model
{
    internal class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<Contact> Contacts { get; set; }

        public User(int userId, string firstName, string lastName, bool isAdmin)
        {
            UserID = userId;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            IsActive = true;
            Contacts = new List<Contact>();
        }
    }
}
