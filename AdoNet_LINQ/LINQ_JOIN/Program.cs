using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_JOIN
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
    }

    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var anonimousType = new
            //{
            //    Number = 456,
            //    Name = "Eduard",
            //    Koef = 1.5
            //};

            List<Group> groups = new List<Group>
            {
                new Group { Id = 1, Name = "27PPS11" },
                new Group { Id = 2, Name = "27PPS12" }
            };
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Miller", GroupId = 2 },
                new Student { FirstName = "Candice", LastName = "Leman", GroupId = 1 },
                new Student { FirstName = "Joey", LastName = "Finch", GroupId = 1 },
                new Student { FirstName = "Nicole", LastName = "Taylor", GroupId = 3 }
            };

            foreach (var g in groups)
            {
                foreach (var st in students)
                {
                    if (g.Id == st.GroupId)
                    {
                        var res = new
                        {
                            g.Name,
                            st.FirstName,
                            st.LastName
                        };
                    }
                }
            }

            var query = from g in groups
                        join st in students on g.Id equals st.GroupId
                        select new { FirstName = st.FirstName, LastName = st.LastName, GroupName = g.Name };


            WriteLine("\tStudents in groups:");
            foreach (var item in query)
            {
                WriteLine($"Surname: {item.LastName}, " +
                          $"Name: {item.FirstName}, " +
                          $"Group:{item.GroupName}");
            }
            System.Console.WriteLine("------------------------------------------");

            var result = groups.Join(students,
                                        g => g.Id,
                                        st => st.GroupId,
                                        (g, st) => new { StudentName = st.FirstName, GroupName = g.Name });

            foreach (var item in result)
            {
                WriteLine($"Student: {item.StudentName}, " +
                          $"Group:{item.GroupName}");
            }
        }
    }
}
