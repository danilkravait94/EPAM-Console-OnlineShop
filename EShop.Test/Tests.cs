using NUnit.Framework;
using EShop;
using EShop.DB;
using EShop.Roles;
using System.Linq;
using System.IO;
using System;

namespace EShop.Test
{
    public class Tests
    {
        [Test]
        public void AddUser_TestForAdmin()
        {
            Admin admin = new Admin();
            Users.users.Add(admin);
            Assert.AreEqual(admin, Users.users.Last());
        }

        [Test]
        public void AddUser_TestForRegisteredUser()
        {
            RegisteredUser user = new RegisteredUser();
            Users.users.Add(user);
            Assert.AreEqual(user, Users.users.Last());
        }
        [Test]
        public void AddToBasket_TestForRegisteredUser()
        {
            RegisteredUser user = new RegisteredUser();
            Product product = new Product();
            user.AddToBasket(product);
            Assert.AreEqual(product, user.Basket.Last());
        }
        [Test]
        public void AddToBasket_TestForAdmin()
        {
            Admin admin = new Admin();
            Product product = new Product();
            admin.AddToBasket(product);
            Assert.AreEqual(product, admin.Basket.Last());
        }
        [Test]
        public void CreateOrder_TestForAdmin()
        {
            Admin admin = new Admin();
            Product product = new Product();

            admin.AddToBasket(product);
            Order order = new Order(product, "UK", 12);
            admin.CreateOrder(order);

            Assert.AreEqual(order, admin.Orders.Last());
        }
        [Test]
        public void SetUp_Test()
        {
            RegisteredUser user = new RegisteredUser("Qwer", "Dfgh", "dadadn@ukr.net", "12345", 12345698);
            User guest = new Guest();

            guest = (guest as Guest).SetUpUser(user);

            Assert.That(guest is RegisteredUser);
        }
        [Test]
        public void SetIn_Test()
        {
            RegisteredUser user = new RegisteredUser("Qwer", "Dfgh", "dadadn@ukr.net", "12345", 12345698);
            User guest = new Guest();

            (guest as Guest).SetUpUser(user);
            guest = (guest as Guest).SetInUser("dadadn@ukr.net", "12345");

            Assert.That(guest is RegisteredUser);
        }
        [Test]
        public void CancelOrder_Test()
        {
            RegisteredUser user = new RegisteredUser();
            Product product = new Product();

            user.AddToBasket(product);
            Order order = new Order(product, "UK", 12);
            user.CreateOrder(order);
            user.CancelOrder(order);

            Assert.That(user.Orders[user.Orders.IndexOf(order)].Status == Order.Statuses.CanceledByUser);
        }
        [Test]
        public void ChangeEmail_Test()
        {
            RegisteredUser user = new RegisteredUser();
            user.ChangeEmail("qwerty@ukr.net");

            Assert.That(user.Email == "qwerty@ukr.net");
        }
        [Test]
        public void ChangePassword_Test()
        {
            RegisteredUser user = new RegisteredUser();
            user.ChangeInfo("45678765");

            Assert.That(user.Pasword == "45678765");
        }
        [Test]
        public void ChangeFullName_Test()
        {
            RegisteredUser user = new RegisteredUser();
            user.ChangeInfo("Mark","Krava");

            Assert.That(user.FirstName == "Mark" && user.LastName == "Krava");
        }
        [Test]
        public void SetGetToOrder_Test()
        {
            RegisteredUser user = new RegisteredUser();
            Product product = new Product();

            user.AddToBasket(product);
            Order order = new Order(product, "UK", 12);
            user.CreateOrder(order);
            user.SetGetToOrder(order);

            Assert.That(user.Orders[user.Orders.IndexOf(order)].Status == Order.Statuses.Recieved);
        }

        [TestCase(Order.Statuses.CanceledByAdmin)]
        [TestCase(Order.Statuses.Sent)]
        [TestCase(Order.Statuses.Ended)]
        public void ChangeStatus_Test(Order.Statuses status)
        {
            Admin admin = new Admin();
            Product product = new Product();

            admin.AddToBasket(product);
            Order order = new Order(product, "UK", 12);
            admin.CreateOrder(order);
            admin.ChangeStatus(order,status);

            Assert.That(admin.Orders[admin.Orders.IndexOf(order)].Status == status);
        }

        [Test]
        public void ChangeProduct_Test()
        {
            Admin admin = new Admin();
            Product product = new Product();

            admin.ChangeProduct(product, 123);
            Assert.That(product.Price == 123);
        }
    }
}