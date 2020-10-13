using System;
using System.Collections.Generic;
using System.Text;

namespace uppgit_1_nr2
{
    class LibraryApp
    {
        private List<Item> items;
        private List<Member> members;
        private List<Loan> getLoans;

        public void Start()
        {
            while (true)
            {
                bool exit = false;

                int selectedMenu = ShowMenu();

                switch (selectedMenu)
                {

                    case 1:
                        CreateBook();
                        break;


                    case 2:
                        ShowBooks();
                        break;

                    case 3:
                        DeleteBook();
                        break;


                    case 4:
                        CreateMember();
                        break;

                    case 5:
                        ShowMembers();
                        break;

                    case 6:
                        DeleteMember();
                        break;
                    case 7:
                        CreateMovie();
                        break;
                    case 8:
                        ShowMovie();
                        break;
                    case 9:
                        DeleteMovie();
                        break;
                    case 10:
                        ShowItems();
                        break;

                    case 11:
                        LoanItem();
                        break;
                    case 12:
                        GetLoan();
                        break;



                    default:
                        exit = true;
                        break;




                }

                if (exit)
                {
                    break;
                }

            }




        }



        private int ShowMenu()
        {
            Console.WriteLine("=====Meny=====");
            Console.WriteLine("1.Skapa bok");
            Console.WriteLine("2.Visa alla böcker");
            Console.WriteLine("3.Ta bort bok");
            Console.WriteLine("4.Skapa medlem");
            Console.WriteLine("5.Visa alla medlemmar");
            Console.WriteLine("6.Tar bort medlem");
            Console.WriteLine("7.Skapa film");
            Console.WriteLine("8.Visa alla filmer");
            Console.WriteLine("9.Tar bort filmer");
            Console.WriteLine("10.Visa artiklar");
            Console.WriteLine("11.Låna artikel");
            Console.WriteLine("12.Visa alla lån");

            Console.WriteLine("Skriv Exit för att gå ur");

            Console.Write("Skriv alternativ: ");
            string input = Console.ReadLine();
            int.TryParse(input, out var selectedOption);

            return selectedOption;

        }

        private void CreateBook() // skapa bok
        {
            Console.Clear();
            Console.Write("Skriv titel:");
            var title = Console.ReadLine();

            Console.Write("Skriv författare:");
            var author = Console.ReadLine();

            Console.Write("Skriv antal:");
            var count = int.Parse(Console.ReadLine());


            var book = new Book(title, author,count);
            var db = new Database();
            db.CreateBook(book);

        }

        private void ShowBooks() // visa bok
        {
            Console.Clear();

            Database db = new Database();
            var books = db.GetBooks();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Author}");
            }

        }

        private void DeleteBook() // tar bort bok
        {
            Console.Clear();
            ShowBooks();

            Console.WriteLine("Delete...");
            Console.WriteLine("Skriv namn för att ta bort:");
            string input = Console.ReadLine();

            Database db = new Database();
            db.DeleteBook(input);


        }

    

        private void CreateMember() // skapa användare
        {
            Console.Clear();
            Console.WriteLine("Create member...");

            Console.Write("Skriv ditt namn: ");
            var namn = Console.ReadLine();

            Console.Write("Skriv adress: ");
            var address = Console.ReadLine();

            var member = new Member(namn, address);

            Database db = new Database();
            db.CreateMember(member);



        }

        private void ShowMembers() // visa alla member
        {
            Database db = new Database();
            members = db.GetMembers();
            Console.Clear();

            var count = 1; // skriva siffror istället för ID nummer.
            foreach (var member in members)
            {
                Console.WriteLine($"{count}: {member.Name}, {member.Address}");
                count++;
            }
        }

        private void DeleteMember() // tar bort member
        {
            Console.Clear();
            ShowMembers();

            Console.WriteLine("Delete member.....");
            Console.Write(" välj member du vill tar bort:");
            string input = Console.ReadLine();

            Database db = new Database();
            db.DeleteMember(input);

        }

        // uppgift 2
        private void CreateMovie() // skapa film
        {
            Console.Clear();
            Console.Write("Skriv titel:");
            var title = Console.ReadLine();

            Console.Write("Skriv Språk:");
            var lang = Console.ReadLine();

            Console.Write("Skriv antal:");
            var count = int.Parse(Console.ReadLine());

            var movie = new Movie(title,lang, count );
            var db = new Database();
            db.CreateMovie(movie);

        }

        private void ShowMovie() // visa alla film
        {
            Database db = new Database();
            var movies = db.GetMovies();
            Console.Clear();


            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Title}, {movie.Language}");
            }
        }

        private void DeleteMovie() // tar bort filmer
        {
            Console.Clear();
            ShowMovie();

            Console.WriteLine("Delete movie.....");
            Console.Write(" välj movie du vill tar bort:");
            string input = Console.ReadLine();

            Database db = new Database();
            db.DeleteMovie(input);

        }

        private void ShowItems() // visa alla böcker och filmer.
        {
            Console.Clear();
            Database db = new Database();
            items = db.GetItems();

            var count = 1;
            foreach (var item in items)
            {
                var type = item is Book ? "book" : "movie"; // true, false..item är book .. book är sant ..item inte är book = movie
                Console.WriteLine($"{count}:{item.Title} ({type})");
                count++;
            }

        }

        public void LoanItem() // låna artikel
        {

            Database db = new Database();
            Console.Clear();
            ShowItems(); // visa alla böcker och filmer

            Console.Write("Välj artikel du vill låna (siffra): ");
            var itemCount = int.Parse(Console.ReadLine());
            var item = items[itemCount - 1]; //välj artikel som man vill låna

            var loanCount = db.GetLoansByItem(item); // hämta vi ut hur många av just artikel är lånare.

            if(loanCount >= item.TotalCount) // Om det inte finns någor ledigt så stopa vi. 
            {
                Console.WriteLine("Det finns inget tillgängligt exemplar.");
                return;
            }

            ShowMembers();// visa medlem 
            Console.Write("Välj medlem (siffra): ");
            var memberCount = int.Parse(Console.ReadLine());
            var member = members[memberCount - 1];

            var start = DateTime.Now;
            var end = start.AddDays(14); // slut datum om 14 dagar.

            var loan = new Loan(member,item,start,end);

            db.CreateLoan(loan);

        }
        private void GetLoan() // visa alla som är utlånare, datum och slut datum
        {
            Console.Clear();
            Database db = new Database();
            var loans = db.GetLoans();

            foreach (var loan in loans)
            {
                Console.WriteLine($"{loan.Item.Title}, {loan.Member.Name},{loan.StartDate} - {loan.EndDate}");
            }

        }






    }



}






