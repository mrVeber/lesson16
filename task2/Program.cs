using System;
using System.IO;
using System.Text.Json;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(@"D:\lessons itmo\lesson16\Products.json"))
            {
               jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxsells = products[0];

            foreach (Product p in products)
            {
                if (p.ProductPrice > maxsells.ProductPrice)
                {
                    maxsells = p;
                }
            }
            Console.WriteLine($"Самый дорогой продукт это: {maxsells.ProductName} \nС кодом: {maxsells.ProductCode} \nЦена: {maxsells.ProductPrice}");
            Console.ReadKey();
        }
    }
}
