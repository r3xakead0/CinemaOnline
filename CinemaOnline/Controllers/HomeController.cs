using CinemaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CinemaOnline.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db = new MovieContext();
        public int pageSize = 16; 
        public ActionResult Index(int page =1)
        {
            MoviessListViewModel model = new MoviessListViewModel
            {
                MoviesListAll = db.Movies,
                moviespage = db.Movies
                    .OrderByDescending(s => s.DownloadDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Movies.Count()
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string inputSearch)
        {
            if (!String.IsNullOrWhiteSpace(inputSearch))
            {
                Movie mv = db.Movies.Where(m => m.NameM.Contains(inputSearch)).FirstOrDefault();
                if (mv != null)
                {
                    return RedirectToAction("Movie", "Home", new { id = mv.MovieId });
                }
                else return View("Index", "Home");
            }
            else return View("Index", "Home");
        }

        //[Authorize]
        //[ValidateAntiForgeryToken]
        [OutputCache(Duration = 360)]
        public ActionResult Movie(int id = 1)
        {
            ContainerMovie cm = new ContainerMovie();
            if (id > 0)
            {
                var mv = db.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                if (mv != null)
                {
                    cm.Comments = db.Comments.Where(c => c.MovieId == mv.MovieId);
                    cm.OneMovie = mv;
                    cm.Movies = db.Movies;
                    return View(cm);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        //Menu 
        public ActionResult random()
        {
            Random rnd = new Random();
            int buf = rnd.Next(1, db.Movies.Count());
            Movie i = db.Movies.OrderBy(m => m.MovieId).Skip(--buf).Take(1).First();
            return RedirectToAction("Movie", "Home", new { id = i.MovieId });
        }

        public ActionResult newsMovie(int page = 1)
        {
            MoviessListViewModel model = new MoviessListViewModel
            {
                MoviesListAll = db.Movies,
                moviespage = db.Movies
                    .Where(m => m.Age == 2018)
                    .OrderByDescending(s => s.DownloadDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                
            };
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = model.moviespage.Count()
            };
            return View("Index", model);
        }

        //Genre
        public ActionResult Genre(string genre)
        {
            int page = 1;
            MoviessListViewModel model = new MoviessListViewModel
            {
                MoviesListAll = db.Movies,
                moviespage = db.Movies
                    .Where(m => m.Genre.Contains(genre))
                    .OrderByDescending(s => s.DownloadDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
            };
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = model.moviespage.Count()
            };
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult comment([Bind(Include = "CommentId,Title,Content, TimeC, MovieId")] ContainerMovie ComMod)
        {
            if (String.IsNullOrWhiteSpace(ComMod.Title)) { ModelState.AddModelError("Title", "Поле не должно быть пустым");}
            if (ModelState.IsValid)
            {
                if (ComMod != null)
                {
                    db.Comments.Add(new Comment {
                        Title = ComMod.Title,
                        Content = ComMod.Content,
                        MovieId = ComMod.MovieId,
                        TimeC = DateTime.Now,
                        Movie = db.Movies.Where(m=>m.MovieId == ComMod.MovieId).FirstOrDefault()
                    });
                    db.SaveChanges();
                    return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId });
                }
            }
            else{return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId});}
            return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId });
        }

        [OutputCache(Duration = 360)]
        public ActionResult Faq()
        {
            return View();
        }

        [OutputCache(Duration = 360)]
        public ActionResult Contact()
        {
            return View();
        }

        [Authorize]
        [OutputCache(Duration = 360)]
        public ActionResult Rights()
        {
            return View();
        }
    }
}