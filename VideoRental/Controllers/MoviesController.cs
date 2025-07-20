using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoRentalApp.Domain.Models;
using VideoRentalApp.Models.ViewModels;
using VideoRentalApp.Services.Implementation;
using VideoRentalApp.Services.Interfaces;

namespace VideoRentalApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _moviesService;
        private readonly IRentalService _rentalService;

        public MoviesController(IMovieService moviesService, IRentalService rentalService)
        {
            _moviesService = moviesService;
            _rentalService = rentalService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!checkClaim)
            {
                return RedirectToAction("Index", "Home");
            }

            var movies = _moviesService.GetAll();
            //the purpose of the below code block is to hide the availability of the movie if the user had already rented the movie even though the movie is available in the video store
            var rented = _rentalService.GetRentalsByUserId(userId);
            
            foreach(var movie in movies)
            {
                if (rented.Select(x => x.MovieId).Contains(movie.Id))
                {
                    movie.IsAvailable = false;
                }
            }

            return View(movies);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!checkClaim)
            {
                return RedirectToAction("Index", "Home");
            }

            var movie = _moviesService.GetMovieById(id);

            if( movie != null)
            {
                var rented = _rentalService.GetRentalsByUserId(userId);
                var isRentedByUser = rented.Any(x => x.MovieId == movie.Id);

                ViewBag.IsRentedByUser = isRentedByUser;

                return View(movie);
            }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult Rent(int movieId)
        {
            bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!checkClaim)
            {
                return RedirectToAction("Index", "Home");
            }

            _rentalService.RentMovie(movieId, userId);
            
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public IActionResult Rented(int id)
        {
            bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!checkClaim)
            {
                return RedirectToAction("Index", "Home");
            }

            var rentals = _rentalService.GetRentalsByUserId(userId);

            if (rentals != null)
            {
                return View(rentals);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult ReturnMovie(int rentalId, int movieId)
        {
            bool checkClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!checkClaim)
            {
                return RedirectToAction("Index", "Home");
            }

            _rentalService.ReturnMovie(rentalId, movieId);
            return RedirectToAction("Rented");
        }
    }   
}