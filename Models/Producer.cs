using OnlineTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace OnlineTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture ")]
        [Required(ErrorMessage = "The Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name Length should be between 3 to 50")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "The Biography is Required")]
        public string Bio { get; set; }


        //relationship


        public List<Movie>? Movies { get; set; }
    }
}
