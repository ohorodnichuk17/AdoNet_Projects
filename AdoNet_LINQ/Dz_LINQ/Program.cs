using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Дано цілочисельну послідовність. Витягти з неї всі позитивні числа,
            // відсортувавши їх по зростанню.
            int[] arrayNumbers1 = { 4, -2, -89, 35, -45, -1, 12, 4, 6, 78, -5, 63, -99, -52, 89 };
            var query1 = from i in arrayNumbers1
                        where i > 0
                        orderby i 
                        select i;

            Console.WriteLine("Only the positive numbers:");
            foreach (int item in query1)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var result = arrayNumbers1.Where(i => i > 0).Select(i => i).OrderBy(i => i);
            Console.WriteLine("Only the positive numbers by LINQ method:");
            foreach (int item in query1)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();

            Console.WriteLine("-------------------------------------");
            //Дано колекцію цілих чисел. Знайти кількість позитивних двозначних елементів,
            //а також їх середнє арифметичне.
            int[] arrayNumbers2 = { 2, -6, -32, 44, 62, -50, -2, -8, 10, 8, 38, -26, 98 };
            var query2 = from i in arrayNumbers2
                          where i > 10 && i <= 99
                          select i;

            Console.WriteLine("Only the positive two-digit numbers:");
            foreach (var item in query2)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var query3 = (from i in arrayNumbers2
                      where i > 10 && i <= 99
                      select i).Average();
            Console.WriteLine("Average: " + query3);
            Console.WriteLine("\n");

            var result2 = arrayNumbers2.Where(i => i > 10 && i <= 99).Select(i => i);
            Console.WriteLine("Only the positive two-digit numbers by LINQ method:");
            foreach (var item in query2)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var result3 = arrayNumbers2.Where(i => i > 10 && i <= 99).Select(i => i).Average();
            Console.WriteLine("Average by LINQ method: " + result3);
            Console.WriteLine("-------------------------------------");

            // Дано цілочисельну колекцію, яка зберігає список років.
            // Витягти з неї всі високосні роки, відсортувавши їх по зростанню.
            int[] arrayNumbers3 = { 1999, 2003, 2004, 2023, 2005, 2009, 1876, 1327, 2019, 1017, 1279, 2000 };
            var query4 = from i in arrayNumbers3
                         where i % 4 == 0 && i % 100 != 0 
                         orderby i
                         select i;

            Console.WriteLine("Only the leap years:");
            foreach (var item in query4)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var result4 = arrayNumbers3.Where(i => i % 4 == 0 && i % 100 != 0).Select(i => i).OrderBy(i => i);
            Console.WriteLine("Only the leap years by LINQ method:");
            foreach (var item in query4)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------");

            // Дано колекцію цілих чисел. Знайти максимальне парне значення.
            int[] arrayNumbers4 = { 1, 2, 3, -6, 9, 21, 34, -66, -48, 99, 32, 10, 12, 86, 68, -90, 74 };
            var query5 = (from i in arrayNumbers4
                          where i % 2 == 0
                          select i).Max();
            Console.WriteLine("Max: " + query5);
            Console.WriteLine("\n");

            var result5 = arrayNumbers4.Where(i => i % 2 == 0).Select(i => i).Max();
            Console.WriteLine("Max by LINQ method: " + result5);
            Console.WriteLine("-------------------------------------");

            // Дано колекцію непустих рядків. Отримати колекцію рядків,
            // додавши вкінець до кожної три знаки оклику.
            string[] arrayString = { "Hello world", "Hello C#", "Hello Sql", "Hello Python" };
            var query6 = from i in arrayString
                         select i + "!!!";
            Console.WriteLine("String collection: ");
            foreach (var item in query6)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var result6 = arrayString.Select(i => i + "!!!");
            Console.WriteLine("String collection by LINQ method: ");
            foreach (var item in result6)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------");

            // Дано певний символ і строкова колекція.
            // Отримати колекцію строк, які мають відповідний символ.
            string[] arrayString2 = { "Hello world", "Hello linq", "Hello Sql", "Hello ado net" };
            var query7 = from i in arrayString2
                         select i.Contains('l');
            Console.WriteLine("String collection which contains 'l' symbol: ");
            foreach (var item in query7)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");

            var result7 = arrayString2.Select(i => i.Contains('l'));
            Console.WriteLine("String collection which contains 'l' symbol by LINQ method: ");
            foreach (var item in query7)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------");

            // Дано колекцію непустих рядків. Згрупувати всі елементи по кількості символів.
            string[] arrayString3 = { "Hello world", "Hello linq", "H" , "Hello Sql", "Hello ado net", "Hello" };
            IEnumerable<IGrouping<int, string>> query8 = from i in arrayString3
                                                            group i by arrayString3.Length;

            Console.WriteLine("String collection group by length: ");
            foreach(IGrouping<int, string> group in query8)
            {
                Console.Write($"Key: {group.Key}\n Value: ");
                foreach (var item in group)
                {
                    Console.Write($"\t{item}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            var result8 = arrayString3.GroupBy(i => arrayString3.Length);
            Console.WriteLine("String collection group by length by LINQ method: ");
            foreach (IGrouping<int, string> group in result8)
            {
                Console.Write($"Key: {group.Key}\n Value: ");
                foreach (var item in group)
                {
                    Console.Write($"\t{item}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

        }
    }
}