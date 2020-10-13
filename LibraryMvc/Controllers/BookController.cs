using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using uppgit_1_nr2;

namespace LibraryMvc.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var db = new Database();
            var books = db.GetBooks();


            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(string id)
        {
            var bookId = new ObjectId(id);

            var db = new Database();
            var book = db.GetBookById(bookId);

            return View(book);


        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var book = new Book(collection["Title"], collection["Author"], int.Parse(collection["TotalCount"]));

                var db = new Database();
                db.CreateBook(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // POST: Book/Delete/5
        public ActionResult Delete(string id)
        {
            var bookId = new ObjectId(id);

            var db = new Database();
            db.DeleteBook(bookId);
            return RedirectToAction(nameof(Index));
        }


    }
}