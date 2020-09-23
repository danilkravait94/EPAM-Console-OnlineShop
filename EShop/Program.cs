using EShop.DB;
using EShop.Exceptions;
using EShop.Roles;
using System;
using System.Collections.Generic;

namespace EShop
{
    class Program : Users
    {
        static User my;
        static int consoleKey = 1;
        static Dictionary<int, Action> Actions = new Dictionary<int, Action>();
        static Dictionary<int, Action> ActionsKey = new Dictionary<int, Action>();
        static Dictionary<int, Func<User>> SetDict = new Dictionary<int, Func<User>>();
        static void Main(string[] args)
        {

            AddProducts();
            my = new Admin();
            AddDictionaryAdmin();
            my = new Guest();
            AddDictionary();
            AddUsers();
            while (consoleKey != 0)
            {
                Clear();
                my.PaintMy();
                if (consoleKey < 5)
                {
                    ActionsKey[consoleKey]();
                    Actions[consoleKey]();
                }
                else
                {
                    if (my is Guest)
                    {
                        my = SetDict[consoleKey]();
                        Clear();
                        Paint();
                        my.PaintMy();
                    }
                    else
                    {
                        if (consoleKey == 7)
                            my = SetDict[consoleKey]();
                        Actions[consoleKey]();

                    }
                }
                ShowWithTry();
            }
        }
        static void ShowWithTry()
        {
            try
            {
                Console.Write("Enter your option: ");
                consoleKey = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                ShowWithTry();
            }
            catch (UserException e)
            {
                Console.WriteLine(e.Message);
                ShowWithTry();
            }
        }
        static void AddDictionary()
        {
            Actions.Add(1,Products.ShowProducts);
            ActionsKey.Add(1, PaintRed1);
            Actions.Add(2,my.ShowBasket);
            ActionsKey.Add(2, PaintRed2d);
            Actions.Add(3,my.ShowOrders);
            Actions.Add(4,my.AddorNoToBasket);
            ActionsKey.Add(3, PaintRed3);
            ActionsKey.Add(4, PaintRed4);
            SetDict.Add(5,(my as Guest).SetIn);
            SetDict.Add(6,(my as Guest).SetUp);
            SetDict.Add(7,my.Exit);
            Actions.Add(5,my.CreateOrder);
        }
        static void AddDictionaryAdmin()
        {
            Actions.Add(6, (my as Admin).AddProduct);
        }
        static void AddProducts()
        {
            Products.Add(new Product("Apple", "Food", "Fruit", 120));
            Products.Add(new Product("Plum", "Food", "Fruit", 230));
            Products.Add(new Product("Grapes", "Food", "Fruit", 80));
            Products.Add(new Product("Potato", "Food", "Vegetables", 45));
            Products.Add(new Product("Tomato", "Food", "Fruit", 53));
            Products.Add(new Product("Strawberry", "Food", "Fruit", 63));
            Products.Add(new Product("Cinamon", "Food", "Fruit", 54));
            Products.Add(new Product("Cemolina", "Food", "Fruit", 75));
            Products.Add(new Product("Parsley", "Food", "Fruit", 95));
            Products.Add(new Product("Dill", "Food", "Fruit", 85));
            Products.Add(new Product("Tendalier", "Food", "Fruit", 65));
            Products.Add(new Product("Orange", "Food", "Fruit", 75));
            Products.Add(new Product("Cake", "Food", "Fruit", 57));
            Products.Add(new Product("Garlic", "Food", "Fruit", 58));
            Products.Add(new Product("Raspberry", "Food", "Fruit", 45));
            Products.Add(new Product("Melon", "Food", "Fruit", 65));
            Products.Add(new Product("Watermelon", "Food", "Fruit", 15));
            Products.Add(new Product("Cranberry", "Food", "Fruit", 67));
        }
        static void PaintRed1()
        {
            PaintRed(0, "/ List of Products(1) /");
        }
        static void PaintRed2d()
        {
            PaintRed(22, "/ Basket(2) /");
        }
        static void PaintRed3()
        {
            PaintRed(34, "/ Orders(3) /");
        }
        static void PaintRed4()
        {
            PaintRed(45, " / Find(4) /");
        }
        static void PaintRed(int from,string str)
        {
            Console.SetCursorPosition(0, 0);
            Paint();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < str.Length; i++)
            {
                Console.SetCursorPosition(from++, 0);
                Console.Write(str[i]);
            }
            Console.ForegroundColor = ConsoleColor.White; 
            Console.SetCursorPosition(0, 1);
        }

        private static void Paint()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("/ List of Products(1) / Basket(2) / Orders(3) / Find(4) /");
        }

        static void Clear()
        {
            for (int i = 0; i < 80; i++)
            {
                for (int j = 1; j < Products.products.Count+4; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 1);
        }
        static void AddUsers()
        {
            users.Add(new Admin("Danil", "Kravchenko", "danilkrava@ukr.net", "Qwerty1", 1234567890));
            users.Add(new Admin("Mark", "Marchenko", "danilkrava4@gmail.com", "123456", 1452369854));
            users.Add(new RegisteredUser("Ilia", "Makarov", "ilia@gmail.com", "makarov", 1329856329));
            users.Add(new RegisteredUser("Artem", "Ficus", "ficusartem@gmail.com", "ficus2002", 11144455522));
        }
    }
}
