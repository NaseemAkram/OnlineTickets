using OnlineTickets.Data.Base;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {


        public ActorsService(AppDbContext context) : base(context)
        {

        }

    }
}
