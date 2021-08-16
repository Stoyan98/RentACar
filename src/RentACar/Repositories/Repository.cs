using RentACar.Data;

namespace RentACar.Repositories
{
    public abstract class Repository : IRepository
    {
        private readonly RentACarDbContext _context;

        public Repository(RentACarDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
