using OnlineTickets.Models;

namespace OnlineTickets.Data.ViewModels
{
    public class NewMovieDropDownsVM
    {

        public NewMovieDropDownsVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();

        }


        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
