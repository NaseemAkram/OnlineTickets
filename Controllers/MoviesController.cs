using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTickets.Data.Services;
using OnlineTickets.Data.ViewModels;

namespace OnlineTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allmovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allmovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //movies/details

        public async Task<IActionResult> Details(int id)
        {
            var moviedetails = await _service.GetByIdAsync(id);
            return View(moviedetails);
        }


        //create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var moviedroopdown = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(moviedroopdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedroopdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedroopdown.Actors, "Id", "FullName");

            return View();
        }


        [HttpPost]


        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedroopdown = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(moviedroopdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedroopdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedroopdown.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }



        //Movies/edit/id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var moviedetails = await _service.GetByIdAsync(id);

            if (moviedetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM()
            {
                Id = moviedetails.Id,
                Name = moviedetails.Name,
                Description = moviedetails.Description,
                Price = moviedetails.Price,
                ImageURL = moviedetails.ImageURL,
                StartDate = moviedetails.StartDate,
                EndDate = moviedetails.EndDate,
                MovieCategory = moviedetails.MovieCategory,
                CinemaId = moviedetails.CinemaId,
                ProducerId = moviedetails.ProducerId,
                ActorIds = moviedetails.Actors_Movies.Select(n => n.ActorId).ToList()

            };


            var moviedroopdown = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(moviedroopdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(moviedroopdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviedroopdown.Actors, "Id", "FullName");

            return View(response);
        }


        [HttpPost]


        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }


            if (!ModelState.IsValid)
            {
                var moviedroopdown = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(moviedroopdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedroopdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedroopdown.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }
    }
}
