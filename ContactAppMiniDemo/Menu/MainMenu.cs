using ContactAppMiniDemo.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Menu
{
    internal class MainMenu
    {
        public void Display()
        {
            while (true)
            {
                Console.Write("Enter UserId: ");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    var user = UserManager.FindUser(userId);

                    if (user == null)
                    {
                        Console.WriteLine("User not found");
                        continue;
                    }

                    if (user.IsAdmin)
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Display();
                    }
                    else
                    {
                        StaffMenu staffMenu = new StaffMenu();
                        staffMenu.Display();
                    }
                }
            }
        }
    }
}
