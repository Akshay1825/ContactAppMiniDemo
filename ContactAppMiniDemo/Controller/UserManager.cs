using ContactAppMiniDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniDemo.Controller
{
    internal class UserManager
    {
        public static List<User> Users = new List<User>
        {
            new User(1, "Yogesh", "Raut", true),
            new User(2, "Atharva", "Vichare", false), 
            new User(3, "Rohit", "Chavan", true)
        };

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static void ModifyUser(int userId, string firstName, string lastName)
        {
            var user = Users.FirstOrDefault(u => u.UserID == userId && u.IsActive);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
            }
        }

        public static void DeleteUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                user.IsActive = false;
            }
        }

        public static List<User> GetActiveUsers()
        {
            return Users.Where(u => u.IsActive).ToList();
        }

        public static User FindUser(int userId)
        {
            return Users.FirstOrDefault(u => u.UserID == userId && u.IsActive);
        }
    }
}
