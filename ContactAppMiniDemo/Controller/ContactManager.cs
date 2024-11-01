using ContactAppMiniDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Controller
{
    internal class ContactManager
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact(1, "Prathamesh", "Walawalkar")
            {
               ContactDetails = new List<ContactDetails>
               {
                   new ContactDetails(1, "Email", "prathamesh@gmail.com"),
                   new ContactDetails(2, "Phone", "9876667888")
               }
            },
            new Contact(2, "Shubham", "Raut")
            {
               ContactDetails = new List<ContactDetails>
               {
                   new ContactDetails(1, "Email", "shubham@gmail.com"),
                   new ContactDetails(2, "Phone", "9876667888")
               }
            },
            new Contact(3, "Sachin", "Kadu")
        };

        public static void AddContact(int id,string firstName, string lastName)
        {
            var contact = new Contact(id, firstName, lastName);
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully");
        }

        public static void ModifyContact(Contact contact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.ContactID == contact.ContactID);
            if (existingContact != null && existingContact.IsActive)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
            }
        }

        public static void DeleteContact(int contactId)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactID == contactId);
            if (contact != null)
            {
                contact.IsActive = false;
            }
        }

        public static List<Contact> GetActiveContacts()
        {
            return contacts.Where(c => c.IsActive).ToList();
        }

        public static Contact FindContact(int contactId)
        {
            return contacts.FirstOrDefault(c => c.ContactID == contactId && c.IsActive);
        }

        public static void AddContactDetail(int contactId, ContactDetails contactDetail)
        {
            var contact = FindContact(contactId);
            if (contact != null && contact.IsActive)
            {
                contact.ContactDetails.Add(contactDetail); 
                Console.WriteLine("Contact details added successfully");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public static void ModifyContactDetail(ContactDetails contactDetail)
        {
            foreach (var contact in contacts)
            {
                var detail = contact.ContactDetails.FirstOrDefault(d => d.ContactDetailsID == contactDetail.ContactDetailsID);
                if (detail != null && detail.IsActive)
                {
                    detail.Type = contactDetail.Type;
                    detail.Value = contactDetail.Value;
                    return;
                }
            }
        }

        public static void DeleteContactDetail(int detailId)
        {
            foreach (var contact in contacts)
            {
                var detail = contact.ContactDetails.FirstOrDefault(d => d.ContactDetailsID == detailId);
                if (detail != null)
                {
                    detail.IsActive = false;
                    return;
                }
            }
        }
        public static List<ContactDetails> GetActiveContactDetails()
        {
            return contacts.SelectMany(c => c.ContactDetails).Where(d => d.IsActive).ToList();
        }

        public static ContactDetails FindContactDetail(int detailId)
        {
            return contacts.SelectMany(c => c.ContactDetails).FirstOrDefault(d => d.ContactDetailsID == detailId && d.IsActive);
        }
    }
}
