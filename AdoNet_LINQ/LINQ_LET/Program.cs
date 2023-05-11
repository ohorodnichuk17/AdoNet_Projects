using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_LET
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] poem = {
                "All the world's a stage,",
                "And all the men and women merely players; ",
                "They have their exits and their entrances,",
                "And one man in his time plays many parts,",
                "His acts being seven ages…"
            };

            IEnumerable<string> query = from p in poem
                                        let words = p.Split(' ', ';', ',')
                                        from w in words
                                        where w.Count() > 5
                                        select w;

            WriteLine("Words, in which more than 5 characters:");
            foreach (string item in query)
            {
                WriteLine($"\t{item}");
            }

            string[] arr = { "blaba", "ukhdt", "afag" };
            var q = arr.SelectMany(i => i.ToArray());

            foreach (var item in q)
            {
                Write(item + " ");
            }
            System.Console.WriteLine();

            // Метод розширення
            IEnumerable<string> result = poem.SelectMany(p => p.Split(' ', ';', ',')).Where(i => i.Count() > 5);
            foreach (string item in result)
            {
                WriteLine($"\t{item}");
            }

        }
    }
}
