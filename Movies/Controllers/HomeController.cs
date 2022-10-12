using Microsoft.AspNetCore.Mvc;
using Movies.Interface;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMovie _IMovie;

        public HomeController(IMovie movie)
        {
            _IMovie = movie;
        }

        public IActionResult Index()
        {
            return View(_IMovie.List());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}