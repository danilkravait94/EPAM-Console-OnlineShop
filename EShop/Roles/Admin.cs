using EShop.DB;
using System;
using static EShop.Order;

namespace EShop.Roles
{
    public class Admin : User,IAdmin
    {
        public Admin()
        {

        }
        public Admin(string firstname, string lastname, string email, string pasword)
            : base(firstname, lastname, email, pasword) { }
        public Admin(string firstname, string lastname, string email, string pasword, long numberofcard)
            : base(firstname, lastname, email, pasword, numberofcard) { }

        public void AddProduct()
        {
            string name, category, description;
            decimal price;
            Console.Write("Name of product: ");
            name = Console.ReadLine();
            Console.WriteLine("Category: ");
            category = Console.ReadLine();
            Console.WriteLine("Description: ");
            description = Console.ReadLine();
            Console.WriteLine("Price: ");
            Console.WriteLine("Description: ");
            price = Convert.ToDecimal(Console.ReadLine());
            Products.Add(new Product(name, category, description, price));
        }

        public void ChangeProduct(Product product, string name, string category)
        {
            product.Name = name;
            product.Category = category;
        }

        public void ChangeProduct(Product product, decimal price) => product.Price = price;

        public void ChangeStatus(Order order, Statuses status) => order.Status = status;

        public void ChangeUsersEmail(User user, string email) => user.Email = email;

        public void ChangeUsersInfo(User user, string name, string lastname) 
            => (user as RegisteredUser).ChangeInfo(name, lastname);

        public void ChangeUsersInfo(User user, string password) 
            => (user as RegisteredUser).ChangeInfo(password);

        public void ChangeUsersInfo(User user, decimal money) 
            => (user as RegisteredUser).ChangeInfo(money);


        public void ShowInfoAboutUsers()
        {
            foreach (User user in users)
            {
                Console.WriteLine(user);
                user.ShowOrders();
            }
        }
        public override void PaintMy()
        {
            Console.SetCursorPosition(70, 0);
            Console.Write($"Admin-{FirstName}/Exit(7)\n");
        }
    }
}
