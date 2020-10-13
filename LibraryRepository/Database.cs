using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace uppgit_1_nr2
{
    public class Database
    {
        private const string BOOK_COLLECTION = "books"; // detta är konstant ska man byta namn så räcker med ändra här "books"... 
        private const string MEMBER_COLLECTION = "members";
        private const string MOVIE_COLLECTION = "movies";
        private const string LOAN_COLLECTION = "loans";     


        public void CreateBook(Book book) // skapa böcker
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION); // Book (class) vilken typ som hämta från collection (books)

            collection.InsertOne(book);

        }

        public List<Book> GetBooks() // Visa alla böcker
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);// books = tabel i mongo

            return collection.Find(r => true).ToList(); // r = den här hämta ut alla böcker som finns i tabel.  Tolist att den gör om till en lista

        }

        public Book GetBook(string title) // hämta ut en bok (för att låna)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);// books = tabel i mongo

            return collection.Find(r => r.Title == title).First(); // hitta bok som har samma titel och ta första (first) alla titel som har samma och säga vi vill har den första.
        }

        public Book GetBookById(ObjectId id) // hämta ut en bok (för att låna)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);// books = tabel i mongo

            return collection.Find(r => r.Id == id).First(); // hitta bok som har samma id och ta första (first) alla titel som har samma och säga vi vill har den första.
        }

        public void UpdateBook(Book book)  // updatera book
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);

            collection.ReplaceOne(m => m.Title == book.Title, book); // ersätt bok som har samma titel med den vi skicka in
        }

        public void DeleteBook(string title)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);

            collection.DeleteOne(b => b.Title == title);// .DeleteOne ( mongodb) ...Man gå genom varje bok i databasen == (title is true)
        }

        public void DeleteBook(ObjectId id)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Book>(BOOK_COLLECTION);

            collection.DeleteOne(b => b.Id == id);// .DeleteOne ( mongodb) ...Man gå genom varje bok i databasen == (title is true)
        }


        public void CreateMember(Member member)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Member>(MEMBER_COLLECTION);

            collection.InsertOne(member);
        }


        public List<Member> GetMembers() // Visa alla memmber
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Member>(MEMBER_COLLECTION);//  tabel i mongo

            return collection.Find(r => true).ToList();

        }

        public Member GetMemberById(ObjectId id) // Visa alla memmber
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Member>(MEMBER_COLLECTION);//  tabel i mongo

            return collection.Find(r => r.Id == id).First();

        }

        public void DeleteMember(string names)
           {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Member>(MEMBER_COLLECTION);

            collection.DeleteOne(b => b.Name == names);
        }

        public List<Item> GetItems() // item sortera film och movie
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var bookCollection = database.GetCollection<Book>(BOOK_COLLECTION);
            var movieCollection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            var books = bookCollection.Find(r => true).ToList();
            var movies = movieCollection.Find(r => true).ToList();

            var items = new List<Item>();
            items.AddRange(books);
            items.AddRange(movies);
            return items;
        }

        public Item GetItemById(ObjectId id) // item sortera film och movie
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var bookCollection = database.GetCollection<Book>(BOOK_COLLECTION);
            var movieCollection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            var book = bookCollection.Find(r => r.Id == id).FirstOrDefault();

            if (book != null)
            {
                return book;
            }

            var movie = movieCollection.Find(r => r.Id == id).First();
            return movie;
        }


        // uppgift2

        public void CreateMovie(Movie movie)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            collection.InsertOne(movie);
        }

        public void UpdateMovie(Movie movie)// visa movie
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            collection.ReplaceOne(m => m.Title == movie.Title, movie); // ersätt film som har samma titel med den vi skicka in
        }


        public Movie GetMovie(string title) // hämta ut en film (för att låna)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);//  tabel i mongo

            return collection.Find(r => r.Title == title).First(); // hitta film som har samma titel och ta första
        }
        
        // MVC
        public Movie GetMovieById(ObjectId id) // hämta ut en film (för att låna)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);//  tabel i mongo

            return collection.Find(r => r.Id == id).First(); // hitta film som har samma id och ta första
        }

        public List<Movie> GetMovies() // Visa alla filmer
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);// = tabel i mongo

            return collection.Find(r => true).ToList();

        }

        public void DeleteMovie(string title ) // tar bort film
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            collection.DeleteOne(b => b.Title == title);// .DeleteOne ( mongodb) ...Man gå genom varje bok i databasen == (title is true)
        }

        // MV Delete
        public void DeleteMovieById(ObjectId id) // tar bort film
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Movie>(MOVIE_COLLECTION);

            collection.DeleteOne(b => b.Id == id);// .DeleteOne ( mongodb) ...Man gå genom varje bok i databasen 
        }

        public void CreateLoan(Loan loan) // skapa låna
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Loan>(LOAN_COLLECTION);

            collection.InsertOne(loan);
        }
        
        public int GetLoansByItem(Item item)  
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Loan>(LOAN_COLLECTION);

            var loans = collection.Find(x => x.Item.Id == item.Id && DateTime.Now < x.EndDate).ToList();

            return loans.Count;
        }

        public void UpdateLoan(Loan loan)// visa alla lån 
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Loan>(LOAN_COLLECTION);

            collection.ReplaceOne(b => b.Id == loan.Id,loan);
        }


        public List<Loan> GetLoans() // hämta låne lista start och slut
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Loan>(LOAN_COLLECTION);

            return collection.Find(x => DateTime.Now < x.EndDate).ToList();
        }
        // MVC
        public Loan GetLoanById(ObjectId id)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Library");

            var collection = database.GetCollection<Loan>(LOAN_COLLECTION);

            return collection.Find(x => x.Id == id).First();
        }

        // mvc
       public void DeleteLoanById(ObjectId id)
       {
           MongoClient dbClient = new MongoClient();

           var database = dbClient.GetDatabase("Library");

           var collection = database.GetCollection<Loan>(LOAN_COLLECTION);
           collection.DeleteOne(b => b.Id ==id);
       }


    }
}
