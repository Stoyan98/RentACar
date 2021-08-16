using RentACar.Data;
using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public class CategoryRepository : Repository, ICaregoryRepository
    {
        private readonly RentACarDbContext _context;

        public CategoryRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public bool CategoryExists(int caregoryId)
            => _context.Categories.Any(x => x.Id == caregoryId);

        public IQueryable<Category> GetAllCategories()
            => _context.Categories;
    }
}
