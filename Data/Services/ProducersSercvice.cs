using OnlineTickets.Data.Base;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services
{
    public class ProducersSercvice : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersSercvice(AppDbContext context) : base(context)
        {

        }

    }
}
