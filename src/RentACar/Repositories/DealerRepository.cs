using RentACar.Data;

namespace RentACar.Repositories
{
    public class DealerRepository : Repository, IDealerRepository
    {
        private readonly RentACarDbContext _context;

        public DealerRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
