using ContactAppMiniDemo.Controller;
using ContactAppMiniDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Menu
{
    internal class AdminMenu
    {
        public void Display()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add new User");
                Console.WriteLine("2. Modify existing User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Display all Users");
                Console.WriteLine("5. Find User");
                Console.WriteLine("6. Logout");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        ModifyUser();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        DisplayUsers();
                        break;
                    case "5":
                        FindUser();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void AddUser()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            bool isAdmin = GetYesNo("Is Admin? (y/n): ");
            var newUser = new User(id, firstName, lastName, isAdmin);
            UserManager.AddUser(newUser);
            Console.WriteLine("User added successfully");
        }

        private void ModifyUser()
        {
            Console.Write("Enter User ID to modify: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                var user = UserManager.FindUser(userId);
                if (user != null)
                {
                    Console.Write("Enter new First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter new Last Name: ");
                    string lastName = Console.ReadLine();
                    UserManager.ModifyUser(userId, firstName, lastName);
                    Console.WriteLine("User modified successfully");
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
        }

        private void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                UserManager.DeleteUser(userId);
                Console.WriteLine("User Deleted Successfully");
            }
        }

        private void DisplayUsers()
        {
            foreach (var user in UserManager.GetActiveUsers())
            {
                Console.WriteLine($"ID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Admin: {user.IsAdmin}");
            }
        }

        private void FindUser()
        {
            Console.Write("Enter User ID to find: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                var user = UserManager.FindUser(userId);
                if (user != null)
                {
                    Console.WriteLine($"ID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Admin: {user.IsAdmin}");
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
        }

        private bool GetYesNo(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().Trim().ToLower() == "y";
        }
    }
}
