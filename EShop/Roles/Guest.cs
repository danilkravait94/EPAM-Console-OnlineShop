using EShop.DB;
using EShop.Exceptions;
using System;

namespace EShop.Roles
{
    public class Guest : User,IGuest
    {
        public User SetIn()
        {
            Console.Clear();
            Console.WriteLine("                                  Set in");
            string email, password;
            Console.Write("Email: ");
            email = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            if (Checking(email))
            {
                return SetInUser(email, password);
            }
            else
            {
                throw new UserException("Incorect email");
            }

        }
        public User SetInUser(string email,string password)
        {
            User user = Find(email);
            if (user.Pasword == password) return user;
            else
            {
                throw new UserException("Incorect password");
            }
        }
        public User SetUp()
        {
            Console.Clear();
            Console.WriteLine("                                  Set up");
            string email, firstname, lastname, password;
            long card;
            RegisteredUser registeredUser;
            Console.WriteLine("Write your first name");
            firstname = Console.ReadLine();
            Console.WriteLine("Write your last name");
            lastname = Console.ReadLine();
            Console.WriteLine("Write your email");
            email = Console.ReadLine();
            if (Checking(email))
            {
                throw new UserException("The email is used");
            }
            string passwordfirst, passwordsecond;
            do
            {
                Console.WriteLine("Write your password");
                passwordfirst = Console.ReadLine();
                Console.WriteLine("Repeat the password");
                passwordsecond = Console.ReadLine();
            }
            while (passwordfirst != passwordsecond);
            password = passwordfirst;
            Console.WriteLine("Do you want to add a card?\n" +
                "Press 'Y' to Yes\n" +
                "Press 'N' to No");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.WriteLine("Write a number of your card");
                card = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("The registration was successful");
                registeredUser = new RegisteredUser(firstname, lastname, email, password, card);
                return SetUpUser(registeredUser);
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.WriteLine("The registration was successful");
            registeredUser = new RegisteredUser(firstname, lastname, email, password);
            return SetUpUser(registeredUser);
        }
        public User SetUpUser(RegisteredUser user)
        {
            users.Add(user);
            return user;
        }
        public override void PaintMy()
        {
            Console.SetCursorPosition(70, 0);
            Console.Write("Sign in(5)/Sign up(6)\n");
        }
    }
}
