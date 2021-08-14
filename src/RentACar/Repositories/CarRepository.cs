using RentACar.Data;
using RentACar.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentACarDbContext _data;
        public CarRepository(RentACarDbContext data)
        {
            _data = data;
        }

        public void Add(Car car)
        {
            _data.Add(car);
            Save();
        }

        public IQueryable<Car> GetAll()
        {
            return _data.Cars;
        }

        public void Save()
        {
            _data.SaveChanges();
        }

        public Car FindById(int carId)
        {
            return _data.Cars.FirstOrDefault(x => x.Id == carId);
        }
    }
}
