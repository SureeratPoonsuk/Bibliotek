using System;
using uppgit_1_nr2;

namespace VisitorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bibliotek besök app");
            ShowBooks();

            Console.ReadKey();
        }

        private static void ShowBooks() // visa bok
        {
            Database db = new Database();
            var books = db.GetBooks();

            foreach (var book in books)
            {                
                Console.WriteLine($"- Titel: {book.Title}, Författare: {book.Author}, Antal: {book.TotalCount}");
            }

        }
    }
}
