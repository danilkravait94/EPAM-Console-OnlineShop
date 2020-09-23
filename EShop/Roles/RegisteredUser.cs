using EShop.Roles.Interfaces;
using System;

namespace EShop.Roles
{
    public class RegisteredUser : User,IRegisteredUser
    {
        public RegisteredUser() { }
        public RegisteredUser(string firstname, string lastname, string email, string pasword) 
            : base(firstname,lastname,email,pasword) { }
        public RegisteredUser(string firstname, string lastname, string email, string pasword,long numberofcard) 
            : base(firstname, lastname, email, pasword,numberofcard) { }

        public void CancelOrder(Order order)
        {
            if (order.Status != Order.Statuses.CanceledByAdmin && order.Status != Order.Statuses.Recieved)
            {
                order.Status = Order.Statuses.CanceledByUser;
            }
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Console.WriteLine($"Email has been successfuly changed to {email}");
        }

        public void ChangeInfo(string name, string lastname)
        {
            FirstName = name;
            LastName = lastname;
            Console.WriteLine($"Full name has been successfuly changed to {FirstName} {LastName}");
        }

        public void ChangeInfo(string password)
        {
            Pasword = password;
            Console.WriteLine($"Pasword has been successfuly changed");
        }

        public void ChangeInfo(decimal money)
        {
            Money = money;
            Console.WriteLine($"Money have been successfuly changed");
        }

        public void SetGetToOrder(Order order)
        {
            order.Status = Order.Statuses.Recieved;
        }
        public override void PaintMy()
        {
            Console.SetCursorPosition(70, 0);
            Console.Write($"{FirstName}/Exit(7)\n");
        }
    }
}
