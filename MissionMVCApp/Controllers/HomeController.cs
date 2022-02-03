using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MissionMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MissionMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private MovieInfoContext myContext { get; set; }

        public HomeController(MovieInfoContext someName)
        {
            myContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewMovies()
        {
            var movies = myContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryID)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = myContext.Category.ToList();
            var movie = myContext.responses.Single(x => x.MovieID == movieid);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(AddMovieSubmission ams)
        {
            //if (ModelState.IsValid)
            //{
                myContext.Update(ams);
                myContext.SaveChanges();
                return RedirectToAction("ViewMovies");
            //}
            //else  //invalid entry
            //{
            //    ViewBag.Categories = myContext.Category.ToList();
            //    return View(ams);
            //}
        }

        public IActionResult FindPodcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = myContext.Category.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieSubmission am)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(am);
                myContext.SaveChanges();
                return View("Confirmation", am);
            }
            else
            {
                ViewBag.Categories = myContext.Category.ToList();
                return View(am);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = myContext.responses.Single(x => x.MovieID == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(AddMovieSubmission hi)
        {
            myContext.responses.Remove(hi);
            myContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}
