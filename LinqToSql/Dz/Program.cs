using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            LibraryClassesDataContext context = new LibraryClassesDataContext();

            Console.WriteLine("Вибрати всі книги, кількість сторінок в яких більше 100"); 
            var books = context.Books.Where(n => n.NumberPages > 100);
            foreach (var n in books)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати всі книги, ім’я яких починається на літеру ‘А’ або ‘а’");
            var b = context.Books.Where(n => n.Name.StartsWith("A") || n.Name.StartsWith("a"));
            foreach (var n in b)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати всі книги автора Kira");
            var b2 = context.Books.Where(n => n.AuthorId == 6);
            foreach (var n in b2)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати всі книги українських авторів відсортувавши по алфавіту");
            var b3 = context.Books
                .Where(n => n.AuthorId == 1 || n.AuthorId == 5 || n.AuthorId == 6 || n.AuthorId == 7 || n.AuthorId == 10)
                .OrderBy(n => n.Name)
                .ToList();
            foreach (var n in b3)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати всі книги, ім’я в яких складається менше ніж з 10-ти символів");
            var b4 = context.Books.Where(n => n.Name.Length < 10);
            foreach (var n in b4)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати книгу з максимальною кількістю сторінок не американського автора");
            var b5 = context.Books
                .OrderByDescending(n => n.NumberPages)
                .FirstOrDefault(n => n.Author.CountryId != 2);
            if (b5 != null)
            {
                Console.WriteLine($"Name: {b5.Name}");
                Console.WriteLine($"Number of pages: {b5.NumberPages}");
                Console.WriteLine($"Author: {b5.Author.Name}");
            }
            else
                Console.WriteLine("Not found.");
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати автора, який має найменше книг в базі даних");
            var b6 = context.Books.Where(n => n.AuthorId == 1);
            foreach (var n in b4)
            {
                Console.WriteLine($"Book: {n.Id} {n.Name} {n.NumberPages} {n.AuthorId}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати імена всіх авторів, крім американських, розташованих в алфавітному порядку");
            var a = context.Authors.Where(i => i.CountryId != 2).OrderBy(i => i.Name);//.Select(i => i.Name)
            foreach (var n in a)
            {
                Console.WriteLine($"Author: {n.Name}");
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Вибрати країну, авторів якої є найбільше в базі");
            var count = context.Authors.Count(i => i.CountryId == 1);
            Console.WriteLine($"Number of authors from country: {count}");
        }
    }
}
