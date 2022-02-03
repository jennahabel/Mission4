using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
   
        private MovieAppsContext MyContext { get; set; }


        //Constructor
        public HomeController( MovieAppsContext mycontext)
        {
            MyContext = mycontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        //returns the movie view
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.allCategories = MyContext.categories.ToList();

            return View();
        }

        //returns the confirmation view when the form is submitted with a post method
        [HttpPost]
        public IActionResult Movies(AppResponse ar)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.allCategories = MyContext.categories.ToList();

                return View(ar);
            }

            MyContext.Add(ar);
            MyContext.SaveChanges();

            return View("Confirmation", ar);
        }

        //gets all the info from the database and pops it in the ShowMovies View
        public IActionResult ShowMovies()
        {

            var applications = MyContext.movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        //This is the EDIT Get and Post controllers
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.allCategories = MyContext.categories.ToList();

            var app = MyContext.movies.Single(x => x.MovieId == movieid);

            return View("Movies", app);
        }

        [HttpPost]
        public IActionResult Edit(AppResponse update)
        {
            MyContext.Update(update);
            MyContext.SaveChanges();

            return RedirectToAction("ShowMovies");
        }


        //This is the DELETE Get and Post controllers
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var app = MyContext.movies.Single(x => x.MovieId == movieid);

            return View(app);
        }

        [HttpPost]
        public IActionResult Delete(AppResponse delete)
        {
            MyContext.movies.Remove(delete);
            MyContext.SaveChanges();
            return RedirectToAction("ShowMovies");
        }

    }
}
