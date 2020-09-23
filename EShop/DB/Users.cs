using EShop.Roles;
using System.Collections.Generic;

namespace EShop.DB
{
    public class Users 
    {
        public static List<User> users { get; set; } = new List<User>();
        public void Add(User user)
        {
            if (!users.Contains(user))
            {
                users.Add(user);
            }
        }
        public void Remove(User user)
        {
            users.Remove(user);
        }
        public User Find(string email)
        {
            foreach (User item in users)
            {
                if (item.Email == email) return item;
            }
            return null;
        }
        public bool Checking(string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email) return true;
            }
            return false;
        }
    }
}
