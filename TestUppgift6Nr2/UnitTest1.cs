using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using uppgit_1_nr2;

namespace TestUppgift6Nr2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGetMembers() // testa man kan h�mta members
        {
            var db = new Database();
            var members = db.GetMembers();

            Assert.IsTrue(members.Any()); // any == finns det n�gon i lista d� �r true
        }

        [TestMethod]
        public void CanGetBooks() // testa man kan h�mta books
        {
            var db = new Database();
            var books = db.GetBooks();

            Assert.IsTrue(books.Any());
        }

        [TestMethod]
        public void CanGetMovie() // testa man kan h�mta movie
        {
            var db = new Database();
            var movies = db.GetMovies();

            Assert.IsTrue(movies.Any());
        }
    }
}
