using RentACar.Data;
using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public class CategoryRepository : ICaregoryRepository
    {
        private readonly RentACarDbContext _data;

        public CategoryRepository(RentACarDbContext data)
        {
            _data = data;
        }

        public bool CategoryExists(int caregoryId)
            => _data.Categories.Any(x => x.Id == caregoryId);

        public IQueryable<Category> GetAllCategories()
            => _data.Categories;
    }
}
