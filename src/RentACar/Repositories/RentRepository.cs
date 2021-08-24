using RentACar.Data;
using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public class RentRepository : Repository, IRentRepository
    {
        private readonly RentACarDbContext _context;

        public RentRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Rent> GetAll()
        {
            return _context.Rents.OrderByDescending(x => x.StartDate);
        }

        public void Add(Rent rent)
        {
            _context.Add(rent);
            Save();
        }

        public void Remove(int id)
        {
            var rent = _context.Rents.FirstOrDefault(x => x.Id == id);

            _context.Rents.Remove(rent);

            Save();
        }
    }
}
