using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace OnlineTickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
