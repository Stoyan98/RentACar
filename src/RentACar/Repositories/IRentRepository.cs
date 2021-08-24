using RentACar.Data.Models;
using System.Linq;

namespace RentACar.Repositories
{
    public interface IRentRepository
    {
        IQueryable<Rent> GetAll();

        void Add(Rent rent);

        void Remove(int id);
    }
}
