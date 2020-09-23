using EShop.DB;
using EShop.Roles.Interfaces;
using System;
using System.Collections.Generic;

namespace EShop.Roles
{
    public class User : Users, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public long NumberofCard { get; set; }
        public decimal Money { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Basket { get; set; } = new List<Product>();
        public User()
        { }
        public User(string firstname,string lastname,string email,string pasword)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Pasword = pasword;

        }
        public User(string firstname, string lastname, string email, string pasword,long numberofcard)
            : this(firstname,lastname,email,pasword)
        {
            NumberofCard = numberofcard;
            Money = 1500;
        }
        
        public void ShowOrders()
        {
            if(Orders.Count==0)
            {
                Console.WriteLine("The list of orders is empty");
                return;
            }
            foreach (var item in Orders)
            {
                Console.WriteLine(item);
            }
        }
        public void AddToBasket(Product product)
        {
            Basket.Add(product);
        }
        public void AddorNoToBasket()
        {
            Product product = Products.FindProduct();
            Console.WriteLine(product);
            Console.WriteLine("Add to basket?\n" +
                "press 'Y' to Yes\n" +
                "      'N' to No");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                AddToBasket(product);
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        public void ShowBasket()
        {
            if (Basket.Count == 0)
            {
                Console.WriteLine("The basket is empty");
                return;
            }
            foreach (var item in Basket)
            {
                Console.WriteLine(item);
            }
        }
        public void CreateOrder()
        {
            Console.WriteLine("Write a number of product that you want to buy");
            ShowBasket();
            int index = Convert.ToInt32(Console.ReadLine());
            while (index < 0 || index > Basket.Count)
            {
                Console.WriteLine("Write a number one more time");
                index = Convert.ToInt32(Console.ReadLine());
            }
            Product product = Basket[index];
            Console.WriteLine("Write a name of your country");
            string country = Console.ReadLine();
            Console.WriteLine("Write a number of post");
            int number = Convert.ToInt32(Console.ReadLine());
            if (Money < product.Price)
            {
                Console.WriteLine("You cannot afford this product");
                return;
            }
            CreateOrder(new Order(product, country, number));
        }
        public void CreateOrder(Order order)
        {
            Basket.Remove(order.Product);
            Orders.Add(order);
        }

        public void EditOrder(Order order,string country)=> order.Country = country;

        public void EditOrder(Order order, int number)=> order.NumberOfPost = number;

        public void EditOrder(Order order, string country, int number)
        {
            order.Country = country;
            order.NumberOfPost = number;
        }
        public Guest Exit()
        {
            return new Guest();
        }
        public override string ToString()
        {
            return $"{FirstName,10}|{LastName,10}|{Email,15}|{Pasword,10}";
        }
        public virtual void PaintMy()
        {

        }
    }
}
