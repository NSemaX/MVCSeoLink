using SeoFriendly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeoFriendly.Controllers
{
    public class HomeController : Controller
    {

        [Route("~/")]
        [Route("Home")]
        public ActionResult Index()
        {
            List<Films> filmlist = new List<Films>();
            filmlist = GetFilms();
            return View(filmlist);
        }

        public List<Films> GetFilms()
        {
            List<Films> filmlist = new List<Films>();
            filmlist.Add(new Films { Id = 1, Title = "Iron Man 3" });
            filmlist.Add(new Films { Id = 2, Title = "Batman Begins" });
            filmlist.Add(new Films { Id = 3, Title = "Superman vs Batman Dawn of Justice" });
            filmlist.Add(new Films { Id = 4, Title = "Amazing Spiderman" });
            return filmlist;
        }

        [Route("Detail/{Film_Id}/{seo_text}")]
        public ActionResult Detail(int Film_Id,string seo_text)
        {
           Films film = new Films();
            film = GetFilms().Where(x => x.Id == Film_Id).FirstOrDefault();
            if (SeoFriendlyLink.FriendlyURLTitle(film.Title) != seo_text)
            {
                return HttpNotFound();
            }

            return View(film);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}