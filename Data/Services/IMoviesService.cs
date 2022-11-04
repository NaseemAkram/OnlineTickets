using OnlineTickets.Data.Base;
using OnlineTickets.Data.ViewModels;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {

        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues();


        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);

    }

}
