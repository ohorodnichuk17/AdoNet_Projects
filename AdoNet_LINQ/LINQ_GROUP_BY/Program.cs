using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_GROUP_BY
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return "Product: " + Name + " : " + Category;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = { 5, 34, 65, 12, 94, 42, 365 };

            IEnumerable<IGrouping<int, int>> query = from i in arrayInt
                                                     where i > 10
                                                     group i by i % 10;




            WriteLine("Forming groups of criteria:");
            foreach (IGrouping<int, int> group in query)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (int item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }

            // Метод розширення
            var result = arrayInt.Where(i => i > 10).GroupBy(i => i % 10).OrderBy(g => g.Key);

            // Product Collection
            Product[] arr = {
                new Product() { Name = "Apple", Category = "Food"},
                new Product() { Name = "Phone", Category = "Tech"},
                new Product() { Name = "Laptop", Category = "Tech"},
                new Product() { Name = "banana", Category = "Food"},
                new Product() { Name = "Pelmen", Category = "Food"},
            };

            var res = arr.GroupBy(p => p.Category);

            WriteLine("Forming groups of criteria:");
            foreach (IGrouping<string, Product> group in res)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (Product item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }

            WriteLine("------------------------------");
            var res2 = arr.Where(p => char.IsUpper(p.Name[0])).Select(p => p.Name[0]);

            foreach (var item in res2)
            {
                WriteLine(item);
            }
        }
    }
}
