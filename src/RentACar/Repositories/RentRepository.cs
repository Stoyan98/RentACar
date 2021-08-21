using RentACar.Data;
using RentACar.Data.Models;

namespace RentACar.Repositories
{
    public class RentRepository : Repository, IRentRepository
    {
        private readonly RentACarDbContext _context;

        public RentRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Rent rent)
        {
            _context.Add(rent);
            Save();
        }
    }
}
