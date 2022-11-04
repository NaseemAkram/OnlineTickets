using OnlineTickets.Data.Base;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
