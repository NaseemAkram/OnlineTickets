using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data.Base;
using OnlineTickets.Data.ViewModels;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {


        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newmovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                ImageURL = data.ImageURL,
                Price = data.Price,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId

            };

            await _context.Movies.AddAsync(newmovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newmovie.Id,
                    ActorId = actorId

                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetail = await _context.Movies.Include(c => c.Cinema).Include(p => p.Producer).Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);

            return movieDetail;
        }

        public async Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {

            var dbmovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);


            if (dbmovie != null)
            {

                dbmovie.Name = data.Name;
                dbmovie.Description = data.Description;
                dbmovie.ImageURL = data.ImageURL;
                dbmovie.Price = data.Price;
                dbmovie.CinemaId = data.CinemaId;
                dbmovie.StartDate = data.StartDate;
                dbmovie.EndDate = data.EndDate;
                dbmovie.MovieCategory = data.MovieCategory;
                dbmovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //remove existing acotr
            var existingactordb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingactordb);
            await _context.SaveChangesAsync();

            //add movie actor

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId

                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }
    }
}
