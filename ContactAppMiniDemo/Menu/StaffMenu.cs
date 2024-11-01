using ContactAppMiniDemo.Controller;
using ContactAppMiniDemo.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Menu
{
    internal class StaffMenu
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine("\nStaff Menu:");
                Console.WriteLine("1. Operate Contacts");
                Console.WriteLine("2. Operate Contact Details");
                Console.WriteLine("3. Logout");

                switch (Console.ReadLine())
                {
                    case "1":
                        DisplayContactsMenu();
                        break;
                    case "2":
                        DisplayContactDetailsMenu();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void DisplayContactsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nContacts Menu:");
                Console.WriteLine("1. Add new Contact");
                Console.WriteLine("2. Modify Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display all Contacts");
                Console.WriteLine("5. Find Contact");
                Console.WriteLine("6. Back To Staff Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ModifyContact();
                        break;
                    case "3":
                        DeleteContact();
                        break;
                    case "4":
                        DisplayContacts();
                        break;
                    case "5":
                        FindContact();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void DisplayContactDetailsMenu()
        {
            while (true)
            {
                Console.WriteLine("\nContact Details Menu:");
                Console.WriteLine("1. Add new Contact Details");
                Console.WriteLine("2. Modify Contact Details");
                Console.WriteLine("3. Delete Contact Details");
                Console.WriteLine("4. Display all Contact Details");
                Console.WriteLine("5. Find Contact Details");
                Console.WriteLine("6. Back To Staff Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddContactDetail();
                        break;
                    case "2":
                        ModifyContactDetail();
                        break;
                    case "3":
                        DeleteContactDetail();
                        break;
                    case "4":
                        DisplayContactDetails();
                        break;
                    case "5":
                        FindContactDetail();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void AddContact()
        {
            Console.Write("Enter ID ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Contact First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Contact Last Name: ");
            string lastName = Console.ReadLine();
            ContactManager.AddContact(id,firstName,lastName);
            Console.WriteLine("Contact added successfully.");
        }

        private void ModifyContact()
        {
            Console.Write("Enter Contact ID to modify: ");
            if (int.TryParse(Console.ReadLine(), out int contactId))
            {
                var contact = ContactManager.FindContact(contactId);
                if (contact != null)
                {
                    Console.Write("Enter new First Name: ");
                    contact.FirstName = Console.ReadLine();
                    Console.Write("Enter new Last Name: ");
                    contact.LastName = Console.ReadLine();
                    ContactManager.ModifyContact(contact);
                    Console.WriteLine("Contact modified successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
        }

        private void DeleteContact()
        {
            Console.Write("Enter Contact ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int contactId))
            {
                ContactManager.DeleteContact(contactId);
                Console.WriteLine("Contact deleted Successfully");
            }
        }

        private void DisplayContacts()
        {
            foreach (var contact in ContactManager.GetActiveContacts())
            {
                Console.WriteLine($"ID: {contact.ContactID}, Name: {contact.FirstName} {contact.LastName}");
            }
        }

        private void FindContact()
        {
            Console.Write("Enter Contact ID to find: ");
            if (int.TryParse(Console.ReadLine(), out int contactId))
            {
                var contact = ContactManager.FindContact(contactId);
                if (contact != null)
                {
                    Console.WriteLine($"ID: {contact.ContactID}, Name: {contact.FirstName} {contact.LastName}");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
        }

        private void AddContactDetail()
        {
            Console.Write("Enter Contact ID for the details: ");
            if (int.TryParse(Console.ReadLine(), out int contactId))
            {
                var contact = ContactManager.FindContact(contactId);
                if (contact != null)
                {
                    Console.Write("Enter ID ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter ContactDetails Type (Number/Email): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter Value: ");
                    string detail = Console.ReadLine();
                    var newDetail = new ContactDetails(id, type, detail);
                    ContactManager.AddContactDetail(contactId, newDetail);
                    Console.WriteLine("Contact details added successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found");
                }
            }
        }

        private void ModifyContactDetail()
        {
            Console.Write("Enter Contact Details ID to modify: ");
            if (int.TryParse(Console.ReadLine(), out int detailId))
            {
                var detail = ContactManager.FindContactDetail(detailId);
                if (detail != null)
                {
                    Console.Write("Enter new Details Type (Number/Email) : ");
                    detail.Type = Console.ReadLine();
                    Console.Write("Enter new Details Value : ");
                    detail.Value = Console.ReadLine();
                    ContactManager.ModifyContactDetail(detail);
                    Console.WriteLine("Contact details modified successfully.");
                }
                else
                {
                    Console.WriteLine("Contact details not found.");
                }
            }
        }

        private void DeleteContactDetail()
        {
            Console.Write("Enter Contact Details ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int detailId))
            {
                ContactManager.DeleteContactDetail(detailId);
                Console.WriteLine("ContactDetails deleted Successfully.");
            }
        }

        private void DisplayContactDetails()
        {
            foreach (var detail in ContactManager.GetActiveContactDetails())
            {
                Console.WriteLine($"ID: {detail.ContactDetailsID}, Type: {detail.Type}, Detail: {detail.Value}");
            }
        }

        private void FindContactDetail()
        {
            Console.Write("Enter Contact Details ID to find: ");
            if (int.TryParse(Console.ReadLine(), out int detailId))
            {
                var detail = ContactManager.FindContactDetail(detailId);
                if (detail != null)
                {
                    Console.WriteLine($"ID: {detail.ContactDetailsID}, Type: {detail.Type}, Value: {detail.Value}");
                }
                else
                {
                    Console.WriteLine("Contact details not found.");
                }
            }
        }
    }
}
