using Microsoft.AspNetCore.Mvc;
using Movies.Interface;
using Movies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http.Headers;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovie _IMovie;

        public MovieController(IMovie movie)
        {
            _IMovie = movie;
        }


        public IActionResult Index()
        {
            
            return View(_IMovie.List());
            
        }

        public IActionResult Lancamentos()
        {

            return View(_IMovie.Lista());

        }

    }
}
