using RentACar.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);

        IQueryable<Car> GetAll();

        Car FindById(int carId);

        void Save();
    }
}
