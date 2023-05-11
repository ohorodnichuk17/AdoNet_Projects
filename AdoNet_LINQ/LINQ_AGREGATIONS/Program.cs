using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_AGREGATIONS
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Aggregate ------------------
            //int[] numbers = { 1, 2, 3, 4, 5 };

            //int query = numbers.Aggregate((x, y) => x - y);
            //// int query = 1 - 2 - 3 - 4 - 5;

            //query = numbers.Aggregate((x, y) => x + y); // аналогично 1 + 2 + 3 + 4 + 5

            //string[] words = { "apple", "banana", "pelmen", "salat" };
            //string res = words.Select(i => i[0].ToString()).Aggregate((x, y) => x + y);

            //Console.WriteLine(res);

            // Count-------------------- -
            //int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            //int size = (from i in numbers
            //            where i % 2 == 0 && i >= 10
            //            select i).Count();
            //Console.WriteLine(size);

            //size = numbers.Where(i => i % 2 == 0 && i > 10).Count();
            //size = numbers.Count(i => i % 2 == 0 && i > 10);
            //Console.WriteLine(size);

            // Sum, Min, Max, Average ---------------------------
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            int sum1 = numbers.Sum();
            decimal sum2 = users.Sum(user => user.Age);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);

            int min1 = numbers.Min();
            int min2 = users.Min(u => u.Age); // минимальный возраст
                                              // int min2 = users.Min(delegate (User u) { return u.Age; }); // минимальный возраст
            Console.WriteLine(min1);
            Console.WriteLine(min2);

            int max1 = numbers.Max();
            var max2 = users.Max(u => u.Name); // максимальный возраст
            Console.WriteLine(max1);
            Console.WriteLine(max2);

            double avr1 = numbers.Average();
            double avr2 = users.Average(u => u.Age); //средний возраст
            Console.WriteLine(avr1);
            Console.WriteLine(avr2);
        }
    }
}
