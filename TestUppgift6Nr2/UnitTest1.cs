using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using uppgit_1_nr2;

namespace TestUppgift6Nr2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGetMembers() // testa man kan hämta members
        {
            var db = new Database();
            var members = db.GetMembers();

            Assert.IsTrue(members.Any()); // any == finns det någon i lista då är true
        }

        [TestMethod]
        public void CanGetBooks() // testa man kan hämta books
        {
            var db = new Database();
            var books = db.GetBooks();

            Assert.IsTrue(books.Any());
        }

        [TestMethod]
        public void CanGetMovie() // testa man kan hämta movie
        {
            var db = new Database();
            var movies = db.GetMovies();

            Assert.IsTrue(movies.Any());
        }
    }
}
