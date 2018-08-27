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
        public ActionResult Index()
        {

            //db.Movies.Add(new Movie
            //{
            //    NameM = "Дэдпул 2",
            //    Description = "Опасные и очень веселые приключения главного героя продолжаются в фантастическом боевике «Дэдпул 2». После того, как простой парень с отличным чувством юмора Уэйд Уилсон приобрел изуродованную внешность, его жизнь сильно изменилась. Но он также приобрел сверхспособности и стал супергероем по прозвищу Дэдпул, что помогло пережить сложные времена. Теперь жизнь наемника никогда не будет прежней, но в ней есть много хорошего. ",
            //    Age = 2018,
            //    DownloadDate = DateTime.Now,
            //    Time = (float)2.13,
            //    Rating = (float)8.1,
            //    Producer = "Хулио Знасиас",
            //    Actor = "Джош Бролин, Райан Рейнольдс",
            //    ImgLogoSrc = "/image/LogoMovieImg/cb8f66329_200x300.jpg",
            //    VideoLinkSrc = "http://pandastream.cc/video/a289951092aa586d/iframe?block_geo=US",
            //    Genre = "боевик, комедия, фантастика",
            //    Country = "США"
            //});
            //db.SaveChanges();

            return View(db.Movies);
        }

        [HttpPost]
        public ActionResult Index(string inputSearch)
        {
            if (!String.IsNullOrWhiteSpace(inputSearch))
            {
              Movie mv =  db.Movies.Where(m => m.NameM.Contains(inputSearch)).FirstOrDefault();
                if (mv!=null)
                {
                    return RedirectToAction("Movie","Home", new { id = mv.MovieId });
                }
                else return View("Index", "Home");
            }
            else return View("Index", "Home");
        }

        [Authorize]
        [OutputCache(Duration = 1)]
        public ActionResult Movie(int id=1)
        {
            ContainerMovie cm = new ContainerMovie();
            if (id>0)
            {
                var mv = db.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                if (mv!=null)
                {
                    cm.Comments = db.Comments.Where(c => c.MovieId == mv.MovieId);
                    cm.OneMovie = mv;
                    cm.Movies = db.Movies;
                    return View(cm);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult random()
        {
            Random rnd = new Random();
            int buf = rnd.Next(1, db.Movies.Count());
            Movie i = db.Movies.OrderBy(m => m.MovieId).Skip(--buf).Take(1).First();
            return RedirectToAction("Movie", "Home", new { id =  i.MovieId});
        }

        [HttpPost]
        public ActionResult comment([Bind(Include = "CommentId,Title,Content, TimeC, MovieId")] ContainerMovie ComMod)
        {
            if (ModelState.IsValid)
            {
                if (ComMod != null)
                {
                    db.Comments.Add(new Comment {
                        Title = ComMod.Title,
                        Content = ComMod.Content,
                        MovieId = ComMod.MovieId,
                        TimeC = DateTime.Now,
                        Movie = db.Movies.Where(m=>m.MovieId == ComMod.MovieId).FirstOrDefault() });
                    db.SaveChanges();
                    return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId });
                }
            }
            else
            {
                return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId });
            }
            return RedirectToAction("Movie", "Home", new { id = ComMod.MovieId });
        }

        [OutputCache(Duration = 2)]
        public ActionResult Faq()
        {
            return View();
        }

        [OutputCache(Duration = 2)]
        public ActionResult Contact()
        {
            return View();
        }

        [Authorize]
        [OutputCache(Duration = 2)]
        public ActionResult Rights()
        {
            return View();
        }
    }
}