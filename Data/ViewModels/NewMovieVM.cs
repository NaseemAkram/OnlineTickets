using OnlineTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace OnlineTickets.Data.ViewModels
{
    public class NewMovieVM
    {

        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Movie Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Select actors")]
        [Required(ErrorMessage = "Movie Actors is Required")]

        public List<int> ActorIds { get; set; }


        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie Cinema is Required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Movie Producer is Required")]


        public int ProducerId { get; set; }



    }
}