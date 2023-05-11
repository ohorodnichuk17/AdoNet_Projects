using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_INTO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = { 5, 34, 67, 12, 94, 42 };

            IEnumerable<IGrouping<int, int>> query =
                                                    from i in arrayInt
                                                    group i by i % 10 into gr
                                                    where gr.Count() > 1
                                                    select gr;
            //IEnumerable<IGrouping<int, int>> query2 =
            //                                        from gr in (from i in arrayInt
            //                                                    group i by i % 10)
            //                                        where gr.Count() > 1
            //                                        select gr;

            WriteLine("Groups with the number of elements is greater than 1:");

            foreach (IGrouping<int, int> key in query)
            {
                Write($"Key: {key.Key}\nValue:");
                foreach (int item in key)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }

            // Метод розширення
            IEnumerable<IGrouping<int, int>> result = arrayInt.GroupBy(i => i % 10).Where(g => g.Count() > 1);

            foreach (IGrouping<int, int> key in result)
            {

                Write($"Key: {key.Key}\nValue:");
                foreach (int item in key)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }
        }
    }
}
