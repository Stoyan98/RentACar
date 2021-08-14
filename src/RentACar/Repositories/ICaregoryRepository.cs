using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public interface ICaregoryRepository
    {
        bool CategoryExists(int caregoryId);

        IQueryable<Category> GetAllCategories();
    }
}
