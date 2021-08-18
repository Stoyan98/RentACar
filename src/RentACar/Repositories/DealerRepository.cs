using RentACar.Data;
using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public class DealerRepository : Repository, IDealerRepository
    {
        private readonly RentACarDbContext _context;

        public DealerRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Dealer dealer)
        {
            _context.Add(dealer);
            Save();
        }

        public int DealerIdByUser(string userId)
        {
            return _context
                    .Dealers
                    .Where(d => d.UserId == userId)
                    .Select(d => d.Id)
                    .FirstOrDefault();
        }

        public bool IsDealer(string userId)
        {
            return _context
                    .Dealers
                    .Any(d => d.UserId == userId);
        }
    }
}
