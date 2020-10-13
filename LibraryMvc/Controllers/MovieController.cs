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
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var db = new Database();
            var movies = db.GetMovies();

            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(string id)
        {
            var objectId = new ObjectId(id);
            var db = new Database();
            var movie = db.GetMovieById(objectId);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {   
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) // post att skicka in formulär, collection = formulär som innehåller allt. 
        {
            try
            {
                var movie = new Movie(collection["Title"], collection["Language"], int.Parse(collection["TotalCount"]));

                var db = new Database();
                db.CreateMovie(movie);

                return RedirectToAction(nameof(Index)); // redirectoaction = skicka till annan sida.
            }
            catch
            {
                return View();
            }
        }

        

        // GET: Movie/Delete/5
        public ActionResult Delete(string id)
        {
            var movieId = new ObjectId(id);

            var db = new Database();
            db.DeleteMovieById(movieId);
            return RedirectToAction(nameof(Index));
           
        }

       
    }
}