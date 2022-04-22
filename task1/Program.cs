using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace task1
{
    class Program
    {

        static void Main(string[] args)
        {
            const int number = 3;
            Product[] products = new Product[number];

            for (int i = 0; i < number; i++)
            {
                Console.Write("Введите код продукта: ");
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите название продукта: ");
                string productName = Convert.ToString(Console.ReadLine());
                Console.Write("Введите цену продукта: ");
                double productPrice = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { ProductCode = productCode, ProductName = productName, ProductPrice = productPrice };

                Console.Clear();
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter(@"D:\lessons itmo\lesson16\Products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
