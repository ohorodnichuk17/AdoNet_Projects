using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_WHERE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = { 5, 34, 67, 12, 94, 42 };
            //IEnumerable<int> query;

            var query = from i in arrayInt
                        where i % 2 == 0
                        select i * -1;

            WriteLine("Only the even elements:");
            foreach (int item in query)
            {
                Write($"{item}\t");
            }
            WriteLine();

            // Метод розширення
            query = arrayInt.Where(item => item % 2 == 0).Select(i => i * -1);


            WriteLine("Only the even elements:");
            foreach (int item in query)
            {
                Write($"{item}\t");
            }
            WriteLine();

            // Фільтрація слів по кількості символів
            string[] words = { "jello", "faee", "tyytik", "erte", "qwe", "bvnv", "fhjfhj" };

            var result = from word in words
                         where word.Length == 4
                         select word;
            int count = 0;
            foreach (var i in result)
            {
                System.Console.WriteLine($"{++count}. {i}");
            }


            var result1 = words.Where(word => word.Length == 4).Select(i => i); // int max = words.Max(w => w.Length);

            int count1 = 0;
            foreach (var i in result1)
            {
                System.Console.WriteLine($"{++count1}. {i}");
            }

        }
    }
}
