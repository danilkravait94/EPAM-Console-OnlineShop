using System;
using System.Collections.Generic;

namespace EShop.DB
{
    public static class Products
    {
        public static List<Product> products { get; set; } = new List<Product>();
        readonly static List<Product> deletedProducts = new List<Product>();
        public static void Add(Product product)
        {
            if (!products.Contains(product))
            {
                products.Add(product);
            }
        }
        public static void Remove(Product product)
        {
            deletedProducts.Add(product);
            products.Remove(product);
        }
        public static void ShowProducts()
        {
            foreach (Product pro in products)
            {
                Console.WriteLine(pro);
            }
        }
        public static Product FindProduct()
        {
            Console.Write("Write a name of product: ");
            string name = Console.ReadLine();
            foreach (Product pro in products)
            {
                if (pro.Name.ToLower() == name.ToLower())
                {
                    return pro;
                }
            }
            return null;
            
        }
    }
}
